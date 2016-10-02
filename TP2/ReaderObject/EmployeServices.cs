using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderObject
{
    class EmployeServices
    {

        public static Employe HydrateEmploye(OracleDataReader readerEmploye)
        {
            var employe = new Employe();
            employe.NumEmp = Convert.ToInt16(readerEmploye["NUMEMP"]);
            employe.NomEmp = readerEmploye["NOMEMP"] as string;
            employe.PrenomEmp = readerEmploye["PRENOMEMP"] as string;
            employe.Poste = readerEmploye["POSTE"] as string;
            employe.Salaire = Convert.ToSingle(readerEmploye["SALAIRE"]);
            if (readerEmploye["PRIME"] == DBNull.Value) employe.Prime = null;
                else employe.Prime = Convert.ToInt16(readerEmploye["PRIME"]);
            employe.CodeProjet = readerEmploye["CODEPROJET"] as string;
            if (readerEmploye["SUPERIEUR"] == DBNull.Value) employe.Prime = null;
            else employe.Prime = Convert.ToInt16(readerEmploye["SUPERIEUR"]);

            return employe;
        }
        /// <summary>
        /// Retourne une liste de tous les employés
        /// </summary>
        /// <returns></returns>
        public List<Employe> findAllEmploye()
        {
            List<Employe> employees = new List<Employe>();
            String oracledb = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id = molinarisql; Password = sio; ";

            using (OracleConnection CnOracle = new OracleConnection(oracledb)) 
            {
                try
                {
                    using (OracleCommand cmdTousLesEmployes = new OracleCommand("SELECT * FROM EMPLOYE", CnOracle))
                    {
                        CnOracle.Open();
                        OracleDataReader readerEmploye = cmdTousLesEmployes.ExecuteReader();
                        while (readerEmploye.Read()) { }
                        {
                            Employe employe = HydrateEmploye(readerEmploye);
                            employees.Add(employe);
                        }
                        readerEmploye.Close();
                    }
                    CnOracle.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
             
                }
                return employees;
            }

        }

        public Employe findEmployeById(int id)
        {
            Employe emp = null;
            String oracledb = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id = molinarisql; Password = sio; ";
            using (OracleConnection CnOracle = new OracleConnection(oracledb))
            {
                try
                {
                    using (OracleCommand cmdTousLesEmployes = new OracleCommand("SELECT * FROM EMPLOYE WHERE NUMEMP= :numemp", CnOracle))
                    {
                        OracleParameter pId = new OracleParameter("numemp", OracleDbType.Int16, System.Data.ParameterDirection.Input);
                        pId.Value = id;
                        cmdTousLesEmployes.Parameters.Add(pId);
                        CnOracle.Open();
                        OracleDataReader readerEmploye = cmdTousLesEmployes.ExecuteReader();
                        if (readerEmploye.Read())
                        {
                            emp = HydrateEmploye(readerEmploye);

                        }
                        readerEmploye.Close();
                    }
                    CnOracle.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return emp;
            }
        }
    }
}
