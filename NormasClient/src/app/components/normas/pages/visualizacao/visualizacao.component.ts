import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { OrgaoExpedidor } from 'src/app/shared/models/orgaoExpedidor';
import { TipoDocumento } from 'src/app/shared/models/tipoDocumento';
import { NormasService } from 'src/app/shared/services/normas.service';
import { OrgaoExpedidorService } from 'src/app/shared/services/orgao-expedidor.service';
import { TipoDocumentoService } from 'src/app/shared/services/tipo-documento.service';
import { Norma } from '../../models/norma';

@Component({
  selector: 'app-visualizacao',
  templateUrl: './visualizacao.component.html',
  styleUrls: ['./visualizacao.component.css']
})
export class VisualizacaoComponent implements OnInit {

  idNorma: number;
  listaOrgaosExpedidores: OrgaoExpedidor[] = null;
  listaTiposDocumento: TipoDocumento[] = null;

  formGroup = this.fb.group({
    id: [null],
    codigoNorma: [null],
    descricao: [null],
    tipoDocumento: [null],
    orgaoExpedidor: [null],
    dataPublicacao: [null],
    resumo: [null],
    observacao: [null],
    arquivoNorma: [null]
  });

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private toastrService: ToastrService,
    private normasService: NormasService,
    private orgaoExpedidorService: OrgaoExpedidorService,
    private tipoDocumentoService: TipoDocumentoService
    ) { }

  ngOnInit(): void {
    this.idNorma = this.route.snapshot.params.id;
    this.buscarOrgaosExpedidores();
    this.buscarTiposDocumento();
    this.buscarNormaPorId(this.idNorma);
  }

  get f() { return this.formGroup.controls; }

  buscarTiposDocumento(): void {
    this.tipoDocumentoService.buscarTiposDocumento().pipe(
      catchError((error) => {
        this.toastrService.error(error);
        return throwError(error);
      })
    ).subscribe((listaTiposDocumento: TipoDocumento[]) => {
      this.listaTiposDocumento = listaTiposDocumento;
    });
  }

  buscarOrgaosExpedidores(): void {
    this.orgaoExpedidorService.buscarOrgaosExpedidores().pipe(
      catchError((error) => {
        this.toastrService.error(error);
        return throwError(error);
      })
    ).subscribe((listaOrgaosExpedidores: TipoDocumento[]) => {
      this.listaOrgaosExpedidores = listaOrgaosExpedidores;
    });
  }

  buscarNormaPorId(idNorma: number) {
    this.normasService.buscarNormaPorId(idNorma).pipe(
      catchError((error) => {
        this.toastrService.error(error);
        return throwError(error);
      })
    ).subscribe((norma: Norma) => {
      this.formGroup.setValue({
        id: norma.id,
        codigoNorma: norma.codigoNorma,
        descricao: norma.descricao,
        tipoDocumento: norma.tipoDocumento.id,
        orgaoExpedidor: norma.orgaoExpedidor.id,
        dataPublicacao: new Date(norma.dataPublicacao).toISOString().substring(0, 10),
        resumo: norma.resumo,
        observacao: norma.observacao,
        arquivoNorma: norma.localArquivoNormas
      });
    });
  }

  voltar(): void {
    this.router.navigateByUrl('/normas');
  }
}
