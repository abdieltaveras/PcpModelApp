using emtSoft.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLPcpModelApp.Models
{
    

    public class BaseInsUpd
    {
        [IgnorarEnParam]
        public string InsertadoPor { get; set; } = string.Empty;
        [IgnorarEnParam]
        public DateTime FechaInsertado { get; set; } = Constants.DateDefaultValue;

        [IgnorarEnParam]
        public string ModificadoPor { get; internal set; } = string.Empty;
        [IgnorarEnParam]
        public DateTime FechaModificado { get; set; } = Constants.DateDefaultValue;

        [NotMapped]
        public string Usuario { get; set; } = string.Empty;
    }
}
