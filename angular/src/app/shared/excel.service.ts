import { Injectable, ElementRef } from '@angular/core';
import * as XLSX from 'xlsx';
// import { saveAs, FileSaverOptions } from 'file-saver';

@Injectable({
  providedIn: 'root'
})
export class ExcelService {

  constructor() { }

  // private saveAsExcelFile(buffer: any, fileName: string): void {
  //   const data: Blob = new Blob([buffer], { type: EXCEL_TYPE });
  //   saveAs(data, fileName + '_export_' + new Date().getTime() + EXCEL_EXTENSION);
  // }

  table_to_sheet(table: ElementRef) {
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(table.nativeElement);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, `sheet_${new Date().toISOString()}.xlsx`);
  }

  json_to_sheet(data: any[]) {
    const ws: XLSX.WorkSheet = XLSX.utils.json_to_sheet(data);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, `sheet_${new Date().toISOString()}.xlsx`);
  }



  // test106(datasource: { libelle: string, articles: Article[] }[], excelFileName = 'somename') {
  //   const sheetNames: string[] = datasource.map(e => e.libelle);

  //   const sheets: { [sheet: string]: XLSX.WorkSheet } = {};

  //   datasource.map((e, i) => {
  //     sheets[e.libelle] = XLSX.utils.json_to_sheet(e.articles);
  //   });

  //   const workbook: XLSX.WorkBook = {
  //     SheetNames: sheetNames, // <-- include the sheet names in the array
  //     Sheets: sheets
  //   };

  //   const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
  //   // return
  //   this.saveAsExcelFile(excelBuffer, excelFileName);
  // }



}
