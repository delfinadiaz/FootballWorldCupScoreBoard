using FootballWorldCupScoreBoard.Library.Interfaces;

namespace FootballWorldCupScoreBoard.Library.DomainEntities
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

        public IEnumerable<Game> GetGamesSummary()
        {
            return Games.OrderByDescending(g => g.TotalScore).ThenByDescending( g => g.CreatedDate);
        }
    }
}