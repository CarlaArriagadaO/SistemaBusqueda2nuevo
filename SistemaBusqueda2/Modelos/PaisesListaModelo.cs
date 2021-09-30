using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBusqueda2.Modelos
{
    public class PaisesListaModelo
    {
        public int Codpais { get; set; }
        public string Nombrepais { get; set; }

        public static implicit operator List<object>(PaisesListaModelo paisesListaModelo)
        {
            throw new NotImplementedException();
        }
    }
}
