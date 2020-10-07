using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallengeAsp.Models
{
    public class PlayerSponsor
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int SponsorId { get; set; }
        public Sponsor Sponsor { get; set; }


    }
}
