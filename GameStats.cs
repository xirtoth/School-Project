﻿using System.Collections.Generic;

namespace School_Project
{
    public class GameStats
    {
        public List<Entity> EnemiesKilled { get; set; }
        public List<Entity> ItemsCollected { get; set; }

        public int DamageDealt { get; set; }

        public int DamageTaken { get; set; }

        public string PlayerName { get; set; }
        public int PlayerLevel { get; set; }

        public int MapLevel { get; set; }

        public int Scores { get; set; }

        public GameStats()
        {
            EnemiesKilled = new List<Entity>();
            ItemsCollected = new List<Entity>();
            DamageDealt = 0;
            DamageTaken = 0;
            PlayerName = GameController.Instance.Player.Name;
            PlayerLevel = GameController.Instance.Player.Level;
            MapLevel = GameController.Instance.Level;
            Scores = 0;
        }

        public void Update()
        {
            MapLevel = GameController.Instance.Level + 1;
            Scores = 20 * DamageDealt - 20 * DamageTaken + 100 * PlayerLevel + 50 * EnemiesKilled.Count + 50 * ItemsCollected.Count + 50 * MapLevel + GameController.Instance.Turn;
        }
    }
}