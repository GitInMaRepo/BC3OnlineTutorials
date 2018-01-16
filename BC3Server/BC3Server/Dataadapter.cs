using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC3Server
{
    public class Dataadapter
    {
        public const string tablePath = @"C:/temp/MySQLiteDBC3.s3db";

        public System.Data.IDbConnection OpenDbConnection()
        {
            SQLiteConnection conn = new SQLiteConnection($"Data Source={tablePath}");
            conn.Open();

            return conn;
        }

        public void InsertPerson(Person person)
        {
            string addDataCommand =
            $"INSERT INTO Person (Id, Name, Vorname)" +
            $" VALUES ({person.id}, '{person.Data}', '{person.Data1}')";

            using (var conn = new SQLiteConnection($"Data Source={tablePath}"))
            {
                conn.Open();

                SQLiteCommand insertCmd = new SQLiteCommand(conn)
                {
                    CommandText = addDataCommand
                };

                insertCmd.ExecuteNonQuery();
            }
        }

        public Person SelectPerson(int id)
        {
            string selectDataCommand =
            $"Select * From Person Where Id = {id}";

            using (var conn = new SQLiteConnection($"Data Source={tablePath}"))
            {
                conn.Open();

                SQLiteCommand selectCmd = new SQLiteCommand(conn)
                {
                    CommandText = selectDataCommand
                };

                using (var reader = selectCmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        throw new Exception("All dinosaurs went extinct!");
                    }
                    reader.Read();
                    var result = new Person
                    {
                        id = reader[0].ToString(),
                        Data = (string)reader[1],
                        Data1 = (string)reader[2]
                    };

                reader.Close();

                return result;
                }
            }
        }
    }
}
