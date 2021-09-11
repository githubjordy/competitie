using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wedstrijdplannenmvc.Models
{
    public class Wedstrijd
    {
        [Key]
        public int Id { get; set; }
        public ICollection<TeamWedstrijd> teamwedstrijd { get; set; }
       // public Team uitteam { get; set; }
        public DateTime datum { get; set; }
        public string thuisteamuitslag { get; set; }

        public string uitteamuitslag { get; set; }

        public string thuisteam { get; set; }
    }
}
