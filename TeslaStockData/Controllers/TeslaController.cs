using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeslaStockData.Models;
using TeslaStockData.Repository;

namespace TeslaStockData.Controllers
{
    public class TeslaController : Controller
    {

       public readonly ITeslaRepo teslaRepo;
        public TeslaController(ITeslaRepo repository)
        {
            this.teslaRepo = repository;
        }
        

        public ActionResult GetStockData(int currentPageIndex)
        {

            ModelState.Clear();
            

            return View(teslaRepo.GetStockData(currentPageIndex));
        }
    
        public ActionResult AddStockData()
        {
            return View("AddStockData");
        }

        [HttpPost]
        public ActionResult AddStockData(TeslaModel teslaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
       

                    if (teslaRepo.AddStockData(teslaModel))
                    {
                        ViewBag.Message = "Stock data added successfully";
                    }
                }

                return View("AddStockData");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

        public ActionResult Chart()
        {

            return View();
        }

        [HttpGet]
        public JsonResult NewChart()
        {
            
            ModelState.Clear();
          
            return Json(teslaRepo.GetStockData(0), JsonRequestBehavior.AllowGet);
        }


        public ActionResult EditStockData(int id)
        {
            

            return View(teslaRepo.GetStockData(1).Find(data => data.Id == id));

        }

        [HttpPost]

        public ActionResult EditStockData(int id, TeslaModel obj)
        {
            try
            {
                teslaRepo.UpdateStockData(obj);

                return RedirectToAction("GetStockData", new { currentPageIndex = 1 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }
      
   

        public ActionResult DeleteStockData(int id)
        {
            try
            {
               
                if (teslaRepo.DeleteStockData(id))
                {
                    ViewBag.AlertMsg = "Stock data deleted successfully";

                }
                return RedirectToAction("GetStockData", new { currentPageIndex =1});

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

    }
}