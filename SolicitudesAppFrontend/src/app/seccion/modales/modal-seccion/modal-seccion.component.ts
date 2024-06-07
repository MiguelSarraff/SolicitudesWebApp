import { Component, Inject, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Materia } from 'src/app/materia/interfaces/materia';
import { Profesor } from 'src/app/profesor/interfaces/profesor';
import { Seccion } from '../../interfaces/Seccion';
import { MateriaService } from 'src/app/materia/servicios/materia.service';
import { SeccionService } from '../../servicios/seccion.service';
import { ProfesorService } from 'src/app/profesor/servicios/profesor.service';
import { CompartidoService } from 'src/app/compartido/compartido.service';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-modal-seccion',
  templateUrl: './modal-seccion.component.html',
  styleUrls: ['./modal-seccion.component.css']
})
export class ModalSeccionComponent implements OnInit{

  formSeccion: FormGroup;
  titulo: string = 'Agregar';
  nombreBoton: string = 'Guardar';
  listaMaterias: Materia[] = [];
  listaProfesores: Profesor[] = [];

  constructor(
    private modal: MatDialogRef<ModalSeccionComponent>,
    @Inject(MAT_DIALOG_DATA) public datosSeccion: Seccion,
    private fb: FormBuilder,
    private _materiaServicio: MateriaService,
    private _seccionServicio: SeccionService,
    private _profesorServicio: ProfesorService,
    private _compartidoServicio: CompartidoService
  ) {
    this.formSeccion = this.fb.group({
      codigo: ['', Validators.required],
      edificio: ['', Validators.required],
      aula: ['', Validators.required],
      horario: ['', Validators.required],
      materiaId: ['', Validators.required],
      profesorId: ['', Validators.required],
      estado: ['1', Validators.required],
    });
    if (this.datosSeccion != null) {
      this.titulo = 'Editar';
      this.nombreBoton = 'Actualizar';
    }
  }


  ngOnInit(): void {
    if (this.datosSeccion != null) {
      this.formSeccion.patchValue({
        codigo: this.datosSeccion.codigo,
        edificio: this.datosSeccion.edificio,
        aula: this.datosSeccion.aula,
        horario: this.datosSeccion.horario,
        materiaId: this.datosSeccion.materiaId,
        profesorId: this.datosSeccion.profesorId,
        estado: this.datosSeccion.estado.toString(),
      });
    }
  }

  crearModificarSeccion() {
    const seccion: Seccion = {
      id: this.datosSeccion == null ? 0 : this.datosSeccion.id,
      codigo: this.formSeccion.value.codigo,
      edificio: this.formSeccion.value. edificio,
      aula: this.formSeccion.value.aula,
      horario: this.formSeccion.value. horario,
      materiaId: parseInt(this.formSeccion.value.materiaId),
      nombreMateria: '',
      profesorId: parseInt(this.formSeccion.value.profesorId),
      nombreProfesor: '',
      estado: parseInt(this.formSeccion.value.estado),
    };
    if (this.datosSeccion == null) {
      // Crear Seccion
      this._seccionServicio.crear(seccion).subscribe({
        next: (data) => {
          if (data.isExitoso) {
            this._compartidoServicio.mostrarAlerta(
              'La seccion ha sido grabada con Exito!',
              'Completo'
            );
            this.modal.close('true');
          } else
            this._compartidoServicio.mostrarAlerta(
              'No se pudo crear la Seccion',
              'Error!'
            );
        },
        error: (e) => {
          this._compartidoServicio.mostrarAlerta(e.error.mensaje, 'Error!');
        },
      });
    } else {
      // Editar/Actualizar Seccion
      this._seccionServicio.editar(seccion).subscribe({
        next: (data) => {
          if (data.isExitoso) {
            this._compartidoServicio.mostrarAlerta(
              'La seccion ha sido actualizada con Exito!',
              'Completo'
            );
            this.modal.close('true');
          } else
            this._compartidoServicio.mostrarAlerta(
              'No se pudo actualizar la seccion',
              'Error!'
            );
        },
        error: (e) => {
          this._compartidoServicio.mostrarAlerta(e.error.mensaje, 'Error!');
        },
      });
    }
  }

}
