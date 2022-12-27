using BulletJournal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models
{
    public class Index : Entity
    {
        public string JournalId { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();

        public void AddCollection(Collection.Collection collection)
        {
            var topic = collection.ToTopic();
            Topics.Add(topic);
        }
    }
}
