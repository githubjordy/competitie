using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using wedstrijdplannenmvc.Models;

namespace wedstrijdplannenmvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SeedData seeddata;
        private CompetitieContext competitieContext;
        public HomeController(ILogger<HomeController> logger, SeedData database, CompetitieContext competitie)
        {
            seeddata = database;
            _logger = logger;
            competitieContext = competitie;

        }

        public IActionResult Index()
        {
            seeddata.SeedDatabase();

            return View();
        }


        [HttpPost]
        public IActionResult ResetCompetitie()
        {
            List<Team> teams = competitieContext.Teams.ToList();
            List<Wedstrijd> wedstrijden = competitieContext.Wedstrijden.ToList();

            foreach (Team team in teams) {
                team.punten = 0;
                team.doelpuntentegen = 0;
                team.doelpuntenvoor = 0;
                team.doelsaldo = 0;
                team.wedstrijdengespeeld = 0;
            }

            foreach (Wedstrijd wedstrijd in wedstrijden) {
               
                wedstrijd.thuisteamuitslag = "";
                wedstrijd.uitteamuitslag = "";
            
            }

            competitieContext.SaveChanges();




            return View();
        }



        public IActionResult CompetitieStand()
        {
            List<Team> teams = competitieContext.Teams.ToList();
             teams = teams.OrderByDescending(x => x.punten).ThenByDescending(p => p.doelsaldo).ToList();
            return View(teams);
        }

        public IActionResult SpeelSchema()
        {
            List<Team> teams = competitieContext.Teams.ToList();

            return View(teams);
        }

        [HttpGet]
        public IActionResult ToonSchemaVoorTeam(int Id)
        {
            //Team thuisteam = competitieContext.Teams.Find(Id);
            //TeamWedstrijd teamwedstrijd = new TeamWedstrijd();
            //teamwedstrijd.team = thuisteam;

            List<int> wedstrijdenID = competitieContext.TeamWedstrijd.Where(x => x.TeamId == Id).Select(x => x.Westrijd.Id).ToList();
            List<TeamWedstrijd> teamwedstrijden = competitieContext.TeamWedstrijd.
                Where(t => wedstrijdenID.Contains(t.WedstrijdId)).Select(x => new TeamWedstrijd
                {
                    team = x.team,
                    Westrijd = x.Westrijd,
                    TeamId = x.TeamId,
                    WedstrijdId = x.WedstrijdId
                }).ToList(); ;


            //int thuisteamId = Id;
            //ViewData["thuisteam"] = thuisteamId;

            //var TeamWedstrijden = competitieContext.TeamWedstrijd.Where(x => x.TeamId == Id).Select(x => new TeamWedstrijd
            //{
            //    team = x.team,
            //    Westrijd = x.Westrijd,
            //    //TeamId = x.TeamId,
            //    TeamId = x.Westrijd,
            //    WedstrijdId = x.WedstrijdId
            //}).ToList();

            //.ToList();
            //var GroupedTeamwedstrijd = teamwedstrijden.GroupBy(y => y.WedstrijdId).ToList();
            // List<IGrouping<int,TeamWedstrijd>> w = teamwedstrijden.GroupBy(y => y.WedstrijdId).ToList();
            //Wedstrijd wedstrijd = wedstrijden[0]; groupby 

            //foreach (var group in GroupedTeamwedstrijd) {

            //    var z = group.Key;
            //    foreach (var user in group) {
            //        var naam = user.team.Naam;

            //    }


            //}
            //wedstrijd.
            // var wedstrijden = competitieContext.Wedstrijden.Find(teamwedstrijden);


            return View(teamwedstrijden);
        }


        [HttpPost]
        public IActionResult ToonSchemaVoorTeam(int uitteamId,int thuisteamId, int inputthuisteam, int inputuitteam, int wedstrijdId)
        {
           
            if (ModelState.IsValid) {

                Team uitteam = competitieContext.Teams.Find(uitteamId);
                Team thuisteam = competitieContext.Teams.Find(thuisteamId);
                Wedstrijd wedstrijd = competitieContext.Wedstrijden.Find(wedstrijdId);

                uitteam.doelpuntentegen += inputthuisteam;
                uitteam.doelpuntenvoor += inputuitteam;
                uitteam.doelsaldo += inputuitteam - inputthuisteam;
                uitteam.wedstrijdengespeeld += 1;
                //////////////////////////////////////////////////////////
                thuisteam.doelpuntentegen += inputuitteam;
                thuisteam.doelpuntenvoor += inputthuisteam;
                thuisteam.doelsaldo +=inputthuisteam- inputuitteam;
                thuisteam.wedstrijdengespeeld += 1;
                ///////////////////////////////////////////////////////
                wedstrijd.thuisteamuitslag = inputthuisteam.ToString() + " - " + inputuitteam.ToString();
                wedstrijd.uitteamuitslag =  inputuitteam.ToString() + " - " + inputthuisteam.ToString();
                var uitslagparse = wedstrijd.thuisteamuitslag.Split("-");
                // int res = Int32.Parse(uitslagparse[0]);

                if (Int32.Parse(uitslagparse[0]) < Int32.Parse(uitslagparse[1]))
                {
                    uitteam.punten +=3;
                }

                else if (Int32.Parse(uitslagparse[0]) > Int32.Parse(uitslagparse[1]))
                {
                    thuisteam.punten += 3;
                }

                else {
                    uitteam.punten += 1;
                    thuisteam.punten += 1;               
                }

                competitieContext.SaveChanges();
                //string x= "test";
                //var test = uitteamId;
                return RedirectToAction("SpeelSchema");
            }

            // [FromBody] IGrouping<int, TeamWedstrijd> group
            return RedirectToAction("SpeelSchema"); // hier eigenlijk error page
        }



            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
