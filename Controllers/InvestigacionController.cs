using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScireHub.Context;
using ScireHub.Models.Entities;
using ScireHub.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace ScireHub.Controllers
{
    public class InvestigacionController : Controller
    {

        //Constructor para el uso de base de datos
        private readonly IInvestigacionServices _investigacionServices;
        //Se inicia la entrada a base de datos
        private readonly ApplicationDbContext _context;
        public InvestigacionController(IInvestigacionServices investigacionServices, ApplicationDbContext context)
        {
            _investigacionServices = investigacionServices;
            _context = context;
        }

        [HttpGet]
        //Se retorna la vista "index" de la respectiva carpeta
        public async Task<IActionResult> Index()
        {
            try
            {
                //Uso de la lista de los articulos para que se muestre al abrir la vista

                return View(await _investigacionServices.GetInvestigaciones());

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
        public IActionResult Crear(Investigación request)
        {
            try
            {
                var response = _investigacionServices.SubirInvestigacion(request);
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
            var response = await _investigacionServices.GetByIdInvestigacion(id);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Investigación request)
        {
            var response = await _investigacionServices.EditarInvestigacion(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _investigacionServices.EliminarInvestigacion(id);
            if (true)
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
