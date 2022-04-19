using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    internal class CEProduct
    {
        public int Codigo { get; set; } 
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty ;
        public decimal Precio { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;

        public CEProduct()
        {

        }

    }

    
}
