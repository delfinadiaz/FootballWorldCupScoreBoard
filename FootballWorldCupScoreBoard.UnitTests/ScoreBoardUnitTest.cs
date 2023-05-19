using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FootballWorldCupScoreBoard.Library.Interfaces;
using FootballWorldCupScoreBoard.Library.DomainEntities;
using System.Linq;

namespace FootballWorldCupScoreBoard.UnitTests
{
    public class ScoreBoardUnitTest
    {
        private IScoreBoard _scoreBoard;
        private int _scoreHomeTeam = 0;
        private int _scoreAwayTeam = 0;

        public ScoreBoardUnitTest()
        {
            _scoreBoard = new ScoreBoard();
        }

        [Fact]
        public void StartGame_Should_AddGameToTheBoard()
        {
            var game = _getNewGame();

            var gameAdded = _scoreBoard.StartGame(game);

            IEnumerable<Game> currentGames = _scoreBoard.GetGames();

            Assert.NotNull(currentGames);
            Assert.Contains(gameAdded, currentGames);
        }

        [Fact]
        public void FinishGame_Should_RemoveGameFromTheBoard()
        {
            var game = _getNewGame();

            var newGame = _scoreBoard.StartGame(game);

            _scoreBoard.FinishGame(newGame);

            IEnumerable<Game> currentGames = _scoreBoard.GetGames();

            Assert.DoesNotContain(game, currentGames);
        }

        [Fact]
        public void UpdateScore_Should_UpdateScoresFromTheBoard()
        {
            var game = _getNewGame();

            var newGame = _scoreBoard.StartGame(game);

            newGame.UpdateScore(++_scoreHomeTeam, _scoreAwayTeam);
            newGame.UpdateScore(++_scoreHomeTeam, _scoreAwayTeam);
            newGame.UpdateScore(_scoreHomeTeam, ++_scoreAwayTeam);

            IEnumerable<Game> currentGames = _scoreBoard.GetGames();

            var gameUpdated = currentGames.Where( g => g.HomeTeam == newGame.HomeTeam && g.AwayTeam == newGame.AwayTeam).FirstOrDefault();

            Assert.NotNull(gameUpdated);
            Assert.Equal(2, gameUpdated?.ScoreHomeTeam);
            Assert.Equal(1, gameUpdated?.ScoreAwayTeam);
            Assert.Equal(3, gameUpdated?.TotalScore);
        }

        #region Arrange

        private Game _getNewGame()
        {
           return new Game()
            {
                HomeTeam = new Team()
                {
                    Name = "Mexico"
                },
                AwayTeam = new Team()
                {
                    Name = "Canada"
                }
            };
        }

        #endregion
    }
}
