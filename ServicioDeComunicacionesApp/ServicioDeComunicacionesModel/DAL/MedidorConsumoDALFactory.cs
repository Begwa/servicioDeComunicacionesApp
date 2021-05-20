using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDeComunicacionesModel.DAL
{
    public class MedidorConsumoDALFactory
    {
        public static IMedidorConsumoDAL createDal()
        {
            return MedidorConsumoDALArchivos.GetInstancia();
        }
    }
}
