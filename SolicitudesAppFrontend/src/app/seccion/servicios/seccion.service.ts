import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from 'src/app/interfaces/api-response';
import { enviroment } from 'src/enviroments/enviroment.prod';
import { Seccion } from '../interfaces/Seccion';

@Injectable({
  providedIn: 'root'
})
export class SeccionService {

  baseUrl: string = enviroment.apiUrl + 'seccion/';

  constructor(private http: HttpClient) { }

  lista(): Observable<ApiResponse>{
    return this.http.get<ApiResponse>(`${this.baseUrl}`);
  }

  crear(request: Seccion) : Observable<ApiResponse> {
    return this.http.post<ApiResponse>(`${this.baseUrl}`, request);
  }

  editar(request: Seccion) : Observable<ApiResponse>{
    return this.http.put<ApiResponse>(`${this.baseUrl}`, request);
    }

    eliminar(id: number) : Observable<ApiResponse>{
      return this.http.delete<ApiResponse>(`${this.baseUrl}${id}`);
  }
}
