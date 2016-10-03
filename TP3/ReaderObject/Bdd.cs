using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderObject
{
    class Bdd
    {
        public OracleConnection CnOracle { get; set; }

        public Bdd()
        {
            String ch = String.Format(
                ConfigurationManager.ConnectionStrings["oracle"].ToString(), 
                    ConfigurationManager.AppSettings["SERVEUR"], 
                    ConfigurationManager.AppSettings["PORT"], 
                    ConfigurationManager.AppSettings["SID"], 
                    ConfigurationManager.AppSettings["USERID"], 
                    ConfigurationManager.AppSettings["PWD"]);
            CnOracle = new OracleConnection(ch);
        }
    }
}
