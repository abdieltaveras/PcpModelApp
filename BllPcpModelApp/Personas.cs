using BLLPcpModelApp.Models;
using emtSoft.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLPcpModelApp
{
    public static partial  class BLLPcpModel_App
    {
        public static int InsUpdPersona(Persona insUpdParam)
        {
            var insParam = SearchRec.ToSqlParams(insUpdParam);
            var dt = Database.DataServer.ExecSelSP("spInsUpdPersona",insParam );
            return BLLUtils.GetIdFromDt(dt);
        }

        public static IEnumerable<Persona> GetPersonas(PersonaGetParams getParam)
        {
            var searchParam = SearchRec.ToSqlParams(getParam);
            var result= Database.DataServer.ExecReaderSelSP<Persona>("spGetPersonas",searchParam);
            return result;
        }

    }
}
