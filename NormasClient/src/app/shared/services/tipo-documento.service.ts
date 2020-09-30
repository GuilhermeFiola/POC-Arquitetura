import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../../environments/environment';
import { TipoDocumento } from '../../shared/models/tipoDocumento';

@Injectable({ providedIn: 'root' })
export class TipoDocumentoService {

    constructor(
        private http: HttpClient
    ) { }

    buscarTiposDocumento(): Observable<TipoDocumento[]> {
        return this.http.get(`${environment.apiUrl}/tipodocumento`)
            .pipe(
                map((tipoDocumento: TipoDocumento[]) => {
                    return tipoDocumento;
            }));
    }

    buscarTipoDocumentoPorId(idTipoDocumento: number): Observable<TipoDocumento> {
        return this.http.get(`${environment.apiUrl}/tipodocumento/` + idTipoDocumento)
            .pipe(
                map((tipoDocumento: TipoDocumento) => {
                    return tipoDocumento;
            }));
    }
}
