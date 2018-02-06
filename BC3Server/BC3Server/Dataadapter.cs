using System;
using System.Collections.Generic;
using System.Data.SQLite;

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
            $" VALUES ({person.id}, '{person.Nachname}', '{person.Vorname}')";

            using (var conn = OpenDbConnection())
            {
                SQLiteCommand cmd = CreateCommand(addDataCommand, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public Person SelectPerson(int id)
        {
            string selectDataCommand =
            $"Select * From Person Where Id = {id}";
            using (var conn = OpenDbConnection())
            {
                SQLiteCommand selectCmd = CreateCommand(selectDataCommand, conn);


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
                        Vorname = (string)reader[1],
                        Nachname = (string)reader[2]
                    };

                    reader.Close();

                    return result;
                }
            }
        }

        public List<Person> SelectPersons()
        {
            string selectDataCommand =
            $"Select * From Person";

            using (var conn = OpenDbConnection())
            {
                SQLiteCommand cmd = CreateCommand(selectDataCommand, conn);

                var resultList = new List<Person>();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var result = new Person
                        {
                            id = reader[0].ToString(),
                            Vorname = (string)reader[1],
                            Nachname = (string)reader[2]
                        };

                        resultList.Add(result);
                    }
                    reader.Close();

                    return resultList;
                }
            }
        }

        public void DeletePersons()
        {
            string dataCommand =
            $"Delete From Person";

            using (var conn = OpenDbConnection())
            {
                SQLiteCommand cmd = CreateCommand(dataCommand, conn);
                cmd.ExecuteNonQuery();

            }
        }

        private static SQLiteCommand CreateCommand(string dataCommand, System.Data.IDbConnection conn)
        {
            return new SQLiteCommand(conn as SQLiteConnection)
            {
                CommandText = dataCommand
            };
        }
    }
}
