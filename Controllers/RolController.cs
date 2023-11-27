using Microsoft.AspNetCore.Mvc;
using ScireHub.Models.Entities;
using ScireHub.Services.IServices;
using ScireHub.Models.Entities;
using ScireHub.Services.IServices;

namespace ProyectoWebDL.Controllers
{
    public class RolController : Controller
    {
        //Constructor para el uso de base de datos
        private readonly IRolServices _rolServices;
        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        [HttpGet]
        //Se retorna la vista "index" de la respectiva carpeta
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _rolServices.GetRol());

                /*var response = await _articuloServices.GetArticulos();
                return View(response);*/
            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Rol request)
        {
            try
            {
                var response = _rolServices.CrearRol(request);
                //Esta funcion return sirve para volver al index despues de la accion
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw new Exception("Error" + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _rolServices.GetByIdRol(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult Editar(Rol request)
        {
            var response = _rolServices.EditarRol(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _rolServices.EliminarRol(id);
            if (result = true)
            {
                return Json(new { succes = true });
            }
            else
            {
                return Json(new { succes = false });
            }
        }
    }
}
