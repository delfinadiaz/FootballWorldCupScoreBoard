using System;
using System.Collections.Generic;

namespace FootballWorldCupScoreBoard.UnitTests
{
    public class ScoreBoard : IScoreBoard
    {
        public IEnumerable<Game> GetGames()
        {
            throw new NotImplementedException();
        }

        public Game StartGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void FinishGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}