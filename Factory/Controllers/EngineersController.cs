using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Engineer> allEngineers = _db.Engineers.OrderBy(e => e.Name).ToList();
      return View(allEngineers);
    }

    [HttpGet]
    public ActionResult Details(int id)
    {
        Engineer thisEngineer = _db.Engineers
            .Include(e => e.JoinEntities)
            .ThenInclude(join => join.Machine)
            .FirstOrDefault(e => e.EngineerId == id);
        return View(thisEngineer);
    }


    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
        _db.Engineers.Add(engineer);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

     public ActionResult AddMachine(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(e => e.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines,"MachineId","Name");
      return View(thisEngineer);      
    }
    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int MachineId)
    {
      if (MachineId != 0)
      {
        if (_db.EngineerMachine.Any(join => join.MachineId == MachineId && join.EngineerId == engineer.EngineerId) == false)
        {
          _db.EngineerMachine.Add(new EngineerMachine() { MachineId = MachineId, EngineerId = engineer.EngineerId});
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = engineer.EngineerId});
    }
  }
}