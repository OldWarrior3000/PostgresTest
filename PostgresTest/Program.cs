using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgresTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = GetPassword();
            SelectPostgres(password);
        }

        private static string GetPassword()
        {
            Console.WriteLine("Please enter your password: ");
            return Console.ReadLine();
        }

        private static void SelectPostgres(string password)
        {
            var connString = $"Host=192.168.0.220;Username=dr;Password={password};Database=documentmanagement";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Insert some data
                //using (var cmd = new NpgsqlCommand())
                //{
                //    cmd.Connection = conn;
                //    cmd.CommandText = "INSERT INTO documents (EntryNo) VALUES (@EntryNo)";
                //    cmd.Parameters.AddWithValue("EntryNo", 1);
                //    cmd.ExecuteNonQuery();
                //}

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT * FROM documents", conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            Console.WriteLine(reader.GetString(0));
            }
        }
    }
}
