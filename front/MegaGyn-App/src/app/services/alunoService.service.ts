import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { IAluno } from './../models/IAluno';
import { catchError } from 'rxjs/operators';

@Injectable()
//{providedIn: 'root',}
export class AlunoService {
  baseURL = 'https://localhost:7075/api/aluno';

  constructor(private http: HttpClient) {}

  public getAluno(): Observable<IAluno[]> {
    return this.http.get<IAluno[]>(this.baseURL);
  }

  public getAlunoById(id: Number): Observable<IAluno> {
    return this.http.get<IAluno>(`${this.baseURL}/${id}`);
  }

  public postAluno(aluno: IAluno): Observable<any> {
    return this.http.post(this.baseURL, aluno);
  }

  public deleteAluno(id: Number): Observable<any> {
    const url = `${this.baseURL}/${id}`;
    return this.http.delete(url);
  }
  public putAluno(
    id: Number,
    aluno: IAluno
  ): Observable<IAluno> {
    return this.http
      .put<IAluno>(this.baseURL, aluno)
      .pipe(catchError(this.handleError));
  }
  private handleError(error: any): Observable<never> {
    console.error('Erro na requisição:', error);
    return throwError(
      'Erro na requisição. Por favor, tente novamente mais tarde.'
    );
  }
}
