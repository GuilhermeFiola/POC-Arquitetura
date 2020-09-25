import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './pages/index/index.component';
import { NormasRoutingModule } from './normas-routing.module';
import { CriacaoComponent } from './pages/criacao/criacao.component';
import { AtualizacaoComponent } from './pages/atualizacao/atualizacao.component';
import { VisualizacaoComponent } from './pages/visualizacao/visualizacao.component';

const COMPONENTS = [
  IndexComponent,
  CriacaoComponent,
  AtualizacaoComponent,
  VisualizacaoComponent
];

@NgModule({
  declarations: [...COMPONENTS],
  imports: [
    CommonModule,
    NormasRoutingModule
  ]
})
export class NormasModule { }
