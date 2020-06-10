import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TicketSupport, Chat } from 'src/app/models/models';
import { Subject, Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit, OnDestroy {
  subs: Subscription[] = [];

  myForm: FormGroup;
  o = new TicketSupport();
  title = '';
  chats: Chat[] = [];
  collaborateurs = this.uow.users.get();


  folderToSaveInServer = 'ticketSupports';

  /*{imagesInit}*/



  constructor(
    // public dialogRef: MatDialogRef<any>, @Inject(MAT_DIALOG_DATA) public data: any
    private route: ActivatedRoute, private fb: FormBuilder
    , private uow: UowService, private router: Router) { }

  ngOnInit() {
    this.createForm();
    const id = +this.route.snapshot.paramMap.get('id');
    if (id !== 0) {
      this.uow.ticketSupports.getOne(id).subscribe(r => {
        this.o = r as TicketSupport;
        console.log(this.o);
        this.title = 'Modifier TicketSupport';
        this.createForm();

        this.uow.chats.getByTicket(id).subscribe(r => {
          this.chats = r as any;
        });
      });
    }
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
