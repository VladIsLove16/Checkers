using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Db.DTOs
{
    public record ReferenceItemReadValue(int Id, string Code, string Description, string Value);
    public record UserInfo(int Id, string FirstName, string LastName, string Patronymic, string Email, string Password, ICollection<ReferenceItemReadValue> Settings);
    public record ReferenceItemInfo(int Id, string Code, string Description);
    public record TournamentInfo(int Id, string Name, int TypeId, ReferenceItemInfo Type, bool Started = false, bool Finished = false);
    public record GameInfo(int Id, int Round, int TournamentId, PlayerInfo ParticipantWhite, PlayerInfo ParticipantBlack, ReferenceItemInfo Result);
    public record PlayerInfo(int Id, string Name, int Age, char Gender, ReferenceItemInfo Rank);
}