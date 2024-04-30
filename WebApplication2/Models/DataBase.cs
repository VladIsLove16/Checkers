using WebApplication2.ViewModels;

namespace WebApplication2.Models
{
    public static class DataBase
    {
        static string filename;
        public static List<Tournament> TournamentList
        {
            get
            {
                return new List<Tournament>();  
            }
            set
            {

            }
        }
        
        public static SettingGame SettingGame
        {
            get
            {
                if (settingGame == null)
                    return new SettingGame();
                else return settingGame;
            }
            set { settingGame = value; }
        }
        public static Judge Judge { get; internal set; }
        private static SettingGame settingGame;

        internal static void AddTournament(Tournament tournament)
        {
            TournamentList.Add(tournament);
        }
    }
}
