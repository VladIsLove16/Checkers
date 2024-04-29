namespace Db.DTOs
{
    public record UserCreate(string FirstName, string LastName, string Patronymic, string Email, string Password, ICollection<ReferenceItemWriteValue> Settings);
    public record UserUpdate(int Id, string FirstName, string LastName, string Patronymic, string Email, string Password, ICollection<ReferenceItemWriteValue> Settings);
    public record ReferenceItemWriteValue(int Id, string Value);
    public record ReferenceItemCreate(string Code, string Description);
    public record ReferenceItemUpdate(int Id, string Code, string Description);
    public record TournamentCreate(string Name, int TypeId);
    public record TournamentUpdate(int Id, string Name, int TypeId);
    public record GameCreate(int Round, int TournamentId, int ParticipantWhiteId, int ParticipantBlackId);
    public record PlayerCreate(string Name, int Age, char Gender, int RankId);
    public record PlayerUpdate(int Id, string Name, int Age, char Gender, int RankId);
}