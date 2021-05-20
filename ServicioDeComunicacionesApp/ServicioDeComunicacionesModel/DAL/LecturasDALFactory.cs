using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDeComunicacionesModel.DAL
{
    public class LecturasDALFactory
    {
        public static ILecturasDAL createDal()
        {
            return LecturasDALArchivos.GetInstancia();
        }
    }
}