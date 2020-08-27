using emtSoft.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLPcpModelApp
{
    public partial class BLLUtils
    {
        /// <summary>
        /// extract id From a DataTable Object
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        internal static int GetIdFromDt(DataTable dt)
        {
            var result = -1;
            try
            {
                result = Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception e)
            {
                var mensaje = e.Message;
            }
            return result;
        }
        public static DateTime GetSvrDate()
        {
            var result = Database.DataServer.ExecQuery("select GetDate() as DT", "SysDate");
            var r = Convert.ToDateTime(result.Rows[0][0]);
            return r;
        }
        public static int CalcEdad(DateTime fechaNacimiento)
        {
            var endDate = GetSvrDate();
            var yr = endDate.Year - fechaNacimiento.Year-1;
            var valorASumar = (endDate.Month == fechaNacimiento.Month)  && (endDate.Day >= fechaNacimiento.Day) ? 1 : 0;
            if (valorASumar == 0)
            {
                valorASumar = (endDate.Month > fechaNacimiento.Month) ? 1 : 0;
            }

            yr += valorASumar;
            return yr < 0 ? 0 : yr;
        }
    }
}
