import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'src/app/helpers/auth.guard';
import { AtualizacaoComponent } from './pages/atualizacao/atualizacao.component';
import { CriacaoComponent } from './pages/criacao/criacao.component';
import { IndexComponent } from './pages/index/index.component';
import { VisualizacaoComponent } from './pages/visualizacao/visualizacao.component';

const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        redirectTo: 'Index',
    },
    {
        path: 'Index',
        component: IndexComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'Criacao',
        component: CriacaoComponent,
        canActivate: [AuthGuard],
        data: {roles: ['analista']}
    },
    {
        path: 'Atualizacao/:id',
        component: AtualizacaoComponent,
        canActivate: [AuthGuard],
        data: {roles: ['analista']}
    },
    {
        path: 'Visualizacao/:id',
        component: VisualizacaoComponent,
        canActivate: [AuthGuard]
    },
    {
        path: '**',
        redirectTo: 'Index',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
    declarations: [],
})
export class NormasRoutingModule {}
