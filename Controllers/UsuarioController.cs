using Microsoft.AspNetCore.Mvc;
using ScireHub.Context;
using ScireHub.Services.IServices;

namespace ScireHub.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly IUsuarioServices _usuarioServices;
        private readonly ApplicationDbContext _context;


        public UsuariosController(IUsuarioServices usuarioServices, ApplicationDbContext context)
        {
            _usuarioServices = usuarioServices;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _usuarioServices.GetAll();
            return View(response);
        }
    }
}
