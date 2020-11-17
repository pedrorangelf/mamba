import { DesafioComponent } from '../../pages/desafio/desafio.component';
import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { VagaComponent } from 'src/app/pages/vaga/vaga.component';
import { RespostaComponent } from 'src/app/pages/resposta/resposta.component';
import { AvaliacaoComponent } from 'src/app/pages/avaliacao/avaliacao.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'user-profile',   component: UserProfileComponent },
    { path: 'desafio',        component: DesafioComponent },
    { path: 'desafio/:id',    component: DesafioComponent },
    { path: 'tables',         component: TablesComponent },
    { path: 'icons',          component: IconsComponent },
    { path: 'maps',           component: MapsComponent },
    { path: 'vaga/:id',       component: VagaComponent },
    { path: 'resposta/:id',   component: RespostaComponent},
    { path: 'avaliacao/:id',  component: AvaliacaoComponent}
];
