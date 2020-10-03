import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../../environments/environment';
import { Norma } from '../../components/normas/models/norma';
import { FiltroNormas } from 'src/app/components/normas/models/filtro-normas';

@Injectable({ providedIn: 'root' })
export class NormasService {

    constructor(
        private router: Router,
        private http: HttpClient
    ) { }

    buscarNormas(filtroNormas: FiltroNormas): Observable<Norma[]> {
        const data: any = { };
        if (filtroNormas.codigoNorma) { data.CodigoNorma = filtroNormas.codigoNorma; }
        if (filtroNormas.tipoDocumento) { data.TipoDocumento = filtroNormas.tipoDocumento; }
        if (filtroNormas.orgaoExpedidor) { data.OrgaoExpedidor = filtroNormas.orgaoExpedidor; }
        if (filtroNormas.dataPublicacao) { data.DataPublicacao = filtroNormas.dataPublicacao; }

        return this.http.get(`${environment.apiUrl}/normas`, {params: data})
            .pipe(
                map((norma: Norma[]) => {
                    return norma;
            }));
    }

    buscarNormaPorId(idNorma: number): Observable<Norma> {
        return this.http.get(`${environment.apiUrl}/normas/${idNorma}`)
            .pipe(
                map((norma: Norma) => {
                    return norma;
            }));
    }

    buscarArquivoPorId(idNorma: number): Observable<any> {
        return this.http.get(`${environment.apiUrl}/normas/${idNorma}/arquivo`, { headers: new HttpHeaders( {'Content-Type': 'application/octet-stream' }), responseType: 'blob'})
            .pipe(
                map((arquivo) => {
                    return arquivo;
            }));
    }

    gravarNorma(novaNorma: FormData): Observable<Norma> {
        return this.http.post(`${environment.apiUrl}/normas`, novaNorma)
            .pipe(
                map((norma: Norma) => {
                    return norma;
            }));
    }

    atualizarNorma(atualizacaoNorma: FormData): Observable<Norma> {
        return this.http.put(`${environment.apiUrl}/normas`, atualizacaoNorma)
            .pipe(
                map((norma: Norma) => {
                    return norma;
            }));
    }

    excluirNorma(idNorma: number): Observable<Norma> {
        return this.http.delete(`${environment.apiUrl}/normas/${idNorma}`)
            .pipe(
                map((norma: Norma) => {
                    return norma;
            }));
    }
}
