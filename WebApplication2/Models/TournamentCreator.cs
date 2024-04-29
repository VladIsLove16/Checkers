namespace WebApplication2.Models
{
    public static class TournamentCreator
    {
        public static Tournament Create() {  
            Tournament tournament = new Tournament();
            SetId(tournament);
            DataBase.TournamentList.Add(new Tournament());
            return new Tournament(); 
        }
        private static void SetId(Tournament tournament)
        {
            tournament.Id = DataBase.TournamentList.Count + 1;
        }
    }
}
