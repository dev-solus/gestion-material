import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FonctionRoutingModule } from './fonction-routing.module';
import { FonctionComponent } from './fonction.component';
import { HttpClientModule } from '@angular/common/http';
import { MatModule } from 'src/app/mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TitleModule } from '../../components/title/title.module';
import { UpdateComponent } from './update/update.component';
import { ManageFilesModule } from 'src/app/manage-files/manage-files.module';

@NgModule({
  declarations: [FonctionComponent, UpdateComponent],
  imports: [
    CommonModule,
    FonctionRoutingModule,
    HttpClientModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
    TitleModule,
    ManageFilesModule,
  ]
})
export class FonctionModule { }
