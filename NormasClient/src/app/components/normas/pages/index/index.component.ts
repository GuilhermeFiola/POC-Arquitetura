import { Component, OnInit } from '@angular/core';
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

  constructor(
    private normasService: NormasService,
    private toastrService: ToastrService
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

}
