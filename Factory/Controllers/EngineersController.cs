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
        Engineer thisEngineer = _db.Engineers//this produces a list of patient objects from the database
            .Include(e => e.JoinEntities)//this loades the join entities property of each patient
            .ThenInclude(join => join.Machine)//this loads the doctor of each DoctorPatient relationship
            .FirstOrDefault(e => e.EngineerId == id);//this specifies which patient from the database were working with
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
  }
}