using System.Web.Mvc;
using EFCodeFirstPaoloTest.Entities;
using EFCodeFirstPaoloTest.Models;
using EFCodeFirstPaoloTest.Services.Interfaces;
using EFCodeFirstPaoloTest.Services.Mapper;

namespace EFCodeFirstPaoloTest.Controllers
{
    public class PlayersController : Controller
    {
        //private LeagueDbContext  db = new LeagueDbContext();

        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;
        public PlayersController(IPlayerService playerService, ITeamService teamService)
        {
            _playerService = playerService;
            _teamService = teamService;
        }

        // GET: Players
        public ActionResult Index()
        {
            var players = _playerService.GetAll();
            return View(players);
        }

        // GET: Players/Details/5
        public ActionResult Details(int id)
        {
            var player = _playerService.GetById(id);
            if (player == null)
                return HttpNotFound();

            //this is just to test the automapper
            var playerVM = MapperService.Map<Player, PlayerVm>(player);

            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(_teamService.GetAll(), "TeamId", "Name");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerId,Name,Surname,Height,Weight,TeamId")] Player player)
        {
            if (ModelState.IsValid)
            {
                _playerService.Save(player);
                //db.Players.Add(player);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(_teamService.GetAll(), "TeamId", "Name", player.TeamId);
            return View(player);
        }

        // GET: Players/Edit/5
        //[OutputCache(Duration = 60, VaryByParam = "id", Location = OutputCacheLocation.Client)]
        public ActionResult Edit(int id)
        {
            var player = _playerService.GetById(id);
            if (player == null)
            {
                return HttpNotFound();
            }

            //ViewBag.TeamId = new SelectList(_teamService.GetAll(), "TeamId", "Name", player.TeamId, "select");
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerId,Name,Surname,Height,Weight,TeamId")] Player player)
        {
            if (ModelState.IsValid)
            {
                _playerService.Update(player);
                //db.Entry(player).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.TeamId = new SelectList(_teamService.GetAll(), "TeamId", "Name", player.TeamId, "select");
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int id)
        {
            var player = _playerService.GetById(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var player = _playerService.GetById(id);
            _playerService.Delete(id);
            //db.Players.Remove(player);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
