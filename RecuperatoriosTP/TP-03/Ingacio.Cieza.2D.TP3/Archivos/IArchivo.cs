using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivo<T>
    {
        #region Metodos
        /// <summary>
        /// Metodo de Interfaz para guardar datos
        /// </summary>
        /// <param name="archivos">Direccion del Archivo</param>
        /// <param name="datos">tipo de dato a guardar</param>
        /// <returns>Nada, es sola la firma</returns>
        bool Guardar(string archivos, T datos);

        /// <summary>
        /// Metodo de Interfaz para leer datos
        /// </summary>
        /// <param name="archivos">Direccion del Archivo</param>
        /// <param name="datos">valor de donde se guardan los datos que se recupera</param>
        /// <returns>Nada, es sola la firma<</returns>
        bool Leer(string archivos, out T datos);

        #endregion
    }
}
