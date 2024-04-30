import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { IExercicio } from './../models/IExercicio'
import { catchError } from 'rxjs/operators';

@Injectable(
  //{providedIn: 'root',}
)
export class ExercicioService {
  baseURL = 'https://localhost:7075/api/exercicio';

  constructor(private http: HttpClient) {}

  public getExercicio(): Observable<IExercicio[]> {
    return this.http.get<IExercicio[]>(this.baseURL);
  }

  public getExercicioById(id: string): Observable<IExercicio> {
    return this.http.get<IExercicio>(`${this.baseURL}/${id}`);
  }

  public postExercicio(exercicio: IExercicio): Observable<any> {
    return this.http.post(this.baseURL, exercicio);
  }
  
  public deleteExercicio(codigo: string): Observable<any> {
    const url = `${this.baseURL}/${codigo}`;
    return this.http.delete(url);
  }
  public putExercicio(codigo: string, exercicio: IExercicio): Observable<IExercicio> {
    return this.http
      .put<IExercicio>(this.baseURL, exercicio)
      .pipe(catchError(this.handleError));
  }
  private handleError(error: any): Observable<never> {
    console.error('Erro na requisição:', error);
    return throwError(
      'Erro na requisição. Por favor, tente novamente mais tarde.'
    );
  }
}
