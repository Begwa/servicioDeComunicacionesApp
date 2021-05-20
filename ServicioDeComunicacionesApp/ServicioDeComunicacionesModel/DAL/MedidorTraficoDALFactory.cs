using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDeComunicacionesModel.DAL
{
    public class MedidorTraficoDALFactory
    {
        public static IMedidorTraficoDAL createDal()
        {
            return MedidorTraficoDALArchivos.GetInstancia();
        }
    }
}
