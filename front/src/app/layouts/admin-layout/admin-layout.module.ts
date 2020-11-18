import { DesafioService } from './../../services/desafio.service';
import { DesafioComponent } from '../../pages/desafio/desafio.component';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ClipboardModule } from 'ngx-clipboard';

import { AdminLayoutRoutes } from './admin-layout.routing';
import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CargoService } from 'src/app/services/cargo.service';
import { CandidatoService } from 'src/app/services/candidato.service';
import { VagaComponent } from 'src/app/pages/vaga/vaga.component';
import { RespostaComponent } from 'src/app/pages/resposta/resposta.component';
import { InscricaoService } from 'src/app/services/inscricao.service';
import { AvaliacaoComponent } from 'src/app/pages/avaliacao/avaliacao.component';
import { AvaliacaoService } from 'src/app/services/avaliacao.service';
// import { ToastrModule } from 'ngx-toastr';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    HttpClientModule,
    NgbModule,
    ClipboardModule,
    ReactiveFormsModule
  ],
  declarations: [
    DashboardComponent,
    UserProfileComponent,
    TablesComponent,
    IconsComponent,
    MapsComponent,
    DesafioComponent,
    VagaComponent,
    RespostaComponent,
    AvaliacaoComponent
  ],
  providers: [
    DesafioService,
    CargoService,
    CandidatoService,
    InscricaoService,
    AvaliacaoService
  ]
})

export class AdminLayoutModule {}
