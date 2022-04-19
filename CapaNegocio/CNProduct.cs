using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntidad;

namespace CapaNegocio
{
    internal class CNProduct
    {
       CDProducto cdProd = new CDProducto();
        
        public void CrearData()
        {
            cdProd.CreateData();          
                       
        }


    }
}
