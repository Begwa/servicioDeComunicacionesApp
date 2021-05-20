using ServicioDeComunicacionesModel.DAL;
using ServicioDeComunicacionesModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDeComunicacionesApp.Parciales
{
    public partial class Program
    {
        static ILecturasDAL lec = LecturasDALFactory.createDal();

        static void IngresarLectura()
        {
            DateTime fecha;
            string valor;
            int tipo;
            string unidadMedida;

            do
            {
                Console.WriteLine("ingrese fecha de Lectura");
                fecha = Console.ReadLine();
            } while (fecha == DateTime);

            do
            {
                Console.WriteLine("ingrese valor de la factura");
                valor = Console.ReadLine().Trim();
            } while (valor == string.Empty);

            do
            {
                Console.WriteLine("ingrese tipo de lectura");
                tipo = Console.ReadLine();
            } while (tipo == tipos);

            do
            {
                Console.WriteLine("ingrese unidad de medida");
                unidadMedida = Console.ReadLine().Trim();
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
        }

        static void MostrarLectura()
        {
            List<Lectura> lecturas = lec.GetAll();
            lecturas.ForEach(l =>
            {
                Console.WriteLine("Fecha:{0} Valor:{1} Tipo:{2}"
                    , l.Fecha, l.Valor, l.Tipo);
            });
        }

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("1. Ingresar Nueva Lectura");
            Console.WriteLine("2. Mostrar Lectura");
            Console.WriteLine("0. Salir");
                string opcion = Console.ReadLine().Trim();
            switch (opcion)
            {
                case "1": IngresarLectura();
                    break;
                case "2": MostrarLectura();
                    break;
                case "3": continuar = false;
                    break;
                default: Console.WriteLine("Opcion Incorrecta");
                    break;
            }
            return continuar;
        }
    }
}