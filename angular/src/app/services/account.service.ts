import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { User } from '../models/models';


@Injectable({
  providedIn: 'root'
})
export class AccountService extends SuperService<User> {

  constructor() {
    super('accounts');
  }

  login(model) {
    return this.http.post(`${this.urlApi}/${this.controller}/login`, model);
  }

  create(returnUrl, model) {
    return this.http.post(`${this.urlApi}/${this.controller}/create/${returnUrl}`, model);
  }

  sendEmailForResetPassword(email, url, lang) {
    return this.http.get(`${this.urlApi}/${this.controller}/sendEmailForResetPassword/${email}/${url}/${lang}`);
  }

  resetPassword(model) {
    return this.http.post(`${this.urlApi}/${this.controller}/resetPassword`, model);
  }

  activeAccount(code) {
    return this.http.get(`${this.urlApi}/${this.controller}/activeAccount/${code}`);
  }

}
