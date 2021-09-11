using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wedstrijdplannenmvc.Models
{
    public class Team
    {
        public Team() { }
        public Team(string Naam, int punten,int doelpuntentegen,int doelpuntenvoor, int doelsaldo, int wedstrijdengespeeld) {
            this.Naam = Naam;
            this.punten = punten;
            this.doelpuntentegen = doelpuntentegen;
            this.doelpuntenvoor = doelpuntenvoor;
            this.doelsaldo = doelsaldo;
            this.wedstrijdengespeeld = wedstrijdengespeeld;         
        }
        [Key]
        public int Id { get; set; }
        public string Naam { get; set; }
        public int punten { get; set; }
        public int doelpuntentegen { get; set; }
        public int doelpuntenvoor { get; set; }
        public int doelsaldo { get; set; }

        public int wedstrijdengespeeld { get; set; }

        public ICollection<TeamWedstrijd> TeamWedstrijd { get; set; }



    }
}
