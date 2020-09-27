import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { TipoDocumento } from 'src/app/shared/models/tipoDocumento';
import { TipoDocumentoService } from 'src/app/shared/services/tipo-documento.service';
import { AccountService } from 'src/app/shared/services/account.service';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  usuario: User;
  listaTipoDocumento: Array<TipoDocumento> = [];
  codigoTipoDocumentoExclusao: string;

  constructor(
    private tipoDocumentoService: TipoDocumentoService,
    private toastrService: ToastrService,
    private accountService: AccountService
    ) { }

  ngOnInit(): void {
    this.usuario = this.accountService.userValue;
    this.buscarTiposDocumento();
  }

  buscarTiposDocumento() {
    this.tipoDocumentoService.buscarTiposDocumento().pipe(
      catchError((error) => {
        this.toastrService.error(error);
        return throwError(error);
      })
    ).subscribe((listaTipoDocumento: TipoDocumento[]) => {
      this.listaTipoDocumento = listaTipoDocumento;
    });
  }

  ehAnalista(): boolean {
    return this.usuario.papel === 'Analista';
  }
}
