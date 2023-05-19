﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballWorldCupScoreBoard.UnitTests
{
    public class ScoreBoard : IScoreBoard
    {
        public ScoreBoard()
        {
            Games = new List<Game>();
        }

        public List<Game> Games { get; set; }


        public IEnumerable<Game> GetGames()
        {
            return Games;
        }

        public Game StartGame(Game game)
        {
            Games.Add(game);
            return Games.Last();
        }

        public void FinishGame(Game game)
        {
            Games.Remove(game);
        }
    }
}