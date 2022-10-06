using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BookClubProject.Models
{
    public class DAL
    {
        public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=bookclub;Uid=root;Pwd=abc123; "); //convert zero datetime=True

        // Person DAL Methods

        public static List<Person> GetAllPeople()
        {
            return DB.GetAll<Person>().ToList();
        }

        public static Person GetOnePerson(int id)
        {
            return DB.Get<Person>(id);
        }

        public static Person AddPerson(Person per)
        {
            DB.Insert(per);
            return per;
        }

        //Update/Edit Person
        public static void UpdatePerson (Person per)
        {
            DB.Update(per);
        }

        //Delete Person
        public static void DeletePerson(int id)
        {
            DB.Execute("delete from presentation where PersonId =@perid", new {perid=id});
            Person per = new Person();
            per.id = id;
            DB.Delete<Person>(per);
        }


        //Presentation DAL Methods
        public static List<Presentation> GetAllPresentations()
        {
            return DB.GetAll<Presentation>().ToList();
        }
        public static Presentation GetOnePresentation(int id)
        {
            return DB.Get<Presentation>(id);
        }

        //Add/Insert
        public static Presentation AddPresentaion(Presentation pres)
        {
            DB.Insert(pres);
            return pres;
        }

        //Update/Edit Person
        public static void UpdatePresentation(Presentation pres)
        {
            DB.Update(pres);
        }

        public static void DeletePresentation(int id)
        {
            Presentation pres = new Presentation();
            pres.id = id;
            DB.Delete(pres);
        }
    }
}
