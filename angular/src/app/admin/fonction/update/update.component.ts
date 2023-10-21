import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { UntypedFormGroup, UntypedFormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Fonction } from 'src/app/models/models';
import { Subject, Subscription } from 'rxjs';
@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit, OnDestroy {
  subs: Subscription[] = [];

  myForm: UntypedFormGroup;
  o: Fonction;
  title = '';
  

  folderToSaveInServer = 'fonctions';

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

  onOkClick(o: Fonction): void {
    let sub = null;
    if (o.id === 0) {
      sub = this.uow.fonctions.post(o).subscribe(r => {
        
        this.dialogRef.close(o);
      });
    } else {
      sub = this.uow.fonctions.put(o.id, o).subscribe(r => {
        
        this.dialogRef.close(o);
      });
    }

    this.subs.push(sub);
  }

  createForm() {
    this.myForm = this.fb.group({
      id: [this.o.id, [Validators.required, ]],
nom: [this.o.nom, [Validators.required, ]],

    });
  }

  resetForm() {
    this.o = new Fonction();
    this.createForm();
  }

  ngOnDestroy(): void {
    this.subs.forEach(e => {
      e.unsubscribe();
    });
  }

}
