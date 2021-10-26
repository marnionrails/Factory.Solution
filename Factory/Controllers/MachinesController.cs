using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
      List<Machine> allMachines = _db.Machines.OrderBy(m => m.Name).ToList();
      return View(allMachines);
    }

    [HttpGet]
    public ActionResult Details(int id)
    {
        Machine thisMachine = _db.Machines
            .Include(m => m.JoinEntities)
            .ThenInclude(join => join.Engineer)
            .FirstOrDefault(m => m.MachineId == id);
        return View(thisMachine);
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public ActionResult Create(Machine machine)
    {
        _db.Machines.Add(machine);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(m => m.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers,"EngineerId","Name");
      return View(thisMachine);      
    }
    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int engineerId)
    {
      if (engineerId != 0)
      {
        if (_db.EngineerMachine.Any(join => join.EngineerId == engineerId && join.MachineId == machine.MachineId) == false)
        {
          _db.EngineerMachine.Add(new EngineerMachine() { MachineId = machine.MachineId, EngineerId = engineerId});
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = machine.MachineId});
    }


  }
}