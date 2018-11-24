using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class JornadaTest
    {
        [TestMethod]
        public void CargoAtributosJornadaCorrectamente_ValidoAtributosNoNull()
        {
            Profesor tempProfesor;
            Jornada tempJornada;

            tempProfesor = new Profesor();
            tempJornada = new Jornada(Universidad.EClases.Laboratorio, tempProfesor);
            
            Assert.IsNotNull(tempJornada.Clase);
            Assert.IsNotNull(tempJornada.Instructor);
            Assert.IsNotNull(tempJornada.Alumnos);
        }
    }
}
