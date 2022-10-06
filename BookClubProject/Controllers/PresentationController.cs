using BookClubProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookClubProject.Controllers
{
    public class PresentationController : Controller
    {
        //List all presentations
        public IActionResult Index()
        {
            List<Presentation> pres = DAL.GetAllPresentations();
            return View(pres);
        }

        //Details on one 
        public IActionResult Detail(int id)
        {
            ViewData["person"] = DAL.GetAllPeople().ToList();
            return View(DAL.GetOnePresentation(id));
        }

        //Add One
        public IActionResult AddForm()
        {
            List<Person> pers = DAL.GetAllPeople();
            return View(pers);
        }
        public IActionResult Add(Presentation pres)
        {
            bool isValid = true;
            if(pres.PresentationDate.ToString() == "1/1/0001 12:00:00 AM")
            {
                ViewBag.DateMessage = "Please choose a date.";
                isValid = false;
            }
            if (pres.BookTitle == null)
            {
                ViewBag.TitleMessage = "Title is required.";
                isValid = false;

            }
            if (pres.BookAuthor == null)
            {
                ViewBag.AuthorMessage = "Author is required";
                isValid = false;
            }
            if (pres.Genre == null)
            {
                ViewBag.GenreMessage = "Genre is required";
                isValid = false;
            }

            if (isValid)
            {
                DAL.AddPresentaion(pres);
                return Redirect("/presentation");
            }
            else
            {

                List<Person> pers = DAL.GetAllPeople();
                ViewBag.BookTitle = pres.BookTitle;
                ViewBag.BookAuthor = pres.BookAuthor;
                ViewBag.Genre = pres.Genre;
                return View("AddForm", pers);
            }

        }

        //Edit Form and Save
        public IActionResult EditForm(int id)
      
        {
            //ViewBag.Categories   (same thing)
            ViewData["person"] = DAL.GetAllPeople();
            return View(DAL.GetOnePresentation(id));
        }
        public IActionResult SaveChanges(Presentation pres)
        {
            DAL.UpdatePresentation(pres);
            return Redirect("/presentation");
        }

        //Delete
        public IActionResult Delete(int id)
        {
            DAL.DeletePresentation(id);
            return Redirect("/presentation");
        }

    }
}
