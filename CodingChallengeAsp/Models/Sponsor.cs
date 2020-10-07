using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallengeAsp.Models
{
    public class Sponsor
    {
        [Key]
        public int SponsorId { get; set; }

        public string Name { get; set; }

        public IList<PlayerSponsor> PlayerSponsor { get; set; }



    }
}
