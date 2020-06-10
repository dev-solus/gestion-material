import { Component, OnInit, ViewChild, EventEmitter, Inject, OnDestroy } from '@angular/core';
import { merge, Subscription } from 'rxjs';
import { UpdateComponent } from './update/update.component';
import { UowService } from 'src/app/services/uow.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { DeleteService } from 'src/app/components/delete/delete.service';
import { EquipementInfo } from 'src/app/models/models';
import { ExcelService } from 'src/app/shared/excel.service';
import { FormControl } from '@angular/forms';
import { startWith } from 'rxjs/operators';

@Component({
  selector: 'app-equipementInfo',
  templateUrl: './equipementInfo.component.html',
  styleUrls: ['./equipementInfo.component.scss']
})
export class EquipementInfoComponent implements OnInit, OnDestroy {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  update = new EventEmitter();
  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;

  subs: Subscription[] = [];

  dataSource: EquipementInfo[] = [];
  selectedList: EquipementInfo[] = [];

  displayedColumns = ['select',  'nSerie', 'date', 'stringInfo', 'option'];

  panelOpenState = false;

  nSerie = new FormControl('');
stringInfo = new FormControl('');


  

  constructor(private uow: UowService, public dialog: MatDialog, private excel: ExcelService
    , private mydialog: DeleteService, @Inject('BASE_URL') private url: string ) { }

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
this.stringInfo.value === '' ? '*' : this.stringInfo.value,

        );
      }
    );

    this.subs.push(sub);
  }

  reset() {
    this.nSerie.setValue('');
this.stringInfo.setValue('');

    this.update.next(true);
  }

  generateExcel() {
    this.excel.json_to_sheet(this.dataSource);
  }

  search() {
    this.update.next(true);
  }

  getPage(startIndex, pageSize, sortBy, sortDir, nSerie, stringInfo,) {
    const sub = this.uow.equipementInfos.getAll(startIndex, pageSize, sortBy, sortDir,  nSerie, stringInfo,).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
      }
    );

    this.subs.push(sub);
  }

  openDialog(o: EquipementInfo, text) {
    const dialogRef = this.dialog.open(UpdateComponent, {
      width: '750px',
      disableClose: true,
      data: { model: o, title: text }
    });

    return dialogRef.afterClosed();
  }

  add() {
    this.openDialog(new EquipementInfo(), 'Ajouter equipementInfo').subscribe(result => {
      if (result) {
        this.update.next(true);
      }
    });
  }

  edit(o: EquipementInfo) {
    this.openDialog(o, 'Modifier equipementInfo').subscribe((result: EquipementInfo) => {
      if (result) {
        this.update.next(true);
      }
    });
  }

  async delete(id: number) {
    const r = await this.mydialog.openDialog('equipementInfo').toPromise();
    if (r === 'ok') {
      const sub = this.uow.equipementInfos.delete(id).subscribe(() => this.update.next(true));

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

    return `${this.url}/equipementInfos/${urlImage.replace(';', '')}`;
  }

  imgError(img: any) {
    img.src = 'assets/404.jpg';
  }

  //check box
  //
  isSelected(row: EquipementInfo): boolean {
    return this.selectedList.find(e => e.id === row.id) ? true : false;
  }

  check(row: EquipementInfo) {
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
      const sub = this.uow.equipementInfos.deleteRange(this.selectedList).subscribe(() => {
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

