using Microsoft.AspNetCore.Mvc;
using moto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moto.Controllers
{
    public class MotorcycleController : Controller
    {
        private readonly IMotoManager motoManager;

        public MotorcycleController(IMotoManager motoManager)
        {
            this.motoManager = motoManager;
        }

        public IActionResult Get(Motors motor)
        {
            ViewBag.Motor = motoManager.GetFromDb(motor.IdMoto);

            return View();
        }

        public IActionResult List()
        {
            ViewBag.Motors = motoManager.ListFromDb();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Motors motor)
        {
            Motors motors = motor;
            motors.Status = 1;
            motoManager.AddToDb(motor);
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Edit(Motors motor)
        {
            ViewBag.Motor = motoManager.GetFromDb((int)motor.IdMoto);
            return View();
        }

        [HttpPost]
        public IActionResult Editing(Motors motor)
        {
            motoManager.EditToDb(motor);
            return View();
        }

        public IActionResult Delete(Motors motor)
        {
            motoManager.DeleteFromDb(motor.IdMoto);
            return View();
        }

        [HttpPost]
        public IActionResult Buy(Orders order)
        {
            motoManager.AddOrder(order);
            return View();
        }

        [HttpPost]
        public IActionResult Sold(Motors motor)
        {
            ViewBag.MotoId = (int)motor.IdMoto;
            ViewBag.MotoValue = (float)motor.Value;
            return View();
        }
    }
}
