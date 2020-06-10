import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmplacementRoutingModule } from './emplacement-routing.module';
import { EmplacementComponent } from './emplacement.component';
import { HttpClientModule } from '@angular/common/http';
import { MatModule } from 'src/app/mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TitleModule } from '../../components/title/title.module';
import { UpdateComponent } from './update/update.component';
import { ManageFilesModule } from 'src/app/manage-files/manage-files.module';

@NgModule({
  declarations: [EmplacementComponent, UpdateComponent],
  imports: [
    CommonModule,
    EmplacementRoutingModule,
    HttpClientModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
    TitleModule,
    ManageFilesModule,
  ]
})
export class EmplacementModule { }
