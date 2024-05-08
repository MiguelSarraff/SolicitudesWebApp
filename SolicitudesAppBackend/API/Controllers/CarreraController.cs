using API.Extensiones;
using BLL.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using System.Net;

namespace API.Controllers
{
    public class CarreraController : BaseApiController
    {
        private readonly ICarreraServicio _carreraServicio;
        private ApiResponse _response;

        public CarreraController(ICarreraServicio carreraServicio)
        {
            _carreraServicio = carreraServicio;
            _response = new();
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _carreraServicio.ObtenerTodos();
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

        public async Task<IActionResult> Crear(CarreraDto modeloDto)
        {
            try
            {
                await _carreraServicio.Agregar(modeloDto);
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
        public async Task <IActionResult> Editar(CarreraDto modeloDto)
        {
            try
            {
                await _carreraServicio.Actualizar(modeloDto);
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
                await _carreraServicio.Remover(id);
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
