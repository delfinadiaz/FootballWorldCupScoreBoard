using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace FootballWorldCupScoreBoard.UnitTests
{
    public class ScoreBoardUnitTest
    {
        private IScoreBoard _scoreBoard;

        public ScoreBoardUnitTest()
        {
            _scoreBoard = new ScoreBoard();
        }

        [Fact]
        public void StartGame_Should_AddGameToTheBoard()
        {
            var game = new Game()
            {
                HomeTeam = "Mexico",
                AwayTeam = "Canada"
            };

            var gameAdded = _scoreBoard.StartGame(game);

            IEnumerable<Game> currentGames = _scoreBoard.GetGames();

            Assert.NotNull(currentGames);
            Assert.Contains(gameAdded, currentGames);
        }

        [Fact]
        public void FinishGame_Should_RemoveGameFromTheBoard()
        {
            var game = new Game()
            {
                HomeTeam = "Mexico",
                AwayTeam = "Canada"
            };

            var newGame = _scoreBoard.StartGame(game);

            _scoreBoard.FinishGame(newGame);

            IEnumerable<Game> currentGames = _scoreBoard.GetGames();

            Assert.DoesNotContain(game, currentGames);
        }
    }
}
