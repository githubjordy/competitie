using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wedstrijdplannenmvc.Models
{
    public class SortTeams:IComparer<TeamWedstrijd>
    {

        //private readonly int Id;
        //public SortTeams(int Id) {
        //    this.Id = Id;        
        //}
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(TeamWedstrijd x, TeamWedstrijd y)
        {
            if (x.team.Naam == x.Westrijd.thuisteam) { return 1; }
            return -1;
           // return ((new CaseInsensitiveComparer()).Compare(y, x));
        }



    }
}
