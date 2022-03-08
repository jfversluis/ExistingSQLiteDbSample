using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ExistingSQLiteDbSample.Data;
using ExistingSQLiteDbSample.Models;
using Xamarin.Forms;

namespace ExistingSQLiteDbSample
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

        public MainPage()
        {
            InitializeComponent();

            // TODO Only do this when app first runs
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("ExistingSQLiteDbSample.chinook.db"))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);

                    File.WriteAllBytes(EmployeeRepository.DbPath, memoryStream.ToArray());
                }
            }

            EmployeeRepository repository = new EmployeeRepository();
            foreach (var employee in repository.List())
            {
                Employees.Add(employee);
            }

            BindingContext = this;
        }
    }
}

