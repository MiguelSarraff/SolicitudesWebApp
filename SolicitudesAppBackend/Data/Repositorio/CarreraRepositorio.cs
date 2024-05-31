using Data.Interfaces.IRepositorio;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class SeccionRepositorio : Repositorio<Seccion>, ISeccionRepositorio
    {
        private readonly ApplicationDbContext _db;

        public SeccionRepositorio(ApplicationDbContext db) : base (db) 
        {
            _db = db;
        }

        public void Actualizar(Seccion seccion)
        {
           var seccionDb = _db.Secciones.FirstOrDefault(e => e.Id == seccion.Id);
            if (seccionDb !=null)
            {
                seccionDb.Codigo = seccion.Codigo;
                seccionDb.Edificio = seccion.Edificio;
                seccionDb.Aula = seccion.Aula;
                seccionDb.Horario = seccion.Horario;
                seccionDb.MateriaId = seccion.MateriaId;
                seccionDb.ProfesorId = seccion.ProfesorId;
                seccionDb.Estado = seccion.Estado;
                seccionDb.FechaActualizacion = DateTime.Now;
                _db.SaveChanges();
            }
        }
    }
}
