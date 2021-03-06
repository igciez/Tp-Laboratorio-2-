﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Extension de la clase string, utilizada para guardar texto en un archivo
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto,string archivo)
        {
            bool retorno = false;

            using (StreamWriter writer = new StreamWriter(@"C:\Users\user\desktop\"+@archivo,true))
            {                
                writer.WriteLine(texto);                 
                retorno = true;
            }
            return retorno;             
        }
    }
}
