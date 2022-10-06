using Microsoft.AspNetCore.Mvc;
using GroceryCRUDDemo.Models;

namespace GroceryCRUDDemo.Controllers
{
    public class ProductController : Controller
    {
        //List all products

        public IActionResult Index()
        {
            //List<Product> prods = DAL.GetAllProducts();
            //return View();
            //OR
            return View(DAL.GetAllProducts());
            
        }

        //Display detail for a single product
        public IActionResult Detail(int id)
        {
            return View(DAL.GetOneProduct(id));
        }

        // Add a product requires two routes
        // 1. a route to send the form to the browser
        // 2. A route the browser calls when the form is submitted
        public IActionResult AddForm()
        {
            List<Category> cats = DAL.GetAllCategories();
            return View(cats);
        }

        public IActionResult Add(Product prod)
        {
            //Validation: if a field is blank, set a message for it
            // and send them back to the form
            //Always validate on *both* sides --
            // 1. The browswe, client side
            // 2. the server side
            bool isValid = true;
            if (prod.name == null)
            {
                ViewBag.NameMessage = "Name is required.";
                isValid = false;

            }
            if (prod.description == null)
            {
                ViewBag.DescMessage = "Description is required";
                isValid = false;
            }
            if (prod.price <= 0)
            {
                ViewBag.PriceMessage = "Price must be greater than 0";
                isValid=false;
            }

            if (isValid)
            {
                DAL.InsertProduct(prod);
                return Redirect("/product");
            }
            else
            {

                List<Category> cats = DAL.GetAllCategories();
                ViewBag.Name = prod.name;
                ViewBag.Description = prod.description;
                ViewBag.Price = prod.price;
                ViewBag.Inventory = prod.inventory;
                return View("AddForm", cats);
            }

            //DAL.InsertProduct(prod);
            //return Redirect("/product");
        }


        //Deleted a product
        // This one won't return a view. Instead it will redirect 
        // back to the index/product
        public IActionResult Delete(int id)
        {
            DAL.DeleteProduct(id);
            return Redirect("/product");
        }


        //Edit a product needs two routes
        // 1. a route to send the form (prepopulated) to the browser
        // 2. A route that does the update and redirects to index. 
        public IActionResult EditForm(int id)
        //{
        //    Product prod = DAL.GetOneProduct(id);
        //    return View (id);
        {
            //ViewBag.Categories   (same thing)
            ViewData["categories"] = DAL.GetAllCategories();
            return View(DAL.GetOneProduct(id));
        }

        public IActionResult SaveChanges(Product prod)
        {
            DAL.UpdateProduct(prod);
            return Redirect("/product");
        }
    }
}
