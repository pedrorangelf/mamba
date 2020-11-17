import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProcessoPage } from './processo.page';

const routes: Routes = [
  {
    path: '',
    component: ProcessoPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProcessoPageRoutingModule {}
