using System.Collections.Generic;

namespace FootballWorldCupScoreBoard.UnitTests
{
    public interface IScoreBoard
    {
        IEnumerable<Game> GetGames();

        Game StartGame(Game game);

        void FinishGame(Game game);
    }
}