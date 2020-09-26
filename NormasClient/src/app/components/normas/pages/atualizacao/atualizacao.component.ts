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
  selector: 'app-atualizacao',
  templateUrl: './atualizacao.component.html',
  styleUrls: ['./atualizacao.component.css']
})
export class AtualizacaoComponent implements OnInit {

  idNorma: number;
  normaExterna: string;
  submitted: boolean;
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
      this.normaExterna = norma.externa;
    });
  }

  selecionarArquivo(event): void {
    const arquivo = event.target.files[0];

    if (arquivo) {
      this.formGroup.patchValue({
        arquivoNorma: arquivo
      });

      if (event.target.nextElementSibling !== null){
          event.target.nextElementSibling.innerText = arquivo.name;
      }
    }
  }

  atualizarNorma() {
    this.submitted = true;

    if (this.formGroup.invalid) {
      this.toastrService.error('Não foi possível realizar a inserção da norma! Realize as correções necessárias informadas nos campos do formulário.');
      return;
    }

    const formData = new FormData();
    formData.append('Id', this.formGroup.get('id').value);
    formData.append('CodigoNorma', this.formGroup.get('codigoNorma').value);
    formData.append('Descricao', this.formGroup.get('descricao').value);
    formData.append('TipoDocumento', this.formGroup.get('tipoDocumento').value);
    formData.append('OrgaoExpedidor', this.formGroup.get('orgaoExpedidor').value);
    formData.append('DataPublicacao', this.formGroup.get('dataPublicacao').value);
    formData.append('Resumo', this.formGroup.get('resumo').value);
    formData.append('Observacao', this.formGroup.get('observacao').value);

    if (this.normaExterna === 'N') {
      formData.append('ArquivoNorma', this.formGroup.get('arquivoNorma').value);
    }

    this.normasService.atualizarNorma(formData).pipe(
      catchError((error) => {
        this.toastrService.error('Ocorreu um erro na atualização da norma!');
        return throwError(error);
      })
    ).subscribe((norma: Norma) => {
      this.toastrService.success('Norma atualizada com sucesso!');
      this.voltar();
    });
  }

  voltar(): void {
    this.router.navigateByUrl('/normas');
  }

}
