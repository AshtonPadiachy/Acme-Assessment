using EmployeeInfoWebApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EmployeeInfoWebApp.Service
{
    public class EmployeeDatabase
    {
        static SQLiteConnection Database;

        public static EmployeeDatabase Instance
        {
            get 
            {
                var instance = new EmployeeDatabase();
                CreateTableResult result = Database.CreateTable<Person>();
                return instance;

            }
        }

        public static class Constants
        {
            public const string DatabaseFilename = "EmployeeInfoWebAppSQLite.db3";

            public const SQLiteOpenFlags Flags =
                // open the database in read/write mode
                SQLiteOpenFlags.ReadWrite |
                // create the database if it doesn't exist
                SQLiteOpenFlags.Create |
                // enable multi-threaded database access
                SQLiteOpenFlags.SharedCache;

            public static string DatabasePath
            {
                get
                {
                    var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    return Path.Combine(basePath, DatabaseFilename);
                }
            }
        }
        public EmployeeDatabase()
        {
            Database = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        }

        public List<Person> GetPerson()
        {
            return Database.Table<Person>().ToList();
        }

        public List<Person> GetNoPerson()
        {
            return Database.Query<Person>("SELECT * FROM [Person] WHERE [Done] = 0");
        }

        public Person GetPerson(int personid)
        {
            return Database.Table<Person>().Where(i => i.PersonId == personid).FirstOrDefault();
        }

        public int SavePerson(Person person)
        {
            if(person.PersonId != 0)
            {
                return Database.Update(person);
            }
            else
            {
                return Database.Insert(person);
            }
        }

        public int DeletePerson(Person person)
        {
            return Database.Delete(person);
        }


    }
}
