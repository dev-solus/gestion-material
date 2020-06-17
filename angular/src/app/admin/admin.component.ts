import { Component, OnInit } from '@angular/core';
import { SessionService } from '../shared';
import { Router, RouterOutlet } from '@angular/router';
import { slideInAnimation } from '../shared/animations';
import { MediaService } from '../shared/media.service';
import { ChatHubService } from './chat.hub.service';
import { distinctUntilChanged } from 'rxjs/operators';
import { Chat } from '../models/models';

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
    , public myMedia: MediaService, private chat: ChatHubService) { }

  ngOnInit(): void {
    this.myMedia.windowSizeChanged.subscribe(r => this.isMobileWidth = r.width <= 700);

    this.chat.createConnection().startConnection();

    this.messageInComing();
  }

  messageInComing() {
    this.chat.messageReceived.pipe( /*debounceTime(300),*/distinctUntilChanged()).subscribe(async (r: Chat) => {
      console.log(r);
    });
  }

  disconnect() {
    this.session.doSignOut();
    this.router.navigate(['']);
  }

  get profile() {
    return {
      name: this.session.user.nom + ' ' + this.session.user.prenom,
      role: this.session.isAdmin ? 'Admin' : this.session.isAgentSi ? 'Agent SI' : 'Collaborateur',
    }
  }

  prepareRoute(outlet: RouterOutlet) {
    return '';
    return outlet && outlet.activatedRouteData && outlet.activatedRouteData['animation'];
  }

}
