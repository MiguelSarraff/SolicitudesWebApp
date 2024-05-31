using API.Extensiones;
using BLL.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using System.Net;

namespace API.Controllers
{
    public class SeccionController : BaseApiController
    {
        private readonly ISeccionServicio _seccionServicio;
        private ApiResponse _response;

        public SeccionController(ISeccionServicio seccionServicio)
        {
            _seccionServicio = seccionServicio;
            _response = new();
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _seccionServicio.ObtenerTodos();
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

        public async Task<IActionResult> Crear(SeccionDto modeloDto)
        {
            try
            {
                await _seccionServicio.Agregar(modeloDto);
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
        public async Task <IActionResult> Editar(SeccionDto modeloDto)
        {
            try
            {
                await _seccionServicio.Actualizar(modeloDto);
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
                await _seccionServicio.Remover(id);
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
