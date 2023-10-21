import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { UntypedFormGroup, UntypedFormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Chat } from 'src/app/models/models';
import { Subject, Subscription } from 'rxjs';
@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit, OnDestroy {
  subs: Subscription[] = [];

  myForm: UntypedFormGroup;
  o: Chat;
  title = '';
  senders = this.uow.users.get();
receivers = this.uow.users.get();
ticketSupports = this.uow.ticketSupports.get();


  folderToSaveInServer = 'chats';

  /*{imagesInit}*/



  constructor(public dialogRef: MatDialogRef<any>, @Inject(MAT_DIALOG_DATA) public data: any
    , private fb: UntypedFormBuilder, private uow: UowService) { }

  ngOnInit() {
    this.o = this.data.model;
    this.title = this.data.title;
    this.createForm();
    /*{imagesFrom}*/

    setTimeout(() => {
       /*{imagesTo}*/
    }, 100);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onOkClick(o: Chat): void {
    let sub = null;
    if (o.id === 0) {
      sub = this.uow.chats.post(o).subscribe(r => {

        this.dialogRef.close(o);
      });
    } else {
      sub = this.uow.chats.put(o.id, o).subscribe(r => {

        this.dialogRef.close(o);
      });
    }

    this.subs.push(sub);
  }

  createForm() {
    this.myForm = this.fb.group({
      id: [this.o.id, [Validators.required, ]],
idSender: [this.o.idSender, [Validators.required, ]],
idCollaboratteur: [this.o.idCollaboratteur, [Validators.required, ]],
message: [this.o.message, [Validators.required, ]],
vu: [this.o.vu, [Validators.required, ]],
date: [this.o.date, [Validators.required, ]],
idTicketSupport: [this.o.idTicketSupport, [Validators.required, ]],

    });
  }

  resetForm() {
    this.o = new Chat();
    this.createForm();
  }

  ngOnDestroy(): void {
    this.subs.forEach(e => {
      e.unsubscribe();
    });
  }

}
