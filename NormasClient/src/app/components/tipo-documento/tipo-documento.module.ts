import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IndexComponent } from './pages/index/index.component';
import { TipoDocumentoRoutingModule } from './tipo-documento-routing.module';

const COMPONENTS = [
  IndexComponent,
];

@NgModule({
  declarations: [...COMPONENTS],
  imports: [
    CommonModule,
    TipoDocumentoRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class TipoDocumentoModule { }
