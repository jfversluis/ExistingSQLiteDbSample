using System;
using System.Collections.Generic;
using System.IO;
using ExistingSQLiteDbSample.Models;
using SQLite;

namespace ExistingSQLiteDbSample.Data
{
    public class EmployeeRepository
    {
        private readonly SQLiteConnection _database;

        public static string DbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "chinook.db");

        public EmployeeRepository()
        {
            _database = new SQLiteConnection(DbPath);
            _database.CreateTable<Employee>();
        }

        public List<Employee> List()
        {
            return _database.Table<Employee>().ToList();
        }
    }
}
