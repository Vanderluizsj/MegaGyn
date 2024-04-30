import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { ITreino } from './../models/ITreino';
import { catchError } from 'rxjs/operators';

@Injectable()
//{providedIn: 'root',}
export class TreinoService {
  baseURL = 'https://localhost:7075/api/treino';

  constructor(private http: HttpClient) {}

  public getTreino(): Observable<ITreino[]> {
    return this.http.get<ITreino[]>(this.baseURL);
  }

  public getTreinoById(id: Number): Observable<ITreino> {
    return this.http.get<ITreino>(`${this.baseURL}/${id}`);
  }

  public postTreino(treino: ITreino): Observable<any> {
    return this.http.post(this.baseURL, treino);
  }

  public deleteTreino(id: Number): Observable<any> {
    const url = `${this.baseURL}/${id}`;
    return this.http.delete(url);
  }
  public putTreino(
    id: Number,
    treino: ITreino
  ): Observable<ITreino> {
    return this.http
      .put<ITreino>(this.baseURL, treino)
      .pipe(catchError(this.handleError));
  }
  private handleError(error: any): Observable<never> {
    console.error('Erro na requisição:', error);
    return throwError(
      'Erro na requisição. Por favor, tente novamente mais tarde.'
    );
  }
}
