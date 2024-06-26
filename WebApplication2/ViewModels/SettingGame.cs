﻿using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;
using WebApplication2.Models.SortSystems;

namespace WebApplication2.ViewModels
{
    public class SettingGame
    {
        public SortSystem SortSystem;
        [Range(1, 10, ErrorMessage = "Недопустимое кол-во участников")]
        public int Members { get; set; } = 0;
        [Range(0, 10, ErrorMessage = "Недопустимое кол-во призов")]
        public int PrizeCount { get; set; } = 0;
        public Judge Judge;
        public List<Participant> Participants=new List<Participant>();
        public RoundGames RoundGames { get; set; }=new RoundGames();
        public SettingGame() {
            
        }
    }
}
