import { Component, OnInit, Inject } from '@angular/core';

@Component({
  selector: 'app-desktop',
  templateUrl: './desktop.component.html',
  styleUrls: ['./desktop.component.scss']
})
export class DesktopComponent implements OnInit {

  constructor(@Inject('BASE_URL') private url: string) { }

  ngOnInit(): void {
  }

  download() {
    const appname = 'sys-info.exe';
    const url = `${this.url}/download/${appname}`;
    window.open(url);
  }

}
