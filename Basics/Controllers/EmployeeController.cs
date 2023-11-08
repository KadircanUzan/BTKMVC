using Basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class EmployeeController:Controller
    {
        public IActionResult Index1()
        {
            string message=$"Hello World.{DateTime.Now.ToString()}";
            return View("Index1",message);
        }

        public ViewResult Index2()
        {
            var names= new String[]
            {
                "Ahmet",
                "Kadircan",
                "Mehmet"
            };
            return View(names);
        }
        public IActionResult Index3()
        {
            var list= new List<Employee>()
            {
                new Employee(){Id=1,FirstName="Kadircan",LastName="Uzan",Age=29},
                new Employee(){Id=2,FirstName="Kaan",LastName="Uzan",Age=21},
                new Employee(){Id=3,FirstName="Demir",LastName="Kalim",Age=24},
            };
            return View("Index3",list);
        }

    }
}