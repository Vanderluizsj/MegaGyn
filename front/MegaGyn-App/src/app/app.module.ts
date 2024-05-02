import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ExercicioService } from './services/exercicioService.service';
import { TreinoService } from './services/treinoService.service';
import { AlunoService } from './services/alunoService.service';

import { AlunoComponent } from './components/aluno/aluno.component';
import { ExercicioComponent } from './components/exercicio/exercicio.component';
import { TreinoComponent } from './components/treino/treino.component';
import { HomeComponent } from './components/home/home.component';

import { FooterComponent } from './shared/footer/footer.component';
import { NavComponent } from './shared/nav/nav.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NovoAlunoComponent } from './components/aluno/novoAluno/novoAluno.component';


@NgModule({
  declarations: [
    AppComponent,
    AlunoComponent,
    NovoAlunoComponent,
    ExercicioComponent,
    TreinoComponent,
    HomeComponent,
    FooterComponent,
    NavComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    ExercicioService,
    TreinoService,
    AlunoService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
