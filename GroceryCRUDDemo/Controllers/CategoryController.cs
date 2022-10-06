using Microsoft.AspNetCore.Mvc;
using GroceryCRUDDemo.Models;

namespace GroceryCRUDDemo.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            List<Category> cats = DAL.GetAllCategories();
            return View(cats);
        }

        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult Add(Category cat)
        {
            DAL.InsertCategory(cat);
            return Redirect("/category");
        }

        // For detail page, we have to decide how to write our code.
        // We have some choices for the URL.
        // We could listed for a url like this:
        //  https://localhost:7034/category/detail/FRUIT
        // and get tje IF from the last "folder"
        // or we could listen for a url like this:
        //  https://localhost:7034/category/detail?id=FRUIT
        // where we get the ID from the query parameters
        // But in fact, the code we're going to write will
        // work for either type of URL!

        public IActionResult Detail(string id)
        {
            //return Content(id);
            Category cat = DAL.GetOneCategory(id);
            return View(cat);
        }

        public IActionResult ConfirmDelete(string id)
        {
            Category cat = DAL.GetOneCategory(id);
            //ViewData["categoryid"] = id;
            //Dont need this line anymore since we're using
            return View(cat);
        }

        public IActionResult Delete(string id)
        {
            
            DAL.DeleteCategory(id);
            return Redirect("/category");
        }

        public IActionResult EditForm(string id)
        {
            Category cat = DAL.GetOneCategory(id);
            return View(cat);
        }

        public IActionResult SaveChanges(Category cat)
        {
            DAL.UpdateCategory(cat);
            //return Content(cat.id);
            return Redirect("/category");
        }
    }
}
