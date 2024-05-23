import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { enviroment } from 'src/enviroments/enviroment.prod';
import { Profesor } from '../interfaces/profesor';
import { ApiResponse } from 'src/app/interfaces/api-response';

@Injectable({
  providedIn: 'root'
})
export class ProfesorService {
  
  baseUrl: string = enviroment.apiUrl + 'profesor/';

  constructor(private http: HttpClient) { }

  lista(): Observable<ApiResponse>{
    return this.http.get<ApiResponse>(`${this.baseUrl}`);
  }

  crear(request: Profesor) : Observable<ApiResponse> {
    return this.http.post<ApiResponse>(`${this.baseUrl}`, request);
  }

  editar(request: Profesor) : Observable<ApiResponse>{
    return this.http.put<ApiResponse>(`${this.baseUrl}`, request);
    }

    eliminar(id: number) : Observable<ApiResponse>{
      return this.http.delete<ApiResponse>(`${this.baseUrl}${id}`);
  }
}
