using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220304
{
    internal class Program
    {
        public static string connectionString =
            "Server = winsql.verebely.dc; " +
            "Database = diak17; " +
            "Uid = diak17; " +
            "Pwd = 4jGQsb;";
        static void Main()
        {
            InsertNew();
            Console.Clear();
            SelectAll();

            Console.ReadKey(true);
        }

        private static void InsertNew()
        {
            Console.Write("új hülyegyerek neve: ");
            var nev = Console.ReadLine();
            Console.Write("új hülyegyerek kora: ");
            var kor = Console.ReadLine();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var adapter = new MySqlDataAdapter()
                {
                    InsertCommand = new MySqlCommand(
                        $"INSERT INTO teszt (nev, kor) VALUES ('{nev}', {kor});",
                        connection),
                };
                adapter.InsertCommand.ExecuteNonQuery();
            }
        }

        static void SelectAll()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var reader = new MySqlCommand(
                    cmdText: "SELECT * FROM teszt;",
                    connection: connection)
                    .ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]}");
                }
            }
        }
    }
}
