using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace wedstrijdplannenmvc.Models
{
    public class SeedData
    {

        public void SeedDatabase()
        {
            CompetitieContext context = new CompetitieContext();

            if (context.Teams.Count() == 0)
            {
                List<Team> teams = loadjsonTeams();

                foreach (Team thuisteam in teams)
                {

                    foreach (Team uitteam in teams)
                    {
                        if (uitteam != thuisteam)
                        {

                            Wedstrijd wedstrijd = new Wedstrijd();
                            wedstrijd.teamwedstrijd = new List<TeamWedstrijd>();
                            wedstrijd.thuisteam = thuisteam.Naam;

                            TeamWedstrijd teamwedstrijdthuis = new TeamWedstrijd();
                            teamwedstrijdthuis.team = thuisteam;
                            wedstrijd.teamwedstrijd.Add(teamwedstrijdthuis);

                            TeamWedstrijd teamwedstrijduit = new TeamWedstrijd();
                            teamwedstrijduit.team = uitteam;
                            wedstrijd.teamwedstrijd.Add(teamwedstrijduit);

                            wedstrijd.datum = DateTime.Now;
                            wedstrijd.thuisteamuitslag = String.Empty;
                            wedstrijd.uitteamuitslag = String.Empty;

                            context.Add(wedstrijd);
                            // wedstrijden.Add(wedstrijd);

                            //TeamWedstrijd teamwedstrijdwedstrijd = new TeamWedstrijd();
                            //teamwedstrijdwedstrijd.Westrijd = wedstrijd;

                            //uitteam.TeamWedstrijd.Add(teamwedstrijdwedstrijd);
                            //thuisteam.TeamWedstrijd.Add(teamwedstrijdwedstrijd);

                        }
                    }
                }
                context.AddRange(teams);
                context.SaveChanges();
            }


        }
        private static List<Team> loadjsonTeams()
        {
            using (StreamReader r = new StreamReader("Data/Teams.json"))
            {
                string json = r.ReadToEnd();
                List<Team> ListOfTeams = JsonConvert.DeserializeObject<List<Team>>(json);
                // int teamId = 1;
                foreach (Team team in ListOfTeams)
                {
                    //team.Id = teamId;
                    //teamId++;
                }

                return ListOfTeams;
            }
        }


    }
}
