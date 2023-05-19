namespace FootballWorldCupScoreBoard.Library.DomainEntities
{
    public class Game
    {
        public Game()
        {
            ScoreHomeTeam = 0;
            ScoreAwayTeam = 0;
            TotalScore = 0;
        }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public int ScoreHomeTeam { get; set; }

        public int ScoreAwayTeam { get; set; }

        public int TotalScore { get; set; }

        public void UpdateScore(int v1, int v2)
        {
            ScoreHomeTeam = v1;
            ScoreAwayTeam = v2;
            TotalScore = v1 + v2;
        }
    }
}