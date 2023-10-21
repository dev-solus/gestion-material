import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { UntypedFormGroup, UntypedFormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EquipementInfo } from 'src/app/models/models';
import { Subject, Subscription } from 'rxjs';
import { DomSanitizer } from '@angular/platform-browser';
@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit, OnDestroy {
  subs: Subscription[] = [];

  myForm: UntypedFormGroup;
  o: EquipementInfo;
  title = '';


  folderToSaveInServer = 'equipementInfos';

  /*{imagesInit}*/



  constructor(public dialogRef: MatDialogRef<any>, @Inject(MAT_DIALOG_DATA) public data: any
    , private fb: UntypedFormBuilder, private uow: UowService, protected sanitizer: DomSanitizer) { }

  ngOnInit() {
    this.o = this.data.model;
    this.title = this.data.title;
    this.createForm();

    console.log(this.o)
    /*{imagesFrom}*/

    setTimeout(() => {
       /*{imagesTo}*/
    }, 100);
  }

  sanitizeHtml(p: string) {
    return this.sanitizer.bypassSecurityTrustHtml(p ? p : '');
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onOkClick(o: EquipementInfo): void {
    let sub = null;
    if (o.id === 0) {
      sub = this.uow.equipementInfos.post(o).subscribe(r => {

        this.dialogRef.close(o);
      });
    } else {
      sub = this.uow.equipementInfos.put(o.id, o).subscribe(r => {

        this.dialogRef.close(o);
      });
    }

    this.subs.push(sub);
  }

  createForm() {
    this.myForm = this.fb.group({
      id: [this.o.id, [Validators.required, ]],
nSerie: [this.o.nSerie, [Validators.required, ]],
date: [this.o.date, [Validators.required, ]],
stringInfo: [this.o.infoSystemeHtml, [Validators.required, ]],

    });
  }

  resetForm() {
    this.o = new EquipementInfo();
    this.createForm();
  }

  ngOnDestroy(): void {
    this.subs.forEach(e => {
      e.unsubscribe();
    });
  }

}
