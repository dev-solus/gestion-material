import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TicketSupportRoutingModule } from './ticketSupport-routing.module';
import { TicketSupportComponent } from './ticketSupport.component';
import { HttpClientModule } from '@angular/common/http';
import { MatModule } from 'src/app/mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TitleModule } from '../../components/title/title.module';
import { UpdateComponent } from './update/update.component';
import { ManageFilesModule } from 'src/app/manage-files/manage-files.module';

@NgModule({
  declarations: [TicketSupportComponent, UpdateComponent],
  imports: [
    CommonModule,
    TicketSupportRoutingModule,
    HttpClientModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
    TitleModule,
    ManageFilesModule,
  ]
})
export class TicketSupportModule { }
