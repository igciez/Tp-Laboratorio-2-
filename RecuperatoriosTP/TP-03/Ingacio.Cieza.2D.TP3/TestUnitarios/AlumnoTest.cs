using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class AlumnoTest
    {
        [TestMethod]
        public void InstanciaAlumnoDniInvalido_LanzaDniInvalidoException()
        {
            Alumno temporal;
            const string dniInvalido = "";

            try
            {
                temporal = new Alumno(1, "Pablo", "Roo", dniInvalido, Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
                return;
            }
            Assert.Fail("DNI invlaido: {0}. No lanza excepcion", dniInvalido);
        }

        [TestMethod]
        public void DniInvalidoParaNacionalidadExtranjera_LanzaNacionalidadInvalidaException()
        {
            const string dniNoExtranjero = "88888888";
            Alumno temporal;

            try
            {
                temporal = new Alumno(1, "Pablo", "Roo", dniNoExtranjero, Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
                return;
            }
            Assert.Fail("DNI invlaido: {0}. No lanza excepcion", dniNoExtranjero);
        }

        [TestMethod]
        public void ValidaValorNumericoDniNacional_ComparaValorNumerico()
        {
            const string dniArgentino = "88888888";
            Alumno temporal;

            temporal = new Alumno(1, "Pablo", "Roo", dniArgentino, Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            
            Assert.AreEqual(88888888, temporal.DNI);            
        }       

    }
}
