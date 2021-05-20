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
    public class MedidorConsumoDALArchivos : IMedidorConsumoDAL
    {
        //patron singleton
        //1.
        private MedidorConsumoDALArchivos()
        {

        }
        //2.
        private static IMedidorConsumoDAL instancia;
        //3.
        public static IMedidorConsumoDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new MedidorConsumoDALArchivos();
            return instancia;
        }

        private string registroConsumos = Directory.GetCurrentDirectory() +
            Path.DirectorySeparatorChar + "consumos.txt";


        public List<MedidorConsumo> GetAll()
        {
            List<MedidorConsumo> consumos = new List<MedidorConsumo>();
            try
            {
                using(StreamReader reader = new StreamReader(registroConsumos))
                {
                    string texto2 = null;
                    do
                    {
                        texto2 = reader.ReadLine();
                        if (texto2 != null)
                        {
                            string[] textoArray2 = texto2.Split('|');
                            MedidorConsumo mc = new MedidorConsumo()
                            {
                                Id = textoArray2[0],
                                Date = textoArray2[1],
                                Estado = textoArray2[2],
                                KwhConsumidos = textoArray2[3]
                            };
                            consumos.Add(mc);
                        }
                    } while (texto2 != null);
                }
            }catch(IOException ex)
            {

            }

            return consumos;
        }

        public void Save(MedidorConsumo mc)
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(registroConsumos, true))
                {
                    writer.WriteLine(mc);
                    writer.Flush();
                }

            }
            catch(IOException ex)
            {

            }
        }
    }
}