using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Configuration;
using System.Data.SqlClient;

namespace ReaderObject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // String en local
                String oracledb = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id = molinarisql; Password = sio; ";
                // String à utiliser en cours
                //String oracledb = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.10.2.10)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=SLAM)));User Id = molinarisql; Password = sio; ";

                String connectionString = oracledb;
                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = oracledb;
                connection.Open();

                List<Employe> LesEmployes = new List<Employe>();
                OracleCommand command = new OracleCommand("SELECT * FROM EMPLOYE",connection);
                OracleDataReader reader;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
      
                    LesEmployes.Add(new Employe(Convert.ToInt16(reader["NUMEMP"]),
                        reader["NOMEMP"] as String,
                        reader["PRENOMEMP"] as String,
                        reader["POSTE"] as String ,
                        Convert.ToSingle(reader["SALAIRE"]),
                        reader["Prime"] == DBNull.Value ?  Convert.ToSingle(reader["SALAIRE"]) : 0
                        ));
    
                }
                foreach (var employe in LesEmployes)
                {
                    Console.WriteLine(employe.ToString());
                }

                reader.Close();
                connection.Close();
                Console.ReadKey();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }


        }
    }
}
