using emtSoft.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLPcpModelApp.Models
{
    public class Persona : BaseInsUpd
    {
        public int IdPersona { get; set; }

        public string Codigo { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;

        public string Apellido1 { get; set; } = string.Empty;

        public string Apellido2 { get; set; } = string.Empty;

        public string CampoNuevo { get; set; } = string.Empty;

        public DateTime FechaNacimiento { get; set; } = Constants.DateDefaultValue;
        [IgnorarEnParam]
        public int Edad => BLLUtils.CalcEdad(this.FechaNacimiento);
    }


    public class PersonaGetParams 
    {
        public int IdPersona { get; set; }

        //public string DesdeCodigo { get; set; } = string.Empty;

        //public string HastaCodigo { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        //public string Apellido1 { get; set; } = string.Empty;

        //public string Apellido2 { get; set; } = string.Empty;

        //public DateTime DesdeFechaNacimiento { get; set; } = Constants.DateDefaultValue;

        //public DateTime HastaFechaNacimiento { get; set; } = Constants.DateDefaultValue;
    }

}
