import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../../environments/environment';
import { Norma } from '../../components/normas/models/norma';

@Injectable({ providedIn: 'root' })
export class NormasService {

    constructor(
        private router: Router,
        private http: HttpClient
    ) { }

    buscarNormas(): Observable<Norma[]> {
        return this.http.get(`${environment.apiNormas}/api/normas`)
            .pipe(
                map((norma: Norma[]) => {
                    return norma;
            }));
    }
}
