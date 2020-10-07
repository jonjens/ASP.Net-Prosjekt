using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallengeAsp.Models
{
    public class Test
    {

        public int Number(int number)
        {

            int secretNumber;

            if (number > 10)
            {
                secretNumber = number + 10;
                return secretNumber;

            }
            else
            {
                return number;
            }

        }

    }
}
