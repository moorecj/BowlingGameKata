using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata.Tests
{

    [TestFixture]
    class BowlingGameTest
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }


        [Test]
        public void GameClass_ShouldExist()
        {
            Game game = new Game();
            Assert.That(game, Is.Not.Null);

        }

        [Test]
        public void RollingAllZerosShouldScoreZero()
        {

            RollMany(0, 20);

            Assert.That(game.Score(), Is.EqualTo(0));
         

        }

        private void RollMany( int pinValue, int numberOFRolls )
        {
            for (var i = 0; i < numberOFRolls; ++i)
            {
                game.Roll( pinValue );
            }
        }

        [Test]
        public void RollingAllOnesShouldScoreTwenty()
        {

            RollMany(1, 20);

            Assert.That(game.Score(), Is.EqualTo(20));


        }

        [Test]
        public void RollingAllTwosShouldScoreForty()
        {

            RollMany(2,20);

            Assert.That(game.Score(), Is.EqualTo(40));


        }

        [Test]
        public void RollingSomeSparesShouldAddNextRollToScore()
        {
            game.Roll(7);
            game.Roll(3);
            game.Roll(2);

            Assert.That(game.Score(), Is.EqualTo(14));
        }

        [Test]
        public void RollingAStrikeShouldAddNextTwoRollsToScore()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(5);

            Assert.That(game.Score(), Is.EqualTo(26));
        }

        [Test]
        public void RollingATurkeyshouldScoreSixty()
        {
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);

            Assert.That(game.Score(), Is.EqualTo(60));
        }

        [Test]
        public void RollingAllStrikesShouldResultInThreeHundred()
        {
            RollMany(10, 12);

            Assert.That(game.Score(), Is.EqualTo(300));

        }


    }

}
