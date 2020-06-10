import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Equipement } from 'src/app/models/models';
import { Subject, Subscription } from 'rxjs';
@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit, OnDestroy {
  subs: Subscription[] = [];

  myForm: FormGroup;
  o: Equipement;
  title = '';
  constucteurs = this.uow.constucteurs.get();
categories = this.uow.categories.get();
statuts = this.uow.statuts.get();
fournisseurs = this.uow.fournisseurs.get();


  folderToSaveInServer = 'equipements';

  /*{imagesInit}*/

  

  constructor(public dialogRef: MatDialogRef<any>, @Inject(MAT_DIALOG_DATA) public data: any
    , private fb: FormBuilder, private uow: UowService) { }

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

  onOkClick(o: Equipement): void {
    let sub = null;
    if (o.id === 0) {
      sub = this.uow.equipements.post(o).subscribe(r => {
        
        this.dialogRef.close(o);
      });
    } else {
      sub = this.uow.equipements.put(o.id, o).subscribe(r => {
        
        this.dialogRef.close(o);
      });
    }

    this.subs.push(sub);
  }

  createForm() {
    this.myForm = this.fb.group({
      id: [this.o.id, [Validators.required, ]],
nSerie: [this.o.nSerie, [Validators.required, ]],
model: [this.o.model, [Validators.required, ]],
dateAchat: [this.o.dateAchat, [Validators.required, ]],
refAchat: [this.o.refAchat, [Validators.required, ]],
etatActuel: [this.o.etatActuel, [Validators.required, ]],
prixUnitaireHT: [this.o.prixUnitaireHT, [Validators.required, ]],
nInventaire: [this.o.nInventaire, [Validators.required, ]],
remarques: [this.o.remarques, [Validators.required, ]],
idConstucteur: [this.o.idConstucteur, [Validators.required, ]],
idCategorie: [this.o.idCategorie, [Validators.required, ]],
idStatut: [this.o.idStatut, [Validators.required, ]],
idFournisseur: [this.o.idFournisseur, [Validators.required, ]],

    });
  }

  resetForm() {
    this.o = new Equipement();
    this.createForm();
  }

  ngOnDestroy(): void {
    this.subs.forEach(e => {
      e.unsubscribe();
    });
  }

}
