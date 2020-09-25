import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-criacao',
  templateUrl: './criacao.component.html',
  styleUrls: ['./criacao.component.css']
})
export class CriacaoComponent implements OnInit {

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
              private fb: FormBuilder) { }

  ngOnInit(): void {
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

  voltar(): void {
    this.router.navigateByUrl('/normas');
  }
}