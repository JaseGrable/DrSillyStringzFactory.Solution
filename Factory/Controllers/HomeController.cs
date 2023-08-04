using Microsoft.AspNetCore.Mvc;
using System.Collection.Generic;
using System.Linq
using Factory.Models;

namespace Factory.Controller
{
    public class HomeController : Controller
    {
        public readonly FactoryContext_db; 
        public HomeController(FactoryContext db)
        {
            _db = db;
        }


        [HttpGet("/")]
        {
            Engineer[] engineers = _db.Engineers.ToArray();
        Machine[] machines = _db.Machines.ToArray();
        Dictionary<string, object[]> model = new Dictionary<string, object[]>();
        model.Add("engineers", engineers);
            model.Add("machines", machines);
            return View(model);
    }
}
}