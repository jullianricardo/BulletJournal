﻿using BulletJournal.Models.Domain;

namespace BulletJournal.Models
{
    public class Page : Entity
    {
        public string Title { get; set; }

        public int Number { get; set; }

        public List<Collection.Collection> Collections { get; set; }
    }
}
