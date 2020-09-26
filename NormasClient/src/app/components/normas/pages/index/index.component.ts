import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Norma } from '../../models/norma';
import { NormasService } from 'src/app/shared/services/normas.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  listaNormas: Array<Norma> = [];
  codigoNormaExclusao: string;

  constructor(
    private normasService: NormasService,
    private toastrService: ToastrService,
    private modalService: NgbModal
    ) { }

  ngOnInit(): void {
    this.buscarNormas();
  }

  buscarNormas() {
    this.normasService.buscarNormas().pipe(
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

}