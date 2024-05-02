import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AlunoComponent } from './components/aluno/aluno.component';
import { TreinoComponent } from './components/treino/treino.component';
import { ExercicioComponent } from './components/exercicio/exercicio.component';
import { NovoAlunoComponent } from './components/aluno/novoAluno/novoAluno.component';

const routes: Routes = [   
  {path: 'home', component: HomeComponent},
  {path: 'aluno', component: AlunoComponent},
  {path:'aluno/novoAluno', component: NovoAlunoComponent},
  {path: 'treino', component: TreinoComponent},
  {path: 'exercicio', component: ExercicioComponent},
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: '**', redirectTo: 'home', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
