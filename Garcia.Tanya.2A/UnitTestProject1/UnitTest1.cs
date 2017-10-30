using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarExceptionNacionalidadInvalida()
        {
            Universidad miUniversidad = new Universidad();
            try
            {
                Alumno miAlumno = new Alumno(1, "Noelia", "Garcia", "12234458", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
                miUniversidad += miAlumno;
                Assert.Fail("Deberia avisar que la nacionalidad es invalida");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void ValidarExceptionAlumnoRepetido()
        {
            Universidad miUniversidad = new Universidad();
            Alumno miAlumno1 = new Alumno(2, "Frank", "Barinson", "17283387", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
            miUniversidad += miAlumno1;
            Alumno miAlumno2 = new Alumno(2, "Carla", "Rodriguez", "34567765", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            try
            {
                miUniversidad += miAlumno2;
                Assert.Fail("Deberia avisar que el alumno es repetido");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }


        [TestMethod]
        public void ValidarExceptionDniInvalido()
        {
            Universidad miUniversidad = new Universidad();
            try
            {
                Alumno miAlumno = new Alumno(2, "Georgina", "Villamonte", "-17283387", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
                miUniversidad += miAlumno;
                Assert.Fail("Deberia avisar que el dni es invalido");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        [TestMethod]
        public void ValidarValoresNulos()
        {
                Universidad miUniversidad = new Universidad();
                Assert.IsNotNull(miUniversidad);
        }

    }
}
