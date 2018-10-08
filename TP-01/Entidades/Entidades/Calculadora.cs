using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida que el operador reciba +,-,/o*.
        /// </summary>
        /// <param name="operador">operador a validar</param>
        /// <returns>si es +,-,/o* devuelve el operador, si no devuelve el + </returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";

            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                retorno = operador;
            }

            return retorno;
        }
        /// <summary>
        /// Realiza la operacion entre dos numeros, en base al operador, ademas de validarlos.
        /// </summary>
        /// <param name="num1">Primer numero ingresado</param>
        /// <param name="num2">Segundo numero ingresado</param>
        /// <param name="operador">operador ingresado</param>
        /// <returns>La operacion resultante</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string temp = ValidarOperador(operador);
            double valorAretornar = 0;

            switch (temp)
            {
                case "+":
                    valorAretornar = num1 + num2;
                    break;
                case "-":
                    valorAretornar = num1 - num2;
                    break;
                case "*":
                    valorAretornar = num1 * num2;
                    break;
                case "/":
                    valorAretornar = num1 / num2;
                    break;
                default:
                    break;
            }
            return valorAretornar;
        }
    }
}