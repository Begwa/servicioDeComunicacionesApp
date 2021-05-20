using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace
namespace ServicioDeComunicacionesModel.DTO
{
    public class Lectura
    {
        //atributos
        private DateTime fecha;
        private string valor;
        private int tipo;
        private string unidadMedida;
        //property/getters and setters
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Valor { get => valor; set => valor = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public string UnidadMedida { get => unidadMedida; set => unidadMedida = value; }
        //toString
        public override string ToString()
        {
            return Fecha + "|" + Valor + "|" + Tipo + "|" + UnidadMedida;
        }
    }
}