using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioDeComunicacionesModel.DTO;
//namespace
namespace ServicioDeComunicacionesModel.DAL
{
    public class LecturasDALArchivos : ILecturasDAL
    {
        //patron singleton
        //1.
        private LecturasDALArchivos()
        {

        }
        //2.
        private static ILecturasDAL instancia;
        //3.
        public static ILecturasDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new LecturasDALArchivos();
            return instancia;
        }

        private string registroLecturas = Directory.GetCurrentDirectory() +
            Path.DirectorySeparatorChar + "RegistroLecturas.json";

        public List<Lectura> GetAll()
        {
            List<Lectura> lecturas = new List<Lectura>();
            try
            {
                using(StreamReader reader = new StreamReader(registroLecturas))
                {
                    string texto = null;
                    do
                    {
                        texto = reader.ReadLine();
                        if(texto != null)
                        {
                            string[] textoArray = texto.Split('|');
                            Lectura l = new Lectura()
                            {
                                Fecha = textoArray[0],
                                Valor = textoArray[1],
                                Tipo = textoArray[2],
                                UnidadMedida = textoArray[3]
                            };
                            lecturas.Add(l);
                        }
                    } while (texto != null);
                }
            }catch(IOException ex)
            {

            }

            return lecturas;
        }

        public void Save(Lectura l)
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(registroLecturas, true))
                {
                    writer.WriteLine(l);
                    writer.Flush();
                }
            }catch(IOException ex)
            {
                
            }
        }
    }
}