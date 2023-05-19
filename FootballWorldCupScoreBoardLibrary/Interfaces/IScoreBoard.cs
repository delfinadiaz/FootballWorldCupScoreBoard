using System.Collections.Generic;
using FootballWorldCupScoreBoard.Library.DomainEntities;

namespace FootballWorldCupScoreBoard.Library.Interfaces
{
    public interface IScoreBoard
    {
        IEnumerable<Game> GetGames();

        Game StartGame(Game game);

        void FinishGame(Game game);

        IEnumerable<Game> GetGamesSummary();
    }
}