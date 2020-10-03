import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Norma } from '../../models/norma';
import { FiltroNormas } from '../../models/filtro-normas';
import { User } from 'src/app/shared/models/user';
import { OrgaoExpedidor } from 'src/app/shared/models/orgaoExpedidor';
import { TipoDocumento } from 'src/app/shared/models/tipoDocumento';

import { NormasService } from 'src/app/shared/services/normas.service';
import { AccountService } from 'src/app/shared/services/account.service';
import { OrgaoExpedidorService } from 'src/app/shared/services/orgao-expedidor.service';
import { TipoDocumentoService } from 'src/app/shared/services/tipo-documento.service';


@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  usuario: User;
  listaNormas: Array<Norma> = [];
  listaOrgaosExpedidores: OrgaoExpedidor[] = null;
  listaTiposDocumento: TipoDocumento[] = null;
  codigoNormaExclusao: string;

  formGroup = this.fb.group({
    codigoNorma: [null],
    descricao: [null],
    tipoDocumento: [null],
    orgaoExpedidor: [null],
    dataPublicacao: [null]
  });

  constructor(
    private normasService: NormasService,
    private fb: FormBuilder,
    private toastrService: ToastrService,
    private modalService: NgbModal,
    private accountService: AccountService,
    private orgaoExpedidorService: OrgaoExpedidorService,
    private tipoDocumentoService: TipoDocumentoService
    ) { }

  ngOnInit(): void {
    this.usuario = this.accountService.userValue;
    this.buscarOrgaosExpedidores();
    this.buscarTiposDocumento();
    this.buscarNormas();
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

  buscarNormas() {
    this.listaNormas = [];

    const filtroNormas: FiltroNormas = {
      codigoNorma: this.formGroup.get('codigoNorma').value,
      orgaoExpedidor: this.formGroup.get('orgaoExpedidor').value,
      tipoDocumento: this.formGroup.get('tipoDocumento').value,
      dataPublicacao: this.formGroup.get('dataPublicacao').value
    };

    this.normasService.buscarNormas(filtroNormas).pipe(
      catchError((error) => {
        this.toastrService.error(error);
        return throwError(error);
      })
    ).subscribe((listaNormas: Norma[]) => {
      this.listaNormas = listaNormas;
    });
  }

  excluirNorma(idNorma: number) {
    this.normasService.excluirNorma(idNorma).pipe(
      catchError((error) => {
        this.toastrService.error('Ocorreu um erro ao excluir a norma!');
        return throwError(error);
      })
    ).subscribe((norma: Norma) => {
      this.toastrService.success(`Norma ${norma.codigoNorma} excluída com sucesso!`);
      this.buscarNormas();
    });
  }

  abrirModalExclusaoNorma(conteudo, idNorma: number, codigoNorma: string) {
    this.codigoNormaExclusao = codigoNorma;
    this.modalService.open(conteudo).result.then((excluirNorma) => {
      if (excluirNorma) {
        this.excluirNorma(idNorma);
      }
    });
  }

  buscarArquivoPorId(idNorma) {
    this.normasService.buscarArquivoPorId(idNorma).pipe(
      catchError((error) => {
        this.toastrService.error(error);
        return throwError(error);
      })
    ).subscribe((arquivo: any) => {
      const file = new Blob([arquivo], {type: 'application/pdf'});
      const fileURL = URL.createObjectURL(file);
      window.open(fileURL, '_blank');
    });
  }

  ehAnalista(): boolean {
    return this.usuario.papel === 'Analista';
  }

}
