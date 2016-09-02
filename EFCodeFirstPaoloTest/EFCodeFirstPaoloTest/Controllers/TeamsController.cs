using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFCodeFirstPaoloTest.Context;
using EFCodeFirstPaoloTest.Entities;
using EFCodeFirstPaoloTest.Services.Interfaces;

namespace EFCodeFirstPaoloTest.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamService _teamService;
        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // GET: Teams
        public ActionResult Index()
        {
            var teams = _teamService.GetAll();
            return View(teams);
        }

        // GET: Teams/Details/5
        public ActionResult Details(int id)
        {
            var team = _teamService.GetById(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamId,Name,Color")] Team team)
        {
            if (ModelState.IsValid)
            {
                _teamService.Save(team);
                return RedirectToAction("Index");
            }

            return View(team);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var team = _teamService.GetById(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamId,Name,Color")] Team team)
        {
            if (ModelState.IsValid)
            {
                _teamService.Update(team);
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int id)
        {
            var team = _teamService.GetById(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var team = _teamService.GetById(id);

            if (team != null)
                _teamService.Delete(id);
            else
                return HttpNotFound();

            return RedirectToAction("Index");
        }
    }
}
