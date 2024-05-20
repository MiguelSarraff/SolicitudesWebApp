using API.Extensiones;
using BLL.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using System.Net;

namespace API.Controllers
{
    public class MateriaController : BaseApiController
    {
        private readonly IMateriaServicio _materiaServicio;
        private ApiResponse _response;

        public MateriaController(IMateriaServicio materiaServicio)
        {
            _materiaServicio = materiaServicio;
            _response = new();
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _materiaServicio.ObtenerTodos();
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;

            }
            return Ok(_response);
        }

        [HttpPost]

        public async Task<IActionResult> Crear(MateriaDto modeloDto)
        {
            try
            {
                await _materiaServicio.Agregar(modeloDto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.Created;

            }
            catch (Exception ex)
            {

                _response.IsExitoso = false;
                _response.Mensaje=ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;   
            }
            return Ok(_response);
            
           
        }

        [HttpPut]
        public async Task <IActionResult> Editar(MateriaDto modeloDto)
        {
            try
            {
                await _materiaServicio.Actualizar(modeloDto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.NoContent;

            }
            catch (Exception ex)
            {

                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;   
            }
            return Ok(_response);
 
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _materiaServicio.Remover(id);
                _response.IsExitoso = true;
                _response.StatusCode=HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                _response.IsExitoso=false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;

            }
            return Ok(_response);

        }
        

    }

}
