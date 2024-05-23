import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/interfaces/api-response';
import { enviroment } from 'src/enviroments/enviroment.prod';
import { Materia } from '../interfaces/materia';

@Injectable({
  providedIn: 'root'
})
export class MateriaService {

  baseUrl: string = enviroment.apiUrl + 'materia/';

  constructor(private http: HttpClient) { }

  lista(): Observable<ApiResponse>{
    return this.http.get<ApiResponse>(`${this.baseUrl}`);
  }

  crear(request: Materia) : Observable<ApiResponse> {
    return this.http.post<ApiResponse>(`${this.baseUrl}`, request);
  }

  editar(request: Materia) : Observable<ApiResponse>{
    return this.http.put<ApiResponse>(`${this.baseUrl}`, request);
    }

    eliminar(id: number) : Observable<ApiResponse>{
      return this.http.delete<ApiResponse>(`${this.baseUrl}${id}`);
  }
}
