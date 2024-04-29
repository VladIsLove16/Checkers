using WebApplication2.ViewModels;

namespace WebApplication2.Models
{
    public static class DataBase
    {
        public static List<Tournament> TournamentList { get; set; } = new List<Tournament>();
        public static SettingGame SettingGame { get; set; } = new SettingGame();
        public static Judge Judge { get; internal set; }
    }
}
