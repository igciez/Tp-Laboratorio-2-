using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException: Exception
    {
        #region Metodos

        public ArchivosException( Exception innerException) :base("\nArchivo con error.", innerException)
        {
        }


        #endregion
    }
}
