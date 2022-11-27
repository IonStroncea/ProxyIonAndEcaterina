using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace DataBaseWriter
{
    public class DBWriter
    {
        public List<string> connectionStrings;
        public List<DBRequest> requests = new List<DBRequest>();

        public DBWriter(List<string> connectionStrings)
        {
            this.connectionStrings = connectionStrings;

            Thread thread = new Thread(VerifyRequests);
            thread.Start();
        }

        private void VerifyRequests()
        {
            while (true)
            {
                if (requests.Count() > 0)
                {
                    ExecuteRequest();
                }
                else
                {
                    Thread.Sleep(10);
                }
            }
        }

        public void AddRequest(DBRequest request)
        {
            Console.WriteLine("Added request");
            requests.Add(request);
        }

        private void ExecuteRequest()
        {
            Console.WriteLine("Execute");
            requests.Sort();

            DBRequest request = requests.First();
            requests.Remove(request);

            foreach (string connectiostring in connectionStrings)
            {
                Thread thread = new Thread(() => WriteDB(connectiostring, request));
                try
                {
                    thread.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void WriteDB(string connString, DBRequest request)
        {
            Console.WriteLine("Write");
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(request.Procedure, conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (Request param in request.parameters)
                    {
                        SqlParameter paramSql = new SqlParameter();
                        if (param.type == (int)SqlDbType.Int)
                        {
                            JsonElement element = (JsonElement)param.value;
                            int result = (int)element.GetDecimal();
                            paramSql = new SqlParameter(param.name, result);
                        }
                        else
                        {
                            paramSql = new SqlParameter(param.name, ((JsonElement)param.value).GetString());
                        }

                        cmd.Parameters.Add(paramSql);
                    }

                    int rows = cmd.ExecuteNonQuery();

                    Console.WriteLine("Rows " + rows);

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
}
