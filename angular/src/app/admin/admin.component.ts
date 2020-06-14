import { Component, OnInit } from '@angular/core';
import { SessionService } from '../shared';
import { Router, RouterOutlet } from '@angular/router';
import { slideInAnimation } from '../shared/animations';
import { MediaService } from '../shared/media.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
  animations: [slideInAnimation],
})
export class AdminComponent implements OnInit {
  panelOpenState = false;
  isMobileWidth = false;
  constructor(public session: SessionService, private router: Router
    , public myMedia: MediaService) { }

  ngOnInit(): void {
    this.myMedia.windowSizeChanged.subscribe(r => this.isMobileWidth = r.width <= 700);
  }

  disconnect() {
    this.session.doSignOut();
    this.router.navigate(['']);
  }

  prepareRoute(outlet: RouterOutlet) {
    return '';
    return outlet && outlet.activatedRouteData && outlet.activatedRouteData['animation'];
  }

}
