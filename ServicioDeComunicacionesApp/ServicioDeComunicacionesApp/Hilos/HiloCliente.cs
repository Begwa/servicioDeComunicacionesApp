using ServicioDeComunicacionesModel.DAL;
using ServicioDeComunicacionesModel.DTO;
using SocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace
namespace ServicioDeComunicacionesApp.Hilos
{
    public class HiloCliente
    {
        private ClienteSocket clienteSocket;
        private ILecturasDAL lec = LecturasDALFactory.createDal();

        public HiloCliente(ClienteSocket clienteSocket)
        {
            this.clienteSocket = clienteSocket;
        }

        public void Ejecutar()
        {
            DateTime fecha;
            string valor;
            int tipo;
            string unidadMedida;

            do
            {
                clienteSocket.Escribir("ingrese fecha de la lectura");
                fecha = clienteSocket.Leer();
            } while (fecha == DateTime);

            do
            {
                clienteSocket.Escribir("ingrese valor de la lectura");
                valor = clienteSocket.Leer().Trim();
            } while (valor == string.Empty);

            do
            {
                clienteSocket.Escribir("ingrese tipo de la lectura");
                tipo = clienteSocket.Leer();
            } while (tipo == int.MinValue(-1) || tipo == int.MaxValue(2));

            do
            {
                clienteSocket.Escribir("ingrese unidad de medida de la lectura");
                unidadMedida = clienteSocket.Leer();
            } while (unidadMedida == string.Empty);

            Lectura l = new Lectura()
            {
                Fecha = fecha,
                Valor = valor,
                Tipo = tipo,
                UnidadMedida = unidadMedida
            };
            lock (lec)
            {
                lec.Save(l);
            }
            clienteSocket.CerrarConexion();
        }
    }
}
