import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { IExercicio } from 'src/app/models/IExercicio';
import { ActivatedRoute } from '@angular/router';
import { ExercicioService } from 'src/app/services/exercicioService.service';
@Component({
  selector: 'app-exercicio',
  templateUrl: './exercicio.component.html',
  styleUrls: ['./exercicio.component.scss']
})
export class ExercicioComponent implements OnInit {

  exercicio = {} as IExercicio;
  form!: FormGroup;

  get fControl(): any {
    return this.form.controls;
  }

  constructor(private exercicioService: ExercicioService,
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
      nomeExercicio: ['',  [Validators.required]] ,
      series: ['', [Validators.required]],
      repeticoes: ['',  [Validators.required]],
      
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

        this.exercicio = {          
          id: this.form.value.codigo,
          nomeExercicio: this.form.value.nome,
          series: this.form.value.codigo,
          repeticoes: this.form.value.codigo,
        }

        this.exercicioService.postExercicio(this.exercicio).subscribe(
          () => {
            window.alert("Exercicio salvo com sucesso!");
          },
          (error: any) => {
            console.error(error);
            window.alert("Erro ao salvar exercicio!");
          }
        );
        
      }
      
    }  

}
