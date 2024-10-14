using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcDataViews.Models;

namespace MvcDataViews.Controllers
{
    public class PersonController : Controller
    {
        static List<Person> people = new List<Person>();
        public ActionResult Index()
        {
            return View(people);
        }

        
        public ActionResult Details(Person p)
        {
            return View(p);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person p)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", p);
                }

                people.Add(p);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            Person p = new Person();
            foreach (Person pn in people)
            {
                if (pn.Id == id)
                {
                    p.Name = pn.Name;
                    p.Age = pn.Age;
                    p.Id = pn.Id;
                    p.Phone = pn.Phone;
                    p.Email = pn.Email;
                }
            }

            return View(p);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person p)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", p);
            }
            foreach (Person pn in people)
            {
                if (pn.Id == p.Id)
                {
                    pn.Name = p.Name;
                    pn.Age = p.Age;
                    pn.Id = p.Id;
                    pn.Phone = p.Phone;
                    pn.Email = p.Email;
                }
            }
            return RedirectToAction("Index");


        }


        public ActionResult Delete(int id)
        {
            Person p = new Person();
            foreach (Person pn in people)
            {
                if (pn.Id == id)
                {
                    p.Name = pn.Name;
                    p.Age = pn.Age;
                    p.Id = pn.Id;
                    p.Phone = pn.Phone;
                    p.Email = pn.Email;

                    return View(p);
                }
            }

            return RedirectToAction("Index");




           
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Person p)
        {
            try
            {
                
                foreach (Person pn in people)
                {
                    if (pn.Id == p.Id)
                    {
                        people.Remove(pn);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
