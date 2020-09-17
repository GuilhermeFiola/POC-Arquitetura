import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// import { HomeComponent } from './home';
import { AuthGuard } from '../app/helpers/auth.guard';
import { LoginComponent } from './components/account/login.component';

// const usersModule = () => import('./users/users.module').then(x => x.UsersModule);

const routes: Routes = [
    // { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    // { path: 'users', loadChildren: usersModule, canActivate: [AuthGuard] },
    //{ path: 'account', loadChildren: accountModule },
    { path: 'login', component: LoginComponent },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
