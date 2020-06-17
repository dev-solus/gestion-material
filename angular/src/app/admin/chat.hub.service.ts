import { Injectable, Inject } from '@angular/core';
import { HubConnectionBuilder, HubConnection, IHttpConnectionOptions, LogLevel } from '@microsoft/signalr';
import { Subject } from 'rxjs';
import { Chat } from '../Models/models';
import { SessionService } from '../shared';

@Injectable({
  providedIn: 'root'
})
export class ChatHubService {
  messageReceived = new Subject<Chat>();
  updateNotifFromChatComponent = new Subject <number>();
  notificationReceived = new Subject<any>();

  private hubConnection: HubConnection;

  constructor(@Inject('BASE_URL') protected url: string, private session: SessionService) { }


  public createConnection() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.url + '/ChatHub', { accessTokenFactory: () => this.session.token } as IHttpConnectionOptions)
      .withAutomaticReconnect([0, 2000, 10000, 30000, null])
      .configureLogging(LogLevel.Information)
      .build();

    return this;
  }

  public startConnection(): void {
    this.hubConnection.start().then(async (r) => {
      console.log('Hub connection started');

      this.hubConnection.on('receiveMessage', res => this.messageReceived.next(res));

      this.hubConnection.on('notification', res => this.notificationReceived.next(res));

      this.hubConnection.on('innerException', res => {
        console.warn('##################################################################');
        console.warn(res);
        console.warn('##################################################################');
      });

    }).catch(e => {
      console.warn('Error while establishing connection signalr : ', e);
    });
  }

}
