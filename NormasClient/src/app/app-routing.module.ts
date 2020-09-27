import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from '../app/helpers/auth.guard';
import { LoginComponent } from './components/account/login.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'normas', loadChildren: () => import('./components/normas/normas.module').then(m => m.NormasModule)},
    { path: 'orgaoexpedidor', loadChildren: () => import('./components/orgao-expedidor/orgao-expedidor.module').then(m => m.OrgaoExpedidorModule)},
    { path: 'tipodocumento', loadChildren: () => import('./components/tipo-documento/tipo-documento.module').then(m => m.TipoDocumentoModule)},
    { path: 'login', component: LoginComponent },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
