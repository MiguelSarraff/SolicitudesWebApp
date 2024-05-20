using Data.Interfaces.IRepositorio;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class MateriaRepositorio : Repositorio<Materia>, IMateriaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public MateriaRepositorio(ApplicationDbContext db) : base (db) 
        {
            _db = db;
        }

        public void Actualizar(Materia materia)
        {
           var materiaDb = _db.Materias.FirstOrDefault(e => e.Id == materia.Id);
            if (materiaDb != null)
            {
                materiaDb.MateriaNombre = materia.MateriaNombre;
                materiaDb.MateriaCodigo = materia.MateriaCodigo;
                materiaDb.MateriaCreditos = materia.MateriaCreditos;
                materiaDb.Estado = materia.Estado;
                materiaDb.FechaActualizacion = DateTime.Now;
                materiaDb.CarreraId = materia.CarreraId;
                
                

                _db.SaveChanges();
            }
        }
    }
}
