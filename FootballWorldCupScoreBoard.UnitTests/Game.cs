namespace FootballWorldCupScoreBoard.UnitTests
{
    public class Game
    {
        public Game()
        {
            ScoreHomeTeam = 0;
            ScoreAwayTeam = 0;
            TotalScore = 0;
        }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public int ScoreHomeTeam { get; set; }

        public int ScoreAwayTeam { get; set; }

        public int TotalScore { get; set; } 
    }
}