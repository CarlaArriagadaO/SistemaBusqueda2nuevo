using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaBusqueda2.Repositorios;

namespace SistemaBusqueda2.Pages
{
    public class ActualizarPaisModel : PageModel
    {
        [BindProperty]
        public int Codpais { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Nombrepais { get; set; }
        public ActionResult OnGet(int codpais)
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

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
 
                var repo = new PaisRepositorio();
                repo.ActualizarPais(this.Codpais, this.Nombrepais);
                return RedirectToPage("./Paises");

            }

            return Page();
        }
    }
}

