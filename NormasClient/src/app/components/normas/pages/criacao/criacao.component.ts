import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

import { OrgaoExpedidor } from 'src/app/shared/models/orgaoExpedidor';
import { TipoDocumento } from 'src/app/shared/models/tipoDocumento';
import { OrgaoExpedidorService } from 'src/app/shared/services/orgao-expedidor.service';
import { TipoDocumentoService } from 'src/app/shared/services/tipo-documento.service';
import { NormasService } from 'src/app/shared/services/normas.service';
import { Norma } from '../../models/norma';

@Component({
  selector: 'app-criacao',
  templateUrl: './criacao.component.html',
  styleUrls: ['./criacao.component.css']
})
export class CriacaoComponent implements OnInit {

  listaOrgaosExpedidores: OrgaoExpedidor[] = null;
  listaTiposDocumento: TipoDocumento[] = null;

  submitted = false;
  arquivoNorma: File = null;

  formGroup = this.fb.group({
    codigoNorma: [null, Validators.required],
    descricao: [null, Validators.required],
    tipoDocumento: [null, Validators.required],
    orgaoExpedidor: [null, Validators.required],
    dataPublicacao: [null, Validators.required],
    resumo: [null, Validators.maxLength(250)],
    observacao: [null, Validators.maxLength(250)],
    arquivoNorma: [null, Validators.required]
  });

  constructor(private router: Router,
              private fb: FormBuilder,
              private toastrService: ToastrService,
              private normasService: NormasService,
              private orgaoExpedidorService: OrgaoExpedidorService,
              private tipoDocumentoService: TipoDocumentoService) { }

  ngOnInit(): void {
    this.buscarOrgaosExpedidores();
    this.buscarTiposDocumento();
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

  gravarNorma() {
    this.submitted = true;

    if (this.formGroup.invalid) {
      this.toastrService.error('Não foi possível realizar a inserção da norma! Realize as correções necessárias informadas nos campos do formulário.');
      return;
    }

    const formData = new FormData();
    formData.append('CodigoNorma', this.formGroup.get('codigoNorma').value);
    formData.append('Descricao', this.formGroup.get('descricao').value);
    formData.append('TipoDocumento', this.formGroup.get('tipoDocumento').value);
    formData.append('OrgaoExpedidor', this.formGroup.get('orgaoExpedidor').value);
    formData.append('DataPublicacao', this.formGroup.get('dataPublicacao').value);
    formData.append('Resumo', this.formGroup.get('resumo').value);
    formData.append('Observacao', this.formGroup.get('observacao').value);
    formData.append('ArquivoNorma', this.formGroup.get('arquivoNorma').value);

    this.normasService.gravarNorma(formData).pipe(
      catchError((error) => {
        this.toastrService.error('Ocorreu um erro na gravação da norma!');
        return throwError(error);
      })
    ).subscribe((norma: Norma) => {
      this.toastrService.success('Norma inserida com sucesso!');
      this.voltar();
    });
  }

  voltar(): void {
    this.router.navigateByUrl('/normas');
  }
}
