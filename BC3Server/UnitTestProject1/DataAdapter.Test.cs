﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SQLite;
using BC3Server;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public const string tableCreationCommand =
                                @"CREATE TABLE Person (
                                                        Id int
                                                        , Name varchar(255)
                                                        , Vorname varchar(255))";

        public const string addDataCommand =
                                @"INSERT INTO Person (
                                                        Id
                                                        , Name
                                                        , Vorname)
                                                        VALUES 
                                                        (1, 'T-Rex', 'Hans')
                                                        , (2, 'Triceratops', 'Anja')
                                                        , (3, 'Procompsognathus', 'Heiko')";

        [TestMethod]
        public void TDatenbankOeffnenUndSchliessen()
        {
            var dataAdapter = new Dataadapter();
            var conn = dataAdapter.OpenDbConnection();

            Assert.IsTrue(conn.State == System.Data.ConnectionState.Open);

            conn.Close();
            Assert.IsTrue(conn.State == System.Data.ConnectionState.Closed);
        }

        public static void OnlyCreateTable()
        {
            string tablePath = @"C:/temp/MySQLiteDBC3.s3db";
            SQLiteConnection conn = new SQLiteConnection($"Data Source={tablePath}");
            SQLiteCommand create = new SQLiteCommand(conn);
            create.CommandText = tableCreationCommand;
            conn.Open();
            create.ExecuteNonQuery();
        }

        [TestMethod]
        public void TDatenbank_Insert()
        {
            var dataAdapter = new Dataadapter();
            dataAdapter.DeletePersons();

            dataAdapter.InsertPerson(new Person { id = "1", Vorname = "T_Rex", Nachname = "Hans" });

            var result = dataAdapter.SelectPerson(1);

            Assert.IsNotNull(result);
        }


        [Ignore]
        [TestMethod]
        public void TDatenbank_CreateTable()
        {
            OnlyCreateTable();
        }

        [TestMethod]
        public void TDatenbank_DeletePersons()
        {
            var dataAdapter = new Dataadapter();
            dataAdapter.InsertPerson(new Person { id = "1", Vorname = "T_Rex", Nachname = "Hans" });
            dataAdapter.InsertPerson(new Person { id = "2", Vorname = "Müller", Nachname = "Max" });
            dataAdapter.InsertPerson(new Person { id = "3", Vorname = "Meier", Nachname = "Tom" });

            dataAdapter.DeletePersons();

            List<Person> result = dataAdapter.SelectPersons();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TDatenbank_SelectPersons()
        {
            var dataAdapter = new Dataadapter();
            dataAdapter.DeletePersons();

            dataAdapter.InsertPerson(new Person { id = "1", Vorname = "T_Rex", Nachname = "Hans" });
            dataAdapter.InsertPerson(new Person { id = "2", Vorname = "Müller", Nachname = "Max" });
            dataAdapter.InsertPerson(new Person { id = "3", Vorname = "Meier", Nachname = "Tom" });

            List<Person> result = dataAdapter.SelectPersons();
            Assert.AreEqual(3, result.Count);
        }

    }
}
