using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        #region Metodos

        /// <summary>
        /// Metodo de Texto para guardar datos, en base a IArchivos.
        /// </summary>
        /// <param name="archivos">Direccion del Archivo</param>
        /// <param name="datos">tipo de dato a guardar</param>
        /// <returns>bool, indicando el exito del metodo con true, en su defecto una exception</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            XmlTextWriter writer = null;

            try
            {
                writer = new XmlTextWriter(archivo,Encoding.UTF8);
                xmlSerializer.Serialize(writer, datos);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!(writer is null))
                    writer.Close();
            }
            return true;
        }

        /// <summary>
        /// Metodo de Texto para guardar datos, en base a IArchivos.
        /// </summary>
        /// <param name="archivos">Direccion del Archivo</param>
        /// <param name="datos">valor de donde se guardan los datos que se recupera</param>
        /// <returns>bool, indicando el exito del metodo con true, en su defecto una exception</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlTextReader writer = null;
            datos = default(T);

            try
            {
                writer = new XmlTextReader(archivo);
                datos = (T)serializer.Deserialize(writer);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!(writer is null))
                    writer.Close();
            }
            return true;
        }

        #endregion
    }


}

