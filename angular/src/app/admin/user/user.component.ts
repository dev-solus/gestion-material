import { Component, OnInit, ViewChild, EventEmitter, Inject, OnDestroy } from '@angular/core';
import { merge, Subscription } from 'rxjs';
import { UpdateComponent } from './update/update.component';
import { UowService } from 'src/app/services/uow.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { DeleteService } from 'src/app/components/delete/delete.service';
import { User } from 'src/app/models/models';
import { ExcelService } from 'src/app/shared/excel.service';
import { FormControl } from '@angular/forms';
import { startWith } from 'rxjs/operators';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit, OnDestroy {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  update = new EventEmitter();
  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;

  subs: Subscription[] = [];

  dataSource: User[] = [];
  selectedList: User[] = [];

  displayedColumns = ['select', 'nom', 'matricule', 'prenom', 'email', 'emailVerified', 'isActive', 'service', 'fonction', 'role', 'option'];

  panelOpenState = false;

  nom = new FormControl('');
  matricule = new FormControl('');
  prenom = new FormControl('');
  email = new FormControl('');
  codeOfVerification = new FormControl('');
  idService = new FormControl(0);
  idFonction = new FormControl(0);
  idRole = new FormControl(0);


  services = this.uow.services.get();
  fonctions = this.uow.fonctions.get();
  roles = this.uow.roles.get();


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
          this.nom.value === '' ? '*' : this.nom.value,
          this.matricule.value === '' ? '*' : this.matricule.value,
          this.prenom.value === '' ? '*' : this.prenom.value,
          this.email.value === '' ? '*' : this.email.value,
          this.codeOfVerification.value === '' ? '*' : this.codeOfVerification.value,
          this.idService.value === 0 ? 0 : this.idService.value,
          this.idFonction.value === 0 ? 0 : this.idFonction.value,
          this.idRole.value === 0 ? 0 : this.idRole.value,

        );
      }
    );

    this.subs.push(sub);
  }

  reset() {
    this.nom.setValue('');
    this.matricule.setValue('');
    this.prenom.setValue('');
    this.email.setValue('');
    this.codeOfVerification.setValue('');
    this.idService.setValue(0);
    this.idFonction.setValue(0);
    this.idRole.setValue(0);

    this.update.next(true);
  }

  generateExcel() {
    this.excel.json_to_sheet(this.dataSource);
  }

  search() {
    this.update.next(true);
  }

  getPage(startIndex, pageSize, sortBy, sortDir, nom, matricule, prenom, email, codeOfVerification, idService, idFonction, idRole,) {
    const sub = this.uow.users.getAll(startIndex, pageSize, sortBy, sortDir, nom, matricule, prenom, email, codeOfVerification, idService, idFonction, idRole,).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
      }
    );

    this.subs.push(sub);
  }

  openDialog(o: User, text) {
    const dialogRef = this.dialog.open(UpdateComponent, {
      width: '750px',
      disableClose: true,
      data: { model: o, title: text }
    });

    return dialogRef.afterClosed();
  }

  add() {
    this.openDialog(new User(), 'Ajouter user').subscribe(result => {
      if (result) {
        this.update.next(true);
      }
    });
  }

  edit(o: User) {
    this.openDialog(o, 'Modifier user').subscribe((result: User) => {
      if (result) {
        this.update.next(true);
      }
    });
  }

  async delete(id: number) {
    const r = await this.mydialog.openDialog('user').toPromise();
    if (r === 'ok') {
      const sub = this.uow.users.delete(id).subscribe(() => this.update.next(true));

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

    return `${this.url}/users/${urlImage.replace(';', '')}`;
  }

  imgError(img: any) {
    img.src = 'assets/404.jpg';
  }

  //check box
  //
  isSelected(row: User): boolean {
    return this.selectedList.find(e => e.id === row.id) ? true : false;
  }

  check(row: User) {
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
      const sub = this.uow.users.deleteRange(this.selectedList.map(e => e.id) as any).subscribe(() => {
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

