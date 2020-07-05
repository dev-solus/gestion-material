import { Component, OnInit } from '@angular/core';
import { SessionService } from '../shared';
import { Router, RouterOutlet } from '@angular/router';
import { slideInAnimation } from '../shared/animations';
import { MediaService } from '../shared/media.service';
import { ChatHubService } from './chat.hub.service';
import { distinctUntilChanged } from 'rxjs/operators';
import { Chat, User } from '../models/models';
import { ToastrService, IndividualConfig } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { UpdateComponent } from './account/update.component';

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
    , public myMedia: MediaService, private chat: ChatHubService
    , private toastr: ToastrService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.myMedia.windowSizeChanged.subscribe(r => this.isMobileWidth = r.width <= 700);

    this.chat.createConnection().startConnection();

    this.messageInComing();
  }

  messageInComing() {
    this.chat.messageReceived.pipe( /*debounceTime(300),*/distinctUntilChanged()).subscribe(async (r: Chat) => {
      // console.log(r);
      this.toastrChat(r);

    });
  }

  toastrChat(chat: Chat) {
    const conf: Partial<IndividualConfig> = {
      positionClass: 'toast-top-right',
      // positionClass: 'toast-bottom-left',
      closeButton: true,
      disableTimeOut: false,
      tapToDismiss: false,
      enableHtml: true,
      progressBar: true,
      progressAnimation: 'decreasing',
      timeOut: 2500,
      // preventDuplicates: false,
    };

    this.toastr.success(chat.message, chat.senderName, conf).onTap.subscribe(r => {
      this.router.navigate(['admin/ticketSupport/update', chat.idTicketSupport]);
    } )
  }

  disconnect() {
    this.session.doSignOut();
    this.router.navigate(['']);
  }

  get profile() {
    return {
      name: this.session.user.nom + ' ' + this.session.user.prenom,
      role: this.session.isAdmin ? 'Admin' : this.session.isAgentSi ? 'Agent SI' : this.session.isUser ? 'Collaborateur' : 'Financier',
    }
  }

  prepareRoute(outlet: RouterOutlet) {
    return '';
    return outlet && outlet.activatedRouteData && outlet.activatedRouteData['animation'];
  }

  openDialog() {
    const dialogRef = this.dialog.open(UpdateComponent, {
      width: '750px',
      disableClose: true,
      data: { model: this.session.user, title: `` }
    });

    return dialogRef.afterClosed();
  }

}
