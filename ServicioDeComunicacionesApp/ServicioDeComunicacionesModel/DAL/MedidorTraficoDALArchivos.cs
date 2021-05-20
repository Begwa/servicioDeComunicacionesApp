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
    public class MedidorTraficoDALArchivos : IMedidorTraficoDAL
    {
        //patron singleton
        //1.
        private MedidorTraficoDALArchivos()
        {

        }
        //2.
        private static IMedidorTraficoDAL instancia;
        //3.
        public static IMedidorTraficoDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new MedidorTraficoDALArchivos();
            return instancia;
        }

        private string registroTraficos = Directory.GetCurrentDirectory() +
            Path.DirectorySeparatorChar + "traficos.txt";

        public List<MedidorTrafico> GetAll()
        {
            List<MedidorTrafico> traficos = new List<MedidorTrafico>();
            try
            {
                using(StreamReader reader = new StreamReader(registroTraficos))
                {
                    string texto3 = null;
                    do
                    {
                        texto3 = reader.ReadLine();
                        if (texto3 != null)
                        {
                            string[] textoArray3 = texto3.Split('|');
                            MedidorTrafico mt = new MedidorTrafico()
                            {
                                Id = textoArray3[0],
                                Date = textoArray3[1],
                                CantidadVehi = textoArray3[2]
                            };
                            traficos.Add(mt);
                        }
                    } while (texto3 != null);
                }
            }catch(IOException ex)
            {

            }
            return traficos;
        }

        public void Save(MedidorTrafico mt)
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(registroTraficos, true))
                {
                    writer.WriteLine(mt);
                    writer.Flush();
                }
            }
            catch(IOException ex)
            {

            }
        }
    }
}