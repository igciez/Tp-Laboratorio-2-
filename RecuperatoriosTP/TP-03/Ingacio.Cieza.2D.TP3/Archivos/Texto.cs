using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto: IArchivo<string>
    {
        #region Metodos


        /// <summary>
        /// Metodo de Texto para guardar datos
        /// </summary>
        /// <param name="archivos">Direccion del Archivo</param>
        /// <param name="datos">tipo de dato a guardar</param>
        /// <returns>bool, indicando el exito del metodo con true, en su defecto una exception</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter streamWriter = null;

            try
            {
                streamWriter = new StreamWriter(archivo);
                streamWriter.Write(datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!(streamWriter is null))
                    streamWriter.Close();
            }
            return true;
        }

        /// <summary>
        /// Metodo de Texto para leer datos
        /// </summary>
        /// <param name="archivos">Direccion del Archivo</param>
        /// <param name="datos">valor de donde se guardan los datos que se recupera</param>
        /// <returns>bool, indicando el exito del metodo con true, en su defecto una exception</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader streamReader = null;
            datos = "";

            try
            {
                streamReader = new StreamReader(archivo);
                datos = streamReader.ReadToEnd();
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!(streamReader is null))
                    streamReader.Close();
            }
            return true;
        }

        #endregion
    }
}
