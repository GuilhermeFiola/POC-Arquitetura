import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
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
    },
    {
        path: 'Criacao',
        component: CriacaoComponent,
    },
    {
        path: 'Atualizacao/:id',
        component: AtualizacaoComponent,
    },
    {
        path: 'Visualizacao/:id',
        component: VisualizacaoComponent,
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
