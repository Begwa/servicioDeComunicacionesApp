using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace
namespace ServicioDeComunicacionesModel.DTO
{
    public class Medidor
    {
        //atributos
        private int id;
        private DateTime date;
        //property/getters and setters
        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        //toString
        public override string ToString()
        {
            return Id + "|" + Date;
        }
    }
}