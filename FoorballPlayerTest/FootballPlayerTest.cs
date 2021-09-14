using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballPlayerLib;
using System;

namespace FoorballPlayerLibTest
{
    [TestClass]
    public class FootballPlayerTest
    {
        FootballPlayer player;

        [TestMethod]
        public void Constructor_Valid()
        {
            player = new FootballPlayer(1, "Henrik Høltzer", 12000, 1);
            Assert.AreEqual(1, player.Id);
            Assert.AreEqual("Henrik Høltzer", player.Name);
            Assert.AreEqual(12000, player.Price);
            Assert.AreEqual(1, player.ShirtNumber);

            // test on the 4 length limit. Should be able to create with 4 characters
            player = new FootballPlayer(1, "Henr", 12000, 1);

        }



        // CONSTRUCTOR NAME TESTS
        [TestMethod]
        public void Constructor_InvalidName() 
        {
            try
            {
                // Name too short for constraints
                player = new FootballPlayer(1, "Hen", 12000, 1);
                Assert.Fail();
            }
            catch ( ArgumentException e ) 
            { 
                Assert.AreEqual("Name must be at least 4 characters", e.Message); 
            }
        }

        [TestMethod]
        public void Constructor_EmptyName() 
        {
            try
            {
                player = new FootballPlayer(1, "", 12000, 1);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Name cannot be null or empty", e.Message);
            }
        }

        [TestMethod]
        public void Constructor_NullName()
        {
            try
            {
                player = new FootballPlayer(1, null, 12000, 1);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Name cannot be null or empty", e.Message);
            }
        }



        // CONSTRUCTOR PRICE TESTS
        [TestMethod]
        public void Constructor_PriceLimit()
        {
            try
            {
                player = new FootballPlayer(1, "Henrik Høltzer", 0, 1);
                Assert.Fail();
            }
            catch ( ArgumentException e )
            {
                Assert.AreEqual("Price must be above 0", e.Message);
            }
        }

        [TestMethod]
        public void Constructor_PriceAboveLimit()
        {
            player = new FootballPlayer(1, "Henrik Høltzer", 1, 1);
        }

        [TestMethod]
        public void Constructor_PriceBelowLimit()
        {
            try
            {
                player = new FootballPlayer(1, "Henrik Høltzer", -1, 1);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Price must be above 0", e.Message);
            }
        }

        

        // CONSTRUCTOR SHIRT NUMBER TESTS
        [TestMethod]
        public void Constructor_LowerLimit()
        {
            player = new FootballPlayer(1, "Henrik Høltzer", 100, 1);

        }

        [TestMethod]
        public void Constructor_BelowLowerLimit()
        {
            try
            {
                player = new FootballPlayer(1, "Henrik Høltzer", 100, 0);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Shirt Number must be between 1 to 100", e.Message);
            }
        }

        [TestMethod]
        public void Constructor_UpperLimit()
        {
            player = new FootballPlayer(1, "Henrik Høltzer", 100, 100);

        }

        [TestMethod]
        public void Constructor_AboveUpperLimit()
        {
            try
            {
                player = new FootballPlayer(1, "Henrik Høltzer", 100, 101);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Shirt Number must be between 1 to 100", e.Message);
            }
        }



        // CHANGING PROPERTIES TESTS
        [TestMethod]
        public void Player_ChangeNameValid()
        {
            player = new FootballPlayer(1, "Henrik Høltzer", 100, 1);
            player.Name = "Henrik";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Player_ChangeNameInvalid()
        {
            player = new FootballPlayer(1, "Henrik Høltzer", 100, 1);
            player.Name = "hek";
        }

        [TestMethod]
        public void Player_ChangePriceValid()
        {
            player = new FootballPlayer(1, "Henrik Høltzer", 100, 1);
            player.Price = 15;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Player_ChangePriceInvalid()
        {
            player = new FootballPlayer(1, "Henrik Høltzer", 100, 1);
            player.Price = -100;
        }

        [TestMethod]
        public void Player_ChangeShirtNumberValid()
        {
            player = new FootballPlayer(1, "Henrik Høltzer", 100, 1);
            player.ShirtNumber = 5;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Player_ChangeShirtNumberInvalid()
        {
            player = new FootballPlayer(1, "Henrik Høltzer", 100, 1);
            player.ShirtNumber = 200;
        }
    }
}
