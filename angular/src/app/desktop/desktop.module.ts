import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DesktopRoutingModule } from './desktop-routing.module';
import { DesktopComponent } from './desktop.component';
import { MatModule } from '../mat.module';


@NgModule({
  declarations: [DesktopComponent],
  imports: [
    CommonModule,
    DesktopRoutingModule,
    MatModule,
  ]
})
export class DesktopModule { }
