using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CodingChallengeAsp.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ShirtNumber { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public IList<PlayerSponsor> PlayerSponsor { get; set; }


    }
}
