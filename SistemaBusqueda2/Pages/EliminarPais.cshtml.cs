using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaBusqueda2.Repositorios;

namespace SistemaBusqueda2.Pages
{
    public class EliminarPaisModel : PageModel
    {


        [BindProperty]

        public string Nombrepais { get; set; }

        [BindProperty]
        public int Codpais { get; private set; }
    
        public ActionResult OnGet(int codpais)
        {

            {
                var idSession = HttpContext.Session.GetString("idSession");
                if (string.IsNullOrEmpty(idSession))
                {
                    return RedirectToPage("./Index");
                }
                var repo = new PaisRepositorio();
                var Pais = repo.ObtenerPaisPorId(codpais);
                this.Codpais = Pais.Codpais;
                this.Nombrepais = Pais.Nombrepais;

                return Page();
            }
        }

        public ActionResult OnPost()
        {
            //eliminar el registro de la bd
            var repo = new PaisRepositorio();
            repo.EliminarPais(this.Codpais);
            return RedirectToPage("./Paises");
        }
    }
}

