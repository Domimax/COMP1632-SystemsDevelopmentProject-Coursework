using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsDevProject.Model
{
    public class Agency : User
    {
        public int AgencyID { get; set; }
        public string AgencyName { get; set; }

        public Agency(int agencyID, string agencyName)
        {
            AgencyID = agencyID;
            AgencyName = agencyName;
        }

        public Agency(string agencyName)
        {
            AgencyName = agencyName;
        }
    }
}
