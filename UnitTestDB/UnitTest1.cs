using AspNetCore;
using CodingChallengeAsp.Controllers;
using CodingChallengeAsp.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;


namespace UnitTestDB
{
    public class Tests
    {

        [OneTimeSetUp]

        public void OneTimeSetup()
        {
            using(FootballContext context = new FootballContext())
            {
                context.Database.Migrate();

                context.Database.EnsureCreated();

            }
        }


        [SetUp]
        public void Setup()
        {

            using (var context = new FootballContext())
            {

                context.RemoveRange(context.Player);
                context.RemoveRange(context.Team);


                context.SaveChanges();
            }

        }

        [Test]
        public void Test1()
        {


        }
    }
}