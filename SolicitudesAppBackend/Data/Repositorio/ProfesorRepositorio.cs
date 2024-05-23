using Data.Interfaces.IRepositorio;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class ProfesorRepositorio : Repositorio<Profesor>, IProfesorRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ProfesorRepositorio(ApplicationDbContext db) : base (db) 
        {
            _db = db;
        }

        public void Actualizar(Profesor profesor)
        {
           var profesorDb = _db.Profesores.FirstOrDefault(e => e.Id == profesor.Id);
            if (profesorDb != null)
            {
                profesorDb.ProfesorNombres = profesor.ProfesorNombres;
                profesorDb.ProfesorApellidos = profesor.ProfesorApellidos;
                profesorDb.Cedula = profesor.Cedula;
                profesorDb.Direccion = profesor.Direccion;  
                profesorDb.Telefono = profesor.Telefono;
                profesorDb.Email = profesor.Email;
                profesorDb.Genero = profesor.Genero;
                profesorDb.Estado = profesor.Estado;
                profesorDb.FechaActualizacion = DateTime.Now;
                _db.SaveChanges();
            }
        }
    }
}
