using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace
namespace ServicioDeComunicacionesModel.DTO
{
    public class MedidorConsumo: Medidor
    {
        //atributos
        private int estado;
        private double kwhConsumidos;
        //property/getters and setters
        public int Estado { get => estado; set => estado = value; }
        public double KwhConsumidos { get => kwhConsumidos; set => kwhConsumidos = value; }
        //toString
        public override string ToString()
        {
            return Estado + "|" + KwhConsumidos;
        }
    }
}