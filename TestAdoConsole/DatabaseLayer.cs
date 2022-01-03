using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdoConsole
{
    public class DatabaseLayer
    {
        public static string connstr = "Server=(localdb)\\mssqllocaldb;Database=aspnet-TestApp-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true";

        public static void PrintList()
        {
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var command = $"Select * from PersonalDetails";
                using (SqlCommand cmd = new(command,connection))
                {
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var id = rdr["Id"].ToString();
                        var name = rdr["Name"].ToString();
                        var mobile = rdr["Mobile"].ToString();
                        Console.WriteLine($"Id: {id} & Name: {name} & mobile: {mobile}");
                    }
                    connection.Close();
                }
            }
        }
        public static void PrintSingle(int Id=1)
        {
            if (Id > 0)
            {
                using (SqlConnection conn = new SqlConnection(connstr))
                {
                    var command = $"Select * from PersonalDetails where Id = {Id}";
                    using (SqlCommand cmd = new SqlCommand(command,conn))
                    {
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var id = reader["Id"].ToString();
                            var name = reader["Name"].ToString();
                            var mobile = reader["Mobile"].ToString();
                            Console.WriteLine($"Id:{id} | Name:{name} | Moble: {mobile}");
                        }
                        conn.Close();
                    }
                }
            }
        }
        public static void EditSingle(int Id = 1, string Name="no name", string Mobile="no mobile")
        {
            var command = $"Update PersonalDetails Set Name = '{Name}', Mobile = '{Mobile}' where Id = {Id}";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand(command,conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public static void InsertSingle(string Name, string Mobile)
        {
            var command = $"Insert into PersonalDetails (Name,Mobile) values ('{Name}','{Mobile}')";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using(SqlCommand cmd = new SqlCommand(command, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public static void DeleteSingle(int Id)
        {
            var command = $"Delete from PersonalDetails where Id = {Id}";
            using(SqlConnection conn=new SqlConnection(connstr))
            {
                using(SqlCommand cmd = new SqlCommand(command, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
