using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLLPcpModelApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLPcpModelApp.Models;

namespace BLLPcpModelApp.Tests
{
    [TestClass()]
    public class PersonasTests
    {
        [TestMethod()]
        public void InsUpdPersonaTest()
        {
            var persona = CreatePersona();
            var mensajeError = string.Empty;
            var id = -1;
            try
            {
                id = BLLPcpModel_App.InsUpdPersona(persona);
            }
            catch (Exception e)
            {

                mensajeError = e.Message;
            }

            Assert.IsTrue(id>0, mensajeError);
        }

        [TestMethod()]
        public void GerPersonasTest()
        {

            var mensajeError = string.Empty;
            var searchParam = new PersonaGetParams()
            {
                Nombres ="Pedro"
            };
            IEnumerable<Persona> result = null;
            try
            {
                result = BLLPcpModel_App.GetPersonas(searchParam);
            }
            catch (Exception e)
            {
                mensajeError = e.Message;
            }

            Assert.IsTrue(result.Count()==0, $"No se obtuvieron resultados de la busqueda ver el mensaje con mas detalles {mensajeError}");
        }

        private Persona CreatePersona()
        {
            var persona = new Persona
            {
                Codigo = "002",
                Nombres = "Pedro",
                Apellido1 = "Guerrero",
                Apellido2 = "Batista",
                Usuario = "BllTest",
            };
            
            return persona;
        }
    }
}