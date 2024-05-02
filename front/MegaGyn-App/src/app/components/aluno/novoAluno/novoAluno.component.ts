import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { IAluno } from 'src/app/models/IAluno';
import { ActivatedRoute } from '@angular/router';
import { AlunoService } from 'src/app/services/alunoService.service';

@Component({
  selector: 'app-novoAluno',
  templateUrl: './novoAluno.component.html',
  styleUrls: ['./novoAluno.component.scss']
})
export class NovoAlunoComponent implements OnInit {

  aluno = {} as IAluno;
  form!: FormGroup;

  get fControl(): any {
    return this.form.controls;
  }

  constructor(private alunoService: AlunoService,
    private fb: FormBuilder, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.validation();
    this.salvarAlteracao();
  }

  /**
   * validation
 : void  */
  public validation(): void {
    this.form = this.fb.group({
      id: ['', [Validators.required]], 
      nome: ['',  [Validators.required]] ,
      idTreino: ['', [Validators.required]],
      
    });
  }
  public resetForm(): void{
    this.form.reset();
  }
  public vForm(): boolean {
    return this.form.valid; 
  }

  public salvarAlteracao(): void {
    if (this.form.valid) {

        this.aluno = {          
          id: this.form.value.codigo,
          nome: this.form.value.nome,
          idTreino: this.form.value.codigo,
        }

        this.alunoService.postAluno(this.aluno).subscribe(
          () => {
            window.alert("Aluno salvo com sucesso!");
          },
          (error: any) => {
            console.error(error);
            window.alert("Erro ao salvar Aluno!");
          }
        );
        
      }
      
    }  

}
