using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFileIO
{
    class ADODisconnected
    {

        static void Main(string[] args)
        {
            ADODisconnected a = new ADODisconnected();
            a.UpdateDisconnected(ConfigurationManager.ConnectionStrings["ADODemoConnection"].ConnectionString);
            Console.ReadLine();
        }

        void UpdateDisconnected(string connectionString)
        {
            using (SqlConnection connection =
               new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdpater = new SqlDataAdapter(
                  "SELECT EMPNO, EMPNAME, SALARY, DEPTNO from employee",
                  connection);

                dataAdpater.UpdateCommand = new SqlCommand(
                   "UPDATE employee SET SALARY = @salary " +
                   "WHERE EMPNO = @EMPNO", connection);

                dataAdpater.UpdateCommand.Parameters.Add(
                   "@Salary", SqlDbType.Decimal, 10, "SALARY");

                SqlParameter parameter = dataAdpater.UpdateCommand.Parameters.Add(
                  "@EMPNO", SqlDbType.Int);

                parameter.SourceColumn = "EMPNO";
                parameter.SourceVersion = DataRowVersion.Original;

                DataTable employeeTable = new DataTable();
                dataAdpater.Fill(employeeTable);
                //changing category name to new beverages
                DataRow employeeRow = employeeTable.Rows[0];
                employeeRow["SALARY"] = 50000;

                //updating the data adapter
                dataAdpater.Update(employeeTable);

                Console.WriteLine("Rows after update.");
                foreach (DataRow row in employeeTable.Rows)
                {
                    {
                        Console.WriteLine("{0}: {1} {2}", row[0], row[1], row[2]);
                    }
                }
            }
        }
    }
}
