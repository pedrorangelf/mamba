import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ProcessoPageRoutingModule } from './processo-routing.module';

import { ProcessoPage } from './processo.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ProcessoPageRoutingModule
  ],
  declarations: [ProcessoPage]
})
export class ProcessoPageModule {}
