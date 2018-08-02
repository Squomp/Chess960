using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpChess.Model.Tests
{
    [TestClass]
    public class Chess960Test
    {
        #region Tests for 960 board setup
    
        /// <summary>
        ///     Test to make sure order is randomized for Chess960
        /// </summary>
        [TestMethod]
        public void RandomizedTest()
        {
            string testString = "rnbqkbnr";
            string scrambled = Utils.Implement960(testString);
            Assert.IsTrue(testString != scrambled);
        }

        /// <summary>
        ///     Test to make sure bishops are placed on opposite colors
        /// </summary>
        [TestMethod]
        public void BishopsOppositeColorTest()
        {
            string testString = "rnbqkbnr";
            string scrambled = Utils.Implement960(testString);

            int firstBishop = scrambled.IndexOf('b');
            int lastBishop = scrambled.LastIndexOf('b');
            Assert.AreNotEqual(firstBishop % 2, lastBishop % 2);
        }

        /// <summary>
        ///     Test to make sure king is placed between the two rooks
        /// </summary>
        [TestMethod]
        public void KingBetweenRooksTest()
        {
            string testString = "rnbqkbnr";
            string scrambled = Utils.Implement960(testString);

            int firstRook = scrambled.IndexOf('r');
            int lastRook = scrambled.LastIndexOf('r');
            int king = scrambled.IndexOf('k');
            Assert.IsTrue(firstRook < king && king < lastRook);
        }

        /// <summary>
        ///     Test to make sure the black side is a mirrored version of the white side
        /// </summary>
        [TestMethod]
        public void SidesMirroredTest()
        {
            string[] gameString = Fen.GameStartPosition960.Split('/');
            string fristHomeRow = gameString[0];
            string secondHomeRow = gameString[gameString.Length - 1];
            secondHomeRow = secondHomeRow.Substring(0, secondHomeRow.IndexOf(' '));

            Assert.AreEqual(fristHomeRow.ToLower(), secondHomeRow.ToLower());
        }

        #endregion

        #region Tests for Regular board setup

        /// <summary>
        ///     Test to make sure Traditional setup is correct order
        /// </summary>
        [TestMethod]
        public void CorrectOrderTest()
        {
            string expected = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            string actual = Fen.GameStartPosition;
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
