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
            List<Employe> employes;
            EmployeServices serviceEmploye = new EmployeServices();
            employes = serviceEmploye.findAllEmploye();

                foreach (var employe in employes)
                {
                    Console.WriteLine(employe);
                }

            Employe unEmploye = serviceEmploye.findEmployeById(4);
            Console.WriteLine(unEmploye);

            Console.Read();
            }
          


        }
    }
