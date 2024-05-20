import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CompartidoService } from '../compartido.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit{


username: string = '';

constructor(private router: Router,private CompartidoService: CompartidoService)
{

}
  ngOnInit(): void {
    const usuarioToken = this.CompartidoService.obtenerSesion();
    if(usuarioToken!=null)
      {
        this.username = usuarioToken.username;
      }
  }



  cerraSesion(){
  this.CompartidoService.eliminarSesion();  
  this.router.navigate(['login']);
  }

}
