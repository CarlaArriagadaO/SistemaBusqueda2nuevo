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

    public class NuevoPais_Model : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "El campo nombre pais es requerido")]

        public string Nombrepais { get; set; }
        public ActionResult OnGet()
        {

            {
                var idSession = HttpContext.Session.GetString("idSession");
                if (string.IsNullOrEmpty(idSession))
                {
                    return RedirectToPage("./Index");
                }


                return Page();
            }
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var repo = new PaisRepositorio();
                repo.InsertarPais(this.Nombrepais);
                return RedirectToPage("./Paises");
            }

            return Page();

        }
    }
}

