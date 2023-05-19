using FootballWorldCupScoreBoard.Library.DomainEntities;
using FootballWorldCupScoreBoard.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FootballWorldCupScoreBoard.UnitTests
{
    public class ScoreBoardUnitTest
    {
        private IScoreBoard _scoreBoard;
        private int _scoreHomeTeam = 0;
        private int _scoreAwayTeam = 0;
        private string _uruguay = "Uruguay";
        private string _italy = "Italy";
        private string _spain = "Spain";
        private string _brazil = "Brazil";
        private string _mexico = "Mexico";
        private string _canada = "Canada";
        private string _argentina = "Argentina";
        private string _australia = "Australia";
        private string _germany = "Germany";
        private string _france = "France";

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
        public void GetSummary_Should_ReturnGamesOrderedByTotalScoreAndCreatedDate()
        {
            var games = _getNewGames();

            foreach (var game in games) 
            {
                _scoreBoard.StartGame(game);
            }


            IEnumerable<Game> currentGames = _scoreBoard.GetGamesSummary();

            Assert.NotNull(currentGames);
            Assert.Equal(5, currentGames.Count());
            Assert.Collection(currentGames, 
                    g => {
                        Assert.Equal(_uruguay, g.HomeTeam.Name);
                        Assert.Equal(_italy, g.AwayTeam.Name);
                    },
                    g => {
                        Assert.Equal(_spain, g.HomeTeam.Name);
                        Assert.Equal(_brazil, g.AwayTeam.Name);
                    },
                    g => {
                        Assert.Equal(_mexico, g.HomeTeam.Name);
                        Assert.Equal(_canada, g.AwayTeam.Name);
                    },
                    g => {
                        Assert.Equal(_argentina, g.HomeTeam.Name);
                        Assert.Equal(_australia, g.AwayTeam.Name);
                    },
                    g => {
                        Assert.Equal(_germany, g.HomeTeam.Name);
                        Assert.Equal(_france, g.AwayTeam.Name);
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
                    Name = _mexico
                },
                AwayTeam = new Team()
                {
                    Name = _canada
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
                        Name = _mexico
                    },
                    AwayTeam = new Team()
                    {
                        Name = _canada
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
                        Name = _spain
                    },
                    AwayTeam = new Team()
                    {
                        Name = _brazil
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
                        Name = _germany
                    },
                    AwayTeam = new Team()
                    {
                        Name = _france
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
                        Name = _uruguay
                    },
                    AwayTeam = new Team()
                    {
                        Name = _italy
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
                        Name = _argentina
                    },
                    AwayTeam = new Team()
                    {
                        Name = _australia
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
