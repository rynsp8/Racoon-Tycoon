using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameTest1
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //-- Arrange
            player player1 = new player();
            player1.name = "Samwise";
            player1.playerposition = 1;
            player1.capital = 1;
            string expected = "Samwise";

            //-- Act

            string actual = player1.name;

            //-- Assert
            Assert.AreEqual(expected, actual);


        }
    }
}