using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wedstrijdplannenmvc.Models
{
    public class TeamWedstrijd
    {
        public int TeamId { get; set; }
        public Team team { get; set; }

        public int WedstrijdId { get; set; }
        public Wedstrijd Westrijd { get; set; }
    }
}
