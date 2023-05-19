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

        [Fact]
        public void GetSummary_Should_ReturnGamesOrderedByTotalScoreOrCreatedDate()
        {
            var games = _getNewGames();

            foreach (var game in games) 
            {
                _scoreBoard.StartGame(game);
            }


            IEnumerable<Game> currentGames = _scoreBoard.GetGamesSummary();

            Assert.NotNull(currentGames);
            Assert.Equal(5, currentGames.Count());
            Assert.Collection(games, 
                    g => {
                        Assert.Equal("Uruguay", g.HomeTeam.Name);
                        Assert.Equal("Italy", g.AwayTeam.Name);
                    },
                    g => {
                        Assert.Equal("Spain", g.HomeTeam.Name);
                        Assert.Equal("Brazil", g.AwayTeam.Name);
                    },
                    g => {
                        Assert.Equal("Mexico", g.HomeTeam.Name);
                        Assert.Equal("Canada", g.AwayTeam.Name);
                    },
                    g => {
                        Assert.Equal("Argentina", g.HomeTeam.Name);
                        Assert.Equal("Australia", g.AwayTeam.Name);
                    },
                    g => {
                        Assert.Equal("Germany", g.HomeTeam.Name);
                        Assert.Equal("France", g.AwayTeam.Name);
                    }
                    );
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

        private IEnumerable<Game> _getNewGames()
        {
            return new List<Game>()
            {
                new Game()
                {
                    HomeTeam = new Team()
                    {
                        Name = "Mexico"
                    },
                    AwayTeam = new Team()
                    {
                        Name = "Canada"
                    },
                    ScoreHomeTeam = 0,
                    ScoreAwayTeam = 5,
                    TotalScore = 5,
                    CreatedDate = DateTime.Now.AddDays(-5),
                },
                new Game()
                {
                    HomeTeam = new Team()
                    {
                        Name = "Spain"
                    },
                    AwayTeam = new Team()
                    {
                        Name = "Brazil"
                    },
                    ScoreHomeTeam = 10,
                    ScoreAwayTeam = 2,
                    TotalScore = 12,
                    CreatedDate = DateTime.Now.AddDays(-4),
                },
                new Game()
                {
                    HomeTeam = new Team()
                    {
                        Name = "Germany"
                    },
                    AwayTeam = new Team()
                    {
                        Name = "France"
                    },
                    ScoreHomeTeam = 2,
                    ScoreAwayTeam = 2,
                    TotalScore = 4,
                    CreatedDate = DateTime.Now.AddDays(-3),
                },
                 new Game()
                {
                    HomeTeam = new Team()
                    {
                        Name = "Uruguay"
                    },
                    AwayTeam = new Team()
                    {
                        Name = "Italy"
                    },
                    ScoreHomeTeam = 6,
                    ScoreAwayTeam = 6,
                    TotalScore = 12,
                    CreatedDate = DateTime.Now.AddDays(-2),
                },
                 new Game()
                {
                    HomeTeam = new Team()
                    {
                        Name = "Argentina"
                    },
                    AwayTeam = new Team()
                    {
                        Name = "Australia"
                    },
                    ScoreHomeTeam = 3,
                    ScoreAwayTeam = 1,
                    TotalScore = 4,
                    CreatedDate = DateTime.Now.AddDays(-1),
                }
            };
        }

        #endregion
    }
}
