import { Component, OnInit, ViewChild, EventEmitter, Inject, OnDestroy } from '@angular/core';
import { merge, Subscription } from 'rxjs';
import { UpdateComponent } from './update/update.component';
import { UowService } from 'src/app/services/uow.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { DeleteService } from 'src/app/components/delete/delete.service';
import { Equipement } from 'src/app/models/models';
import { ExcelService } from 'src/app/shared/excel.service';
import { UntypedFormControl } from '@angular/forms';
import { startWith } from 'rxjs/operators';

@Component({
  selector: 'app-equipement',
  templateUrl: './equipement.component.html',
  styleUrls: ['./equipement.component.scss']
})
export class EquipementComponent implements OnInit, OnDestroy {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  update = new EventEmitter();
  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;

  subs: Subscription[] = [];

  dataSource: Equipement[] = [];
  selectedList: Equipement[] = [];

  displayedColumns = ['select', 'nSerie', 'model', 'dateAchat', 'refAchat', 'etatActuel', 'prixUnitaireHT', 'nInventaire', 'constucteur', 'categorie', 'statut', 'fournisseur', 'option'];

  panelOpenState = false;

  nSerie = new UntypedFormControl('');
  model = new UntypedFormControl('');
  refAchat = new UntypedFormControl('');
  etatActuel = new UntypedFormControl('');
  prixUnitaireHT = new UntypedFormControl(0);
  nInventaire = new UntypedFormControl('');
  remarques = new UntypedFormControl('');
  idConstucteur = new UntypedFormControl(0);
  idCategorie = new UntypedFormControl(0);
  idStatut = new UntypedFormControl(0);
  idFournisseur = new UntypedFormControl(0);


  constucteurs = this.uow.constucteurs.get();
  categories = this.uow.categories.get();
  statuts = this.uow.statuts.get();
  fournisseurs = this.uow.fournisseurs.get();

  etats = ['STK', 'OPR'];


  constructor(private uow: UowService, public dialog: MatDialog, private excel: ExcelService
    , private mydialog: DeleteService, @Inject('BASE_URL') private url: string) { }

  ngOnInit() {
    const sub = merge(...[this.sort.sortChange, this.paginator.page, this.update]).pipe(startWith(null as any)).subscribe(
      r => {
        r === true ? this.paginator.pageIndex = 0 : r = r;
        !this.paginator.pageSize ? this.paginator.pageSize = 10 : r = r;
        const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
        this.isLoadingResults = true;
        this.getPage(
          startIndex,
          this.paginator.pageSize,
          this.sort.active ? this.sort.active : 'id',
          this.sort.direction ? this.sort.direction : 'desc',
          this.nSerie.value === '' ? '*' : this.nSerie.value,
          this.model.value === '' ? '*' : this.model.value,
          this.refAchat.value === '' ? '*' : this.refAchat.value,
          this.etatActuel.value === '' ? '*' : this.etatActuel.value,
          this.prixUnitaireHT.value === 0 ? 0 : this.prixUnitaireHT.value,
          this.nInventaire.value === '' ? '*' : this.nInventaire.value,
          this.remarques.value === '' ? '*' : this.remarques.value,
          this.idConstucteur.value === 0 ? 0 : this.idConstucteur.value,
          this.idCategorie.value === 0 ? 0 : this.idCategorie.value,
          this.idStatut.value === 0 ? 0 : this.idStatut.value,
          this.idFournisseur.value === 0 ? 0 : this.idFournisseur.value,

        );
      }
    );

    this.subs.push(sub);
  }

  reset() {
    this.nSerie.setValue('');
    this.model.setValue('');
    this.refAchat.setValue('');
    this.etatActuel.setValue('');
    this.prixUnitaireHT.setValue(0);
    this.nInventaire.setValue('');
    this.remarques.setValue('');
    this.idConstucteur.setValue(0);
    this.idCategorie.setValue(0);
    this.idStatut.setValue(0);
    this.idFournisseur.setValue(0);

    this.update.next(true);
  }

  generateExcel() {
    this.excel.json_to_sheet(this.dataSource);
  }

  search() {
    this.update.next(true);
  }

  getPage(startIndex, pageSize, sortBy, sortDir, nSerie, model, refAchat, etatActuel, prixUnitaireHT, nInventaire, remarques, idConstucteur, idCategorie, idStatut, idFournisseur, ) {
    const sub = this.uow.equipements.getAll(startIndex, pageSize, sortBy, sortDir, nSerie, model, refAchat, etatActuel, prixUnitaireHT, nInventaire, remarques, idConstucteur, idCategorie, idStatut, idFournisseur).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
      }
    );

    this.subs.push(sub);
  }

  openDialog(o: Equipement, text) {
    const dialogRef = this.dialog.open(UpdateComponent, {
      width: '750px',
      disableClose: true,
      data: { model: o, title: text }
    });

    return dialogRef.afterClosed();
  }

  add() {
    this.openDialog(new Equipement(), 'Ajouter equipement').subscribe(result => {
      if (result) {
        this.update.next(true);
      }
    });
  }

  edit(o: Equipement) {
    this.openDialog(o, 'Modifier equipement').subscribe((result: Equipement) => {
      if (result) {
        this.update.next(true);
      }
    });
  }

  async delete(id: number) {
    const r = await this.mydialog.openDialog('equipement').toPromise();
    if (r === 'ok') {
      const sub = this.uow.equipements.delete(id).subscribe(() => this.update.next(true));

      this.subs.push(sub);
    }
  }

  displayImage(urlImage: string) {
    if (!urlImage) {
      return 'assets/404.jpg';
    }
    if (urlImage && urlImage.startsWith('http')) {
      return urlImage;
    }

    return `${this.url}/equipements/${urlImage.replace(';', '')}`;
  }

  imgError(img: any) {
    img.src = 'assets/404.jpg';
  }

  //check box
  //
  isSelected(row: Equipement): boolean {
    return this.selectedList.find(e => e.id === row.id) ? true : false;
  }

  check(row: Equipement) {
    const i = this.selectedList.findIndex(o => row.id === o.id);
    const existe: boolean = i !== -1;

    existe ? this.selectedList.splice(i, 1) : this.selectedList.push(row);
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected(): boolean {
    const numSelected = this.selectedList.length;
    const numRows = this.dataSource.length;

    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ? this.selectedList = [] : this.selectedList = Array.from(this.dataSource);
  }

  async deleteList() {
    const r = await this.mydialog.openDialog('role').toPromise();
    if (r === 'ok') {
      const sub = this.uow.equipements.deleteRange(this.selectedList.map(e => e.id) as any).subscribe(() => {
        this.selectedList = [];
        this.update.next(true);
      });

      this.subs.push(sub);
    }
  }

  ngOnDestroy(): void {
    this.subs.forEach(e => {
      e.unsubscribe();
    });
  }

}

