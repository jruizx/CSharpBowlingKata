using System;
using Bowling;
using Xunit;

namespace BowlingTests
{
    public class GameTests
    {
        Game game;
        public GameTests() {
            game = new Game();
        }
        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }
        private void RollStrike()
        {
            game.Roll(10);
        }

        [Fact]
        public void TerribleGame()
        {
            RollMany(20, 0);
            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, game.Score());
        }
        
        [Fact]
        public void OneSpare()
        {
            RollSpare();
            game.Roll(3);
            RollMany(17, 0);
            Assert.Equal(16, game.Score());
        }

        [Fact]
        public void OneStrike()
        {
            RollStrike(); 
            game.Roll(3);
            game.Roll(4);
            RollMany(17, 0);
            Assert.Equal(24, game.Score());
        }

        [Fact]
        public void PerfectGame() {
            RollMany(12, 10);
            Assert.Equal(300, game.Score());
        }

    }
}
