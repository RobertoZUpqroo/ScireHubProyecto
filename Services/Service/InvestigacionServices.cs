﻿using Microsoft.EntityFrameworkCore;
using ScireHub.Context;
using ScireHub.Models.Entities;
using ScireHub.Services.IServices;
using System.Data;

namespace ScireHub.Services.Service
{
    public class InvestigacionServices : IInvestigacionServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;
        private readonly IHttpContextAccessor _httpContext;

        //Constructor para usar las tablas de base de datos
        public InvestigacionServices(ApplicationDbContext context, IHttpContextAccessor httpContext, IWebHostEnvironment webHost)
        {
            _context = context;
            _httpContext = httpContext;
            _webHost = webHost;

        }

        public async Task<List<Investigación>> GetInvestigaciones()
        {
            try
            {

                return await _context.Investigaciones.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Investigación> GetByIdInvestigacion(int id)
        {
            try
            {

                Investigación response = await _context.Investigaciones.FirstOrDefaultAsync(x => x.PkInvestigación == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }
        public async Task<Investigación> SubirInvestigacion(Investigación i)
        {
            try
            {
                var urlPdf = i.Pdf.FileName;
                i.UrlPdfPath = @"Pdf/usuarios/" + urlPdf;

                Investigación request = new Investigación()
                {
                    Nombre = i.Nombre,
                    Categoría = i.Categoría,
                    Fecha = i.Fecha,
                    UrlPdfPath = i.UrlPdfPath,
                    FkAutor = i.FkAutor,
                };

                SubirPdf(urlPdf);

                var result = await _context.Investigaciones.AddAsync(request);
                _context.SaveChanges();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Investigación> EditarInvestigacion(Investigación i)
        {
            try
            {
                Investigación investigación = _context.Investigaciones.Find(i.PkInvestigación);

                investigación.Nombre = i.Nombre;
                investigación.Categoría = i.Categoría;
                investigación.Fecha = i.Fecha;
                investigación.FkAutor = i.FkAutor;

                _context.Entry(investigación).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return investigación;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
        public bool EliminarInvestigacion(int id)
        {
            try
            {
                Investigación investigación = _context.Investigaciones.Find(id);

                if (investigación != null)
                {
                    var res = _context.Investigaciones.Remove(investigación);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }
        public bool SubirPdf(string Pdf)
        {
            bool res = false;

            try
            {
                string rutaprincipal = _webHost.WebRootPath;
                var archivos = _httpContext.HttpContext.Request.Form.Files;

                if (archivos.Count > 0 && !string.IsNullOrEmpty(archivos[0].FileName))
                {

                    var nombreArchivo = Pdf;
                    var subidas = Path.Combine(rutaprincipal, "Pdf", "investigacion");

                    // Asegurarse de que el directorio de destino exista
                    if (!Directory.Exists(subidas))
                    {
                        Directory.CreateDirectory(subidas);
                    }

                    var rutaCompleta = Path.Combine(subidas, nombreArchivo);

                    using (var fileStream = new FileStream(rutaCompleta, FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStream);
                        res = true;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al subir el pdf: {ex.Message}");
            }

            return res;
        }
    }
}