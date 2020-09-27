import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IndexComponent } from './pages/index/index.component';
import { OrgaoExpedidorRoutingModule } from './orgao-expedidor-routing.module';

const COMPONENTS = [
  IndexComponent
];

@NgModule({
  declarations: [...COMPONENTS],
  imports: [
    CommonModule,
    OrgaoExpedidorRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class OrgaoExpedidorModule { }
