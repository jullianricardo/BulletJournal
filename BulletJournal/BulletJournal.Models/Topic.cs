﻿using BulletJournal.Models.Domain;

namespace BulletJournal.Models
{
    public class Topic : Entity
    {
        public string? Title { get; set; }

        public List<string> PageNumbers { get; set; } = new List<string>();
    }
}