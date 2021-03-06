﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;
using ZooApp.ViewModels;

namespace ZooApp.MvcClient.Controllers
{
    public class FoodController : Controller
    {
        FoodService service = new FoodService();
        // GET: Food
        public ActionResult Index()
        {
            var viewFoods = service.GetAll();
            return View(viewFoods);
        }

        // GET: Food/Details/5
        public ActionResult Details(int id)
        {
            ViewFood viewFood = service.Get(id);
            return View(viewFood);
        }

        // GET: Food/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Food/Create
        [HttpPost]
        public ActionResult Create(Food food)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var save = service.Save(food);
                    if (save)
                    {
                        return RedirectToAction("Index");
                    }
                    // TODO: Add insert logic here

                    return View(food);
                }
                catch
                {
                    return View(food);
                }
            }
            return View(food);
        }

        // GET: Food/Edit/5
        public ActionResult Edit(int id)
        {
            Food food = service.GetDbModel(id);
            return View(food);
        }

        // POST: Food/Edit/5
        [HttpPost]
        public ActionResult Edit(Food food)
        {
            try
            {
                var updated = service.Update(food);
                if (updated)
                {

                    return RedirectToAction("Index");
                }
                return View(food);

            }
            catch
            {
                return View(food);
            }
        }

        // GET: Food/Delete/5
        public ActionResult Delete(int id)
        {
            Food food = service.GetDbModel(id);

            return View(food);
        }

        // POST: Food/Delete/5
        [HttpPost]
        public ActionResult Delete(Food food)
        {
            try
            {
                var delete = service.Delete(food);
                if (delete)
                {
                    return RedirectToAction("Index");
                }

                return View(food);
            }
            catch
            {
                return View(food);
            }
        }
    }
}
