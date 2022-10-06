using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BusinessCRUDDemo.Models
{
    public class DAL
    {
        public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=coffeeshopprac;Uid=root;Pwd=abc123;");

        //Read all
        public static List<Product> GetAllProducts()
        {
            return DB.GetAll<Product>().ToList();
        } 

        //Read One
        public static Product GetOneProduct(int id)
        {
            return DB.Get<Product>(id);
        }

        //Add New
        public static Product AddProduct(Product prod)
        {
            DB.Insert<Product>(prod);
            return prod;
        }

        //Delete
        public static void DeleteProduct(int id)
        {
            Product prod = new Product();
            prod.id = id;
            DB.Delete<Product>(prod);
        }

        //Update/Edit
        public static void UpdateProduct(Product prod)
        {
            DB.Update(prod);
        }

    }
}
