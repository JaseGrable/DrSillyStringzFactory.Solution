using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
    public class MachinesController : Controller
    {
        private readonly FactoryContext _db;

        public MachinesController(FactoryContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Machine> model = _db.Machines.ToList();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            Machine thisMachine = _db.Machines
              .Include(machine => machine.JoinEntities)
              .ThenInclude(join => join.Engineer)
              .FirstOrDefault(machine => machine.MachineId == id);
            return View(thisMachine);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MachinesController machine)
        {
            if (!ModelState.IsValid)
            {
                return View(machine);
            }
            else
            {
                _db.Machines.Add(machine);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult AddEngineer(int id)
        {
            Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
            ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
            return View(thisMachine);
        }

        [HttpPost]
        public ActionResult AddEngineer(Machines machines, int engineerId)
        {
            EngineerMachine joinEntity = _db.EngineerMachines.FirstOrDefault(joinEntity => (joinEntity.EngineerId == engineerId && joinEntity.MachineId == machine.MachineId));
            if (joinEntity == null && engineerId != 0)
            {
                _db.EngineerMachines.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = machine.MachineId })
            }
            return RedirectToAction("Details", new { id = machines.MachineId });
        }

        public ActionResult Edit(int id)
        {
            Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
            returns View(thisMachine);
        }
    }
}