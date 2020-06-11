import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, Inject, OnDestroy, ViewChild, ElementRef, AfterViewChecked } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TicketSupport, Chat } from 'src/app/models/models';
import { Subject, Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { SessionService } from 'src/app/shared';
@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit, OnDestroy, AfterViewChecked {
  @ViewChild('scrollMe', { static: false }) private myScrollContainer: ElementRef;
  subs: Subscription[] = [];

  myForm: FormGroup;
  myFormChat: FormGroup;

  o = new TicketSupport();
  idTicket = 0;
  chat = new Chat();
  title = '';
  chats: Chat[] = [];
  collaborateurs = this.uow.users.get();


  folderToSaveInServer = 'ticketSupports';

  priorites = ['Normale', 'haute', 'Urgente'];

  /*{imagesInit}*/



  constructor(
    // public dialogRef: MatDialogRef<any>, @Inject(MAT_DIALOG_DATA) public data: any
    private route: ActivatedRoute, private fb: FormBuilder
    , private uow: UowService, private router: Router
    , public session: SessionService) { }

  ngOnInit() {
    this.createForm();
    this.createFormChat();
    this.idTicket = +this.route.snapshot.paramMap.get('id');
    if (this.idTicket !== 0) {
      this.uow.ticketSupports.getOne(this.idTicket).subscribe(r => {
        this.o = r as TicketSupport;
        console.log(this.o);
        this.title = 'Modifier TicketSupport';
        this.createForm();
        this.createFormChat();

        this.uow.chats.getByTicket(this.idTicket).subscribe(r => {
          console.log(r);
          this.chats = r as any;
        });
      });
    }

    this.scrollToBottom();
  }

  ngAfterViewChecked() {
    this.scrollToBottom();
  }

  isYou(id) {
    return +id === +this.session.user.id;
  }

  scrollToBottom(): void {
    try {
      this.myScrollContainer.nativeElement.scrollTop = this.myScrollContainer.nativeElement.scrollHeight;
    } catch (err) { }
  }

  displayName(u: any) {
    return u.userName !== '' ? u.userName : u.email.substring(0, u.email.indexOf('@')) ;
  }

  onNoClick(): void {
    // this.dialogRef.close();
  }

  onOkClick(o: TicketSupport): void {
    let sub = null;
    if (o.id === 0) {
      sub = this.uow.ticketSupports.post(o).subscribe(r => {
        this.router.navigate(['/admin/ticketSupport']);
        // this.dialogRef.close(o);
      });
    } else {
      sub = this.uow.ticketSupports.put(o.id, o).subscribe(r => {
        this.router.navigate(['/admin/ticketSupport']);
        // this.dialogRef.close(o);
      });
    }

    this.subs.push(sub);
  }

  createForm() {
    this.myForm = this.fb.group({
      id: [this.o.id, [Validators.required,]],
      question: [this.o.question, [Validators.required,]],
      dateCreation: [this.o.dateCreation, [Validators.required,]],
      priorite: [this.o.priorite, [Validators.required,]],
      idCollaborateur: [this.o.idCollaborateur, [Validators.required,]],
    });
  }

  createFormChat() {
    this.myFormChat = this.fb.group({
      id: [this.chat.id, [Validators.required,]],
      idSender: [this.session.user.id, [Validators.required,]],
      idReceiver: [this.chat.idReceiver],
      message: [this.chat.message, [Validators.required,]],
      vu: [this.chat.vu, [Validators.required,]],
      date: [this.chat.date, [Validators.required,]],
      idTicketSupport: [this.idTicket, [Validators.required,]],
    });
  }

  onReceiveMessage(o: Chat) {
    this.chats.push(o);
  }

  send(o: Chat) {
    console.log(o);
    this.uow.chats.post(o).subscribe(r => {
      this.chats.push(o);
    });
  }

  resetForm() {
    this.o = new TicketSupport();
    this.createForm();
  }

  ngOnDestroy(): void {
    this.subs.forEach(e => {
      e.unsubscribe();
    });
  }

}
