using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class SettingGame
    {
        public string SortSystem ="Неопределенная";
        [Range(1, 10, ErrorMessage = "Недопустимое кол-во участников")]
        public int Members { get; set; } = 0;
        [Range(0, 10, ErrorMessage = "Недопустимое кол-во призов")]
        public int PrizeCount { get; set; } = 0;
        public string Name="Неизвестно";
        public List<Participant> Participants=new List<Participant>();
    }
}
