using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace
namespace ServicioDeComunicacionesModel.DTO
{
    public class MedidorTrafico: Medidor
    {
        //atributos
        private int cantidadVehi;
        //property/getters and setters
        public int CantidadVehi { get => cantidadVehi; set => cantidadVehi = value; }
        //toString
        public override string ToString() => $"{this.CantidadVehi}";
    }
}