using API.Extensiones;
using BLL.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using System.Net;

namespace API.Controllers
{
    public class EstudianteController : BaseApiController
    {
        private readonly IEstudianteServicio _estudianteServicio;
        private ApiResponse _response;

        public EstudianteController(IEstudianteServicio estudianteServicio)
        {
            _estudianteServicio = estudianteServicio;
            _response = new();
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _estudianteServicio.ObtenerTodos();
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

        public async Task<IActionResult> Crear(EstudianteDto modeloDto)
        {
            try
            {
                await _estudianteServicio.Agregar(modeloDto);
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
        public async Task <IActionResult> Editar(EstudianteDto modeloDto)
        {
            try
            {
                await _estudianteServicio.Actualizar(modeloDto);
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
                await _estudianteServicio.Remover(Id);
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
