import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { UntypedFormGroup, UntypedFormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Affectation } from 'src/app/models/models';
import { Subject, Subscription } from 'rxjs';
@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit, OnDestroy {
  subs: Subscription[] = [];

  myForm: UntypedFormGroup;
  o: Affectation;
  title = '';
  equipements = this.uow.equipements.get();
  emplacements = this.uow.emplacements.get();
  collaborateurs = [];
  agentSis = [];


  folderToSaveInServer = 'affectations';

  /*{imagesInit}*/



  constructor(public dialogRef: MatDialogRef<any>, @Inject(MAT_DIALOG_DATA) public data: any
    , private fb: UntypedFormBuilder, private uow: UowService) { }

  ngOnInit() {
    this.uow.users.get().subscribe(r => {
      this.collaborateurs = r.filter(e => e.idRole === 3);
      this.agentSis = r.filter(e => e.idRole === 2);
    });
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

  onOkClick(o: Affectation): void {
    let sub = null;
    if (o.id === 0) {
      sub = this.uow.affectations.post(o).subscribe(r => {

        this.dialogRef.close(o);
      });
    } else {
      sub = this.uow.affectations.put(o.id, o).subscribe(r => {

        this.dialogRef.close(o);
      });
    }

    this.subs.push(sub);
  }

  createForm() {
    this.myForm = this.fb.group({
      id: [this.o.id, [Validators.required,]],
      action: [this.o.action, [Validators.required,]],
      date: [this.o.date, [Validators.required,]],
      idEquipement: [this.o.idEquipement, [Validators.required,]],
      idEmplacement: [this.o.idEmplacement, [Validators.required,]],
      idCollaborateur: [this.o.idCollaborateur, [Validators.required,]],
      idAgentSi: [this.o.idAgentSi, [Validators.required,]],

    });
  }

  resetForm() {
    this.o = new Affectation();
    this.createForm();
  }

  ngOnDestroy(): void {
    this.subs.forEach(e => {
      e.unsubscribe();
    });
  }

}
