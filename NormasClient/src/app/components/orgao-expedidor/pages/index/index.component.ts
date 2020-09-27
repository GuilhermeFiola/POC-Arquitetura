import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { OrgaoExpedidor } from 'src/app/shared/models/orgaoExpedidor';
import { OrgaoExpedidorService } from 'src/app/shared/services/orgao-expedidor.service';
import { AccountService } from 'src/app/shared/services/account.service';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  usuario: User;
  listaOrgaoExpedidor: Array<OrgaoExpedidor> = [];
  codigoOrgaoExpedidorExclusao: string;

  constructor(
    private orgaoExpedidorService: OrgaoExpedidorService,
    private toastrService: ToastrService,
    private accountService: AccountService
    ) { }

  ngOnInit(): void {
    this.usuario = this.accountService.userValue;
    this.buscarOrgaosExpedidores();
  }

  buscarOrgaosExpedidores() {
    this.orgaoExpedidorService.buscarOrgaosExpedidores().pipe(
      catchError((error) => {
        this.toastrService.error(error);
        return throwError(error);
      })
    ).subscribe((listaOrgaoExpedidor: OrgaoExpedidor[]) => {
      this.listaOrgaoExpedidor = listaOrgaoExpedidor;
    });
  }

  ehAnalista(): boolean {
    return this.usuario.papel === 'Analista';
  }
}
