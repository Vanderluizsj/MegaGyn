import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ITreino } from 'src/app/models/ITreino';
import { ActivatedRoute } from '@angular/router';
import { TreinoService } from 'src/app/services/treinoService.service';

@Component({
  selector: 'app-treino',
  templateUrl: './treino.component.html',
  styleUrls: ['./treino.component.scss']
})
export class TreinoComponent implements OnInit {

  treino = {} as ITreino;
  form!: FormGroup;

  get fControl(): any {
    return this.form.controls;
  }

  constructor(private treinoService: TreinoService,
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
      nomeTreino: ['',  [Validators.required]] ,
      idExercicio: ['', [Validators.required]],     
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

        this.treino = {          
          id: this.form.value.codigo,
          nomeTreino: this.form.value.nome,
          idExercicio: this.form.value.codigo,
        }

        this.treinoService.postTreino(this.treino).subscribe(
          () => {
            window.alert("Treino salvo com sucesso!");
          },
          (error: any) => {
            console.error(error);
            window.alert("Erro ao salvar treino!");
          }
        );
        
      }
      
    }  


}
