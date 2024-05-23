using API.Extensiones;
using BLL.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using System.Net;

namespace API.Controllers
{
    public class ProfesorController : BaseApiController
    {
        private readonly IProfesorServicio _profesorServicio;
        private ApiResponse _response;

        public ProfesorController(IProfesorServicio profesorServicio)
        {
            _profesorServicio = profesorServicio;
            _response = new();
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _profesorServicio.ObtenerTodos();
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

        public async Task<IActionResult> Crear(ProfesorDto modeloDto)
        {
            try
            {
                await _profesorServicio.Agregar(modeloDto);
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
        public async Task <IActionResult> Editar(ProfesorDto modeloDto)
        {
            try
            {
                await _profesorServicio.Actualizar(modeloDto);
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

        [HttpDelete("{Id:int}")]

        public async Task<IActionResult> Eliminar(int Id)
        {
            try
            {
                await _profesorServicio.Remover(Id);
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
