using Azure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using ScireHub.Context;
using ScireHub.Services.IServices;
using ScireHub.Models.Entities;

namespace ScireHub.Controllers
{
    public class UsuariosController : Controller
    {

        //Constructor para el uso de base de datos
        private readonly IUsuarioServices _usuarioServices;
        //Se inicia la entrada a base de datos
        private readonly ApplicationDbContext _context;
        public UsuariosController(IUsuarioServices usuarioServices, ApplicationDbContext context)
        {
            _usuarioServices = usuarioServices;
            _context = context;
        }

        [HttpGet]
        //Se retorna la vista "index" de la respectiva carpeta
        public async Task<IActionResult> Index()
        {
            try
            {
                //Uso de la lista de los Usuario para que se muestre al abrir la vista

                return View(await _usuarioServices.GetUsuarios());

                /* var response = await _articuloServices.GetArticulos();
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
            ViewBag.Roles = _context.Roles.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkRoles.ToString()
            });
            return View();
        }
        [HttpPost]
        public IActionResult Crear([FromForm] Usuario request)
        {
            try
            {
                var response = _usuarioServices.CrearUsuario(request);
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
            var response = await _usuarioServices.GetByIdUsuario(id);

            ViewBag.Roles = _context.Roles.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkRoles.ToString()
            });
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Usuario request)
        {
            var response = await _usuarioServices.EditarUsuario(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _usuarioServices.EliminarUsuario(id);
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
