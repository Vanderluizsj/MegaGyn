import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ExercicioService } from './services/exercicioService.service';

import { AlunoComponent } from './components/aluno/aluno.component';
import { ExercicioComponent } from './components/exercicio/exercicio.component';
import { TreinoComponent } from './components/treino/treino.component';
import { HomeComponent } from './components/home/home.component';

import { FooterComponent } from './shared/footer/footer.component';
import { NavComponent } from './shared/nav/nav.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    AlunoComponent,
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
    ExercicioService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
