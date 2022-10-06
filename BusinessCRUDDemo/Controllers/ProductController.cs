using Microsoft.AspNetCore.Mvc;
using BusinessCRUDDemo.Models;

namespace BusinessCRUDDemo.Controllers
{
    public class ProductController : Controller
    {

        //List all products
        public IActionResult Index()
        {
            return View(DAL.GetAllProducts());
        }

        //Detail for one product
        public IActionResult Detail(int id)
        {
            return View(DAL.GetOneProduct(id));
;       }

        //Add Product Form and Actual Add
        //      Form:
        public IActionResult AddForm()
        {
            return View();
        }
        //      Adding:
        public IActionResult Add(Product prod)
        {
            DAL.AddProduct(prod);
            return Redirect("/product");
        }

        //Delete One
        public IActionResult Delete(int id)
        {
            DAL.DeleteProduct(id);
            return Redirect("/product");
        }

        //Edit a product. Form and Actual saved changes redirected.
        //      Form:
        public IActionResult EditForm(int id)
        {
            return View(DAL.GetOneProduct(id));
        }
        //      Save Changes:
        public IActionResult SaveChanges(Product prod)
        {
            DAL.UpdateProduct(prod);
            return Redirect("/product");
        }

    }
}
