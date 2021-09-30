using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaBusqueda2.Modelos;
using SistemaBusqueda2.Repositorios;

namespace SistemaBusqueda2.Pages
{
    public class PaisesModel : PageModel
    {
        public List<PaisesListaModelo> Paises { get; set; }
        public ActionResult OnGet ()
        {
            
            {
                var idSession = HttpContext.Session.GetString("idSession");
                if (string.IsNullOrEmpty(idSession))
                {
                    return RedirectToPage("./Index");
                }

                //obtener registros de bd y carga a pro paises

                var repo = new PaisRepositorio();

                this.Paises = repo.ObtenerPaises();

                return Page();
            }
        }
    }
}
