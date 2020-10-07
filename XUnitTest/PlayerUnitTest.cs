using CodingChallengeAsp.Controllers;
using CodingChallengeAsp.Data;
using CodingChallengeAsp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTest
{
    class PlayerUnitTest
    {
        private PlayersController players;
        public static DbContextOptions<FootballContext> dbContextOptions { get; }
        public static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=FootballContext-a3477308-1212-4576-839c-c33821c2e20e;Trusted_Connection=True;MultipleActiveResultSets=true";

        static PlayerUnitTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<FootballContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
        public PlayerUnitTest()
        {
            var context = new FootballContext(dbContextOptions);
            TestDB db = new TestDB();
            db.Seed(context);

            players = new PlayersController(context);

        }
    }
}
