import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { enviroment } from 'src/enviroments/enviroment.prod';
import { Sesion } from '../interfaces/sesion';
import { Login } from '../interfaces/login';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {


baseUrl: string = enviroment.apiUrl+"usuario/"


constructor(private http: HttpClient) { }


iniciarSesion(request: Login):Observable<Sesion>{
return this.http.post<Sesion>(`${this.baseUrl}login`,request);
}

}


