using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }
        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">valor de EMarca ingresado</param>
        /// <param name="patente">valor string ingresado</param>
        /// <param name="color">valor ConsoleColor ingresado</param>
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
            this.tipo = ETipo.Entera;
        }

        /// <summary>
        /// Sobrecarga del constructor, con Etipo
        /// </summary>
        /// <param name="marca">valor de EMarca ingresado </param>
        /// <param name="patente">valor string ingresado</param>
        /// <param name="color">valor ConsoleColor ingresado</param>
        /// <param name="tipo">valor ETipo ingresado </param>
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo)
           : base(patente, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        /// <summary>
        /// sobreescritura del metodo Mostrar, de la clase base.
        /// </summary>
        /// <returns>Un apendice por consola</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
