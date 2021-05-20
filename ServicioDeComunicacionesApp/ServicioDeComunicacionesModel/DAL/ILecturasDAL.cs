using ServicioDeComunicacionesModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace
namespace ServicioDeComunicacionesModel.DAL
{
    public interface ILecturasDAL
    {
        void Save(Lectura l);

        List<Lectura> GetAll();
    }
}