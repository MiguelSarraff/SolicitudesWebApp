using Data.Interfaces.IRepositorio;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class EstudianteRepositorio : Repositorio<Estudiante>, IEstudianteRepositorio
    {
        private readonly ApplicationDbContext _db;

        public EstudianteRepositorio(ApplicationDbContext db) : base (db) 
        {
            _db = db;
        }

        public void Actualizar(Estudiante estudiante)
        {
           var estudianteDb = _db.Estudiantes.FirstOrDefault(e => e.Id == estudiante.Id);
            if (estudianteDb != null)
            {
                estudianteDb.EstudianteNombres = estudiante.EstudianteNombres;
                estudianteDb.EstudianteApellidos = estudiante.EstudianteApellidos;
                estudianteDb.Cedula = estudiante.Cedula;
                estudianteDb.Direccion = estudiante.Direccion;  
                estudianteDb.Telefono = estudiante.Telefono;
                estudianteDb.Email = estudiante.Email;
                estudianteDb.Genero = estudiante.Genero;
                estudianteDb.Estado = estudiante.Estado;
                estudianteDb.UsuarioId = estudiante.UsuarioId;
                estudianteDb.FechaActualizacion = DateTime.Now;
                _db.SaveChanges();
            }
        }
    }
}
