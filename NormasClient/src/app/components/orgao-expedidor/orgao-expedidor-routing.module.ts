import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'src/app/helpers/auth.guard';
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
export class OrgaoExpedidorRoutingModule {}
