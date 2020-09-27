import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './pages/index/index.component';

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
        path: '**',
        redirectTo: 'Index',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
    declarations: [],
})
export class TipoDocumentoRoutingModule {}
