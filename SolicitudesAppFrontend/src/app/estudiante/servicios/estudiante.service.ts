import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/interfaces/api-response';
import { enviroment } from 'src/enviroments/enviroment.prod';
import { Estudiante } from '../interfaces/estudiante';

@Injectable({
  providedIn: 'root'
})
export class EstudianteService {
  
  baseUrl: string = enviroment.apiUrl + 'estudiante/';

  constructor(private http: HttpClient) { }

  lista(): Observable<ApiResponse>{
    return this.http.get<ApiResponse>(`${this.baseUrl}`);
  }

  crear(request: Estudiante) : Observable<ApiResponse> {
    return this.http.post<ApiResponse>(`${this.baseUrl}`, request);
  }

  editar(request: Estudiante) : Observable<ApiResponse>{
    return this.http.put<ApiResponse>(`${this.baseUrl}`, request);
    }

    eliminar(id: number) : Observable<ApiResponse>{
      return this.http.delete<ApiResponse>(`${this.baseUrl}${id}`);
  }
}
