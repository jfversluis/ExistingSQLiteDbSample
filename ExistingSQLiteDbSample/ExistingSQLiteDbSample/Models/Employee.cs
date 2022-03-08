using System;
using SQLite;

namespace ExistingSQLiteDbSample.Models
{
    [Table("employees")]
    public class Employee
    {
        [AutoIncrement, PrimaryKey]
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
