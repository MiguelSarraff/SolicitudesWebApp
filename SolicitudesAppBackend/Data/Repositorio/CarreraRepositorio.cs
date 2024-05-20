using Data.Interfaces.IRepositorio;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class CarreraRepositorio : Repositorio<Carrera>, ICarreraRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CarreraRepositorio(ApplicationDbContext db) : base (db) 
        {
            _db = db;
        }

        public void Actualizar(Carrera carrera)
        {
           var carreraDb = _db.Carreras.FirstOrDefault(e => e.Id == carrera.Id);
            if (carreraDb !=null)
            {
                carreraDb.CarreraNombre = carrera.CarreraNombre;
                carreraDb.CarreraCodigo = carrera.CarreraCodigo;
                carreraDb.Estado = carrera.Estado;
                carreraDb.FechaActualizacion = DateTime.Now;
                _db.SaveChanges();
            }
        }
    }
}
