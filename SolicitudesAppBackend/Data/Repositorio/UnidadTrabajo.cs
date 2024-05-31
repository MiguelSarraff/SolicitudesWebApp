﻿using Data.Interfaces.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class UnidadTrabajo: IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public ICarreraRepositorio Carrera { get; private set; }
        public IMateriaRepositorio Materia { get; private set; }
        public IProfesorRepositorio Profesor { get; private set; }
        public IEstudianteRepositorio Estudiante { get; private set; }
        public ISeccionRepositorio Seccion { get; private set; }
        public ISolicitudRepositorio Solicitud { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Carrera = new CarreraRepositorio(db); 
            Materia = new MateriaRepositorio(db);
            Profesor = new ProfesorRepositorio(db);
            Estudiante = new EstudianteRepositorio(db);
            Seccion = new SeccionRepositorio(db);
            Solicitud = new SolicitudRepositorio(db);
        }
        public void Dispose()
        {
            _db.Dispose();
        }
        public async Task Guardar() 
        {
            await _db.SaveChangesAsync();
        }

    }
}
