import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { AccountService } from '../shared/services/account.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private accountService: AccountService
    ) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const roles: Array<string> = route.data.roles;
        const user = this.accountService.userValue;
        if (user) {
            if (user.papel.toLowerCase() !== 'analista') {
              if (roles && roles.length > 0)  {
                if (!(roles.find(f => f === user.papel.toLowerCase()))) {
                    this.router.navigate(['/']);
                    return false;
                }
              }
            }

            return true;
        }

        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
        return false;
    }
}