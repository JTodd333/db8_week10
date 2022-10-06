using Microsoft.AspNetCore.Mvc;
using BookClubProject.Models;

namespace BookClubProject.Controllers
{
    public class PersonController : Controller
    {
        //List all Persons at index
        public IActionResult Index()
        {

            return View(DAL.GetAllPeople());
        }

        //Details for one person
        public IActionResult Detail(int id)
        {
            ViewData["presentation"] = DAL.GetAllPresentations().ToList();  
            //above line only needed if wanting to show presentations
            return View(DAL.GetOnePerson(id));
        }

        //Add Form and Add Action
        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult Add(Person per)
        {
            bool isValid = true;
            if(per.FirstName == null)
            {
                ViewBag.FNMessage = "First name is required.";
                isValid = false;
            }
            if(per.LastName == null)
            {
                ViewBag.LNMessage = "Last name is required.";
                isValid = false;
            }
            if(per.Email == null || per.Email.Contains("@") == false)
            {
                ViewBag.EmailMessage = "Email is required and must contain @.";
                isValid = false;
            }
            if (isValid)
            {
                DAL.AddPerson(per);
                return Redirect("/person");
            }
            else
            {
                ViewBag.FirstName = per.FirstName;
                ViewBag.LastName = per.LastName;
                ViewBag.Email = per.Email;
                return View("AddForm");
            }

            //DAL.AddPerson(per);
            //return Redirect("/person");
        }

        //Edit Form and Save
        public IActionResult EditForm(int id)
        {
            return View(DAL.GetOnePerson(id));
        }
        public IActionResult SaveChanges(Person per)
        {
            DAL.UpdatePerson(per);
            return Redirect("/person");
        }

        //Delete Confirm and Delete
        public IActionResult ConfirmDelete(int id)
        {
            ViewData["presentation"] = DAL.GetAllPresentations().ToList();
            Person per = DAL.GetOnePerson(id);
            return View(per);
        }
        public IActionResult Delete(int id)
        {
            DAL.DeletePerson(id);
            return Redirect("/person");
        }


    }
}
