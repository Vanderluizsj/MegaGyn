import { Component, OnInit, OnDestroy, TemplateRef } from '@angular/core';
import { AlunoService } from '../../services/alunoService.service';  //new
import { IAluno } from '../../models/IAluno';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.scss']
})
export class AlunoComponent implements OnInit {

  public subscription?: Subscription | null = null;
  modalRef?: BsModalRef;
  public alunos: IAluno[] = [];
  public alunosFiltrados: IAluno[] = [];
  public widthImg: number = 150;
  public marginImg: number = 2;
  public mostrarImagem = true;
  private _filtroLista: string = '';
  

  /**
   * get filtroLista
   */
  public get filtroLista(): string {
    return this._filtroLista;
  }
  /**
   * set filtroLista
   */
  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.alunosFiltrados = this.filtroLista ? this.filtrarAlunos(this.filtroLista) : this.alunos;
  }


  public filtrarAlunos(filtrarPor: string): IAluno[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.alunos.filter(
      (aluno : any) => aluno.marca.toLocaleLowerCase().indexOf(filtrarPor) !== -1 || aluno.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  };

  constructor(
    private alunoService: AlunoService
    ) { }  //new
  
  //constructor(private http: HttpClient) { }  //old

  public exibirImagem(): void {
    this.mostrarImagem = !this.mostrarImagem;
  }

  public ngOnInit(): void {
    this.getAlunos();
  }
  ngOnDestroy(): void{
    this.subscription?.unsubscribe;
  }

  public getAlunos(): void {
    this.subscription = this.alunoService.getAlunos().subscribe(
      (_alunos: IAluno[]) => {
        this.alunos = _alunos;
        this.alunosFiltrados = this.alunos;
      },
      error => console.log(error),
    );   
  }
  
 
 
  confirm(): void {
    this.modalRef?.hide();
  }
 
  decline(): void {
    this.modalRef?.hide();
  }

}
