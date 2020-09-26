import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../../environments/environment';
import { OrgaoExpedidor } from '../../shared/models/orgaoExpedidor';

@Injectable({ providedIn: 'root' })
export class OrgaoExpedidorService {

    constructor(
        private http: HttpClient
    ) { }

    buscarOrgaosExpedidores(): Observable<OrgaoExpedidor[]> {
        return this.http.get(`${environment.apiNormas}/api/orgaoExpedidor`)
            .pipe(
                map((orgaoExpedidor: OrgaoExpedidor[]) => {
                    return orgaoExpedidor;
            }));
    }

    buscarOrgaoExpedidorPorId(idOrgaoExpedidor: number): Observable<OrgaoExpedidor> {
        return this.http.get(`${environment.apiNormas}/api/orgaoExpedidor/` + idOrgaoExpedidor)
            .pipe(
                map((orgaoExpedidor: OrgaoExpedidor) => {
                    return orgaoExpedidor;
            }));
    }
}
