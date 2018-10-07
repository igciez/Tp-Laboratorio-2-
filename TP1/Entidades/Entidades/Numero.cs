using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos

        private double numero;

        #endregion
        #region Propiedades

        private string SetNumero
        {
            set
            {              
                numero = ValidarNumero(value);                          
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Inicializa en 0 la instancia numero, al no tener paramentros.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// inicializa la instancia numero, con el parametro double ingresado
        /// </summary>
        /// <param name="numero">parametro double ingresado</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// incializa la instacia numero, con el parametro string ingresado
        /// </summary>
        /// <param name="strNumero">parametro string ingresado</param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        /// <summary>
        /// Realiza la resta entre dos objetos de clase Numero
        /// </summary>
        /// <param name="numeroUno">Primer objeto a restar</param>
        /// <param name="numeroDos">Segundo objeto a restar</param>
        /// <returns></returns>
        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero - numeroDos.numero;
        }
        /// <summary>
        /// Realiza la suma entre dos objetos de clase Numero
        /// </summary>
        /// <param name="numeroUno">Primer objeto a sumar</param>
        /// <param name="numeroDos">Segundo objeto a sumar</param>
        /// <returns></returns>
        public static double operator +(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero + numeroDos.numero;
        }
        /// <summary>
        /// Realiza la multiplicacion entre dos objetos de clase Numero
        /// </summary>
        /// <param name="numeroUno">Primero objeto a multiplicar</param>
        /// <param name="numeroDos">Segudno objeto a multiplicar</param>
        /// <returns></returns>
        public static double operator *(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero * numeroDos.numero;
        }
        /// <summary>
        /// Realiza la division entre dos objetos de clase Numero
        /// </summary>
        /// <param name="numeroUno">Primer objeto a dividirr</param>
        /// <param name="numeroDos">Segundo objeto a dividir</param>
        /// <returns></returns>
        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero / numeroDos.numero;
        }
        /// <summary>
        /// Valida que lo ingresado sea de tipo double
        /// </summary>
        /// <param name="strNumero">Objeto de tipo string ingresado </param>
        /// <returns></returns>
        private static double ValidarNumero(string strNumero)
        {
            if (!double.TryParse(strNumero, out double retorno))
            {
                retorno = 0;
            }
            return retorno;
        }
       /// <summary>
       /// Sobrecarga de operador implicito que genera un nuevo objeto Numero
       /// </summary>
       /// <param name="numero">tipo string</param>
        public static implicit operator Numero(string numero)
        {
            return new Numero(numero);
        }
        /// <summary>
        /// Sobrecarga de operador implicito que genera un nuevo objeto Numero
        /// </summary>
        /// <param name="numero">tipo double</param>
        public static implicit operator Numero(double numero)
        {
            return new Numero(numero);
        }

        /// <summary>
        /// Transforma un número binario a decimal y lo devuelve como string
        /// </summary>
        /// <param name="binario">Número binario a transformar</param>
        /// <returns>si es posible el numero decimay. si no, "Valor invalido"</returns>
        public static string BinarioDecimal(string binario)
        {
            if (Regex.IsMatch(binario, "^[01]+$"))
            {
                int exponencia = (int)Math.Pow(2, binario.Length - 1);
                double contador = 0;
                foreach (char caracter in binario)
                {
                    contador += ((int)Char.GetNumericValue(caracter) * exponencia);
                    exponencia /= 2;
                }
                return contador.ToString();
            }
            return "Valor invalido";
        }

        /// <summary>
        /// Transforma un número decimal a Binario
        /// </summary>
        /// <param name="numero">Número decimal a transformar</param>
        /// <returns>si es posible el numero decimay. si no, "Valor invalido"</returns>
        public static string DecimalBinario(double numero)
        {
            if (numero >= 0)
            {
                string binario = "";
                if (numero == 0)
                {
                    binario = "0";
                }
                while (numero != 0)
                {
                    binario = String.Concat((numero % 2).ToString(), binario);
                    numero = (int)numero / 2;
                }
                return binario;
            }
            return "Valor invalido";
        }

        /// <summary>
        /// Transforma un número decimal a binario
        /// </summary>
        /// <param name="numero">Número decimal a transformar</param>
        /// <returns>si es posible el numero decimay. si no, "Valor invalido"</returns>
        public static string DecimalBinario(string numero)
        {
            if (double.TryParse(numero, out double doubleNumero))
            {
                return DecimalBinario(doubleNumero);
            }
            return "Valor invalido";
        }
        #endregion
    }
}
