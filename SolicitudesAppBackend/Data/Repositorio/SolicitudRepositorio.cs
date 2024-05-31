using Data.Interfaces.IRepositorio;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class SolicitudRepositorio : Repositorio<Solicitud>, ISolicitudRepositorio
    {
        private readonly ApplicationDbContext _db;

        public SolicitudRepositorio(ApplicationDbContext db) : base (db) 
        {
            _db = db;
        }

        public void Actualizar(Solicitud solicitud)
        {
           var solicitudDb = _db.Solicitudes.FirstOrDefault(e => e.Id == solicitud.Id);
            if (solicitud !=null)
            {
                solicitudDb.Codigo = solicitud.Codigo;
                solicitudDb.SolicitudTipo = solicitud.SolicitudTipo;
                solicitudDb.Descripcion = solicitud.Descripcion;
                solicitudDb.Estatus = solicitud.Estatus;
                solicitudDb.Resolucion = solicitud.Resolucion;
                solicitudDb.SeccionId = solicitud.SeccionId;
                solicitudDb.EstudianteId = solicitud.EstudianteId;
                   
                _db.SaveChanges();
            }
        }
    }
}
