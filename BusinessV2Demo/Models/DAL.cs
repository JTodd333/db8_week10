using Dapper.Contrib.Extensions;
using Dapper;
using MySql.Data.MySqlClient;

namespace BusinessV2Demo.Models
{
    public class DAL
    {
        //We moved this to appsettings.json and Program.cs files now
        //public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=businessv2;Uid=root;Pwd=abc123;");
        public static MySqlConnection DB;

        public static List<Employee> GetAllEmployees()
        {
            return DB.GetAll<Employee>().ToList();
        }

        public static Employee GetOneEmployee(int id)
        {
            return DB.Get<Employee>(id);
        }

        public static Employee AddEmployee(Employee emp)
        {
            DB.Insert(emp);
            return emp;
        }

    }
}
