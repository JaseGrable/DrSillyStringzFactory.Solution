using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

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
            ViewBag.PageTitle = "All Machines";
            return View(model);
        }
        public ActionResult Create()
        {
            ViewBag.PageTitle = "Add Machine";
            return View();
        }
        [HttpPost]
        public ActionResult Create(Machine machine)
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
        public ActionResult Details(int id)
        {
            Machine thisMachine = _db.Machines
                            .Include(machine => machine.JoinEntities)
                            .ThenInclude(join => join.Engineer)
                            .FirstOrDefault(machine => machine.MachineId == id);
            ViewBag.PageTitle = "Machine Details";
            return View(thisMachine);
        }
        public ActionResult Edit(int id)
        {
            Machine thisMachine = _db.Machines
                            .FirstOrDefault(machine => machine.MachineId == id);
            ViewBag.PageTitle = "Edit Machine";
            return View(thisMachine);
        }
        [HttpPost]
        public ActionResult Edit(Machine machine)
        {
            _db.Machines.Update(machine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Machine thisMachine = _db.Machines
                            .FirstOrDefault(machine => machine.MachineId == id);
            ViewBag.PageTitle = "Delete Machine";
            return View(thisMachine);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Machine thisMachine = _db.Machines
                            .FirstOrDefault(machine => machine.MachineId == id);
            _db.Machines.Remove(thisMachine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddEngineer(int id)
        {
            Machine thisMachine = _db.Machines
                            .FirstOrDefault(machines => machines.MachineId == id);
            List<Engineer> engineers = _db.Engineers.ToList();
            SelectList engineerList = new SelectList(engineers, "EngineerId", "EngineerName");
            ViewBag.PageTitle = "Add Machine to Engineer";
            ViewBag.EngineerId = engineerList;
            return View(thisMachine);
        }
        [HttpPost]
        public ActionResult AddEngineer(Machine machine, int engineerId)
        {
#nullable enable
            EngineerMachine? joinEntity = _db.EngineerMachines
                                .FirstOrDefault(join => (join.EngineerId == engineerId && join.MachineId == machine.MachineId));
#nullable disable
            if (joinEntity == null && engineerId != 0)
            {
                _db.EngineerMachines.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = machine.MachineId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = machine.MachineId });
        }
    }
}
