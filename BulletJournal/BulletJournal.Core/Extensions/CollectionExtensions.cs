using BulletJournal.Core.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Core.Extensions
{
    public static class CollectionExtensions
    {

        public static bool IsNullCollection<T>(this ICollection<T> collection)
        {
            return collection is NullCollection<T>;
        }

        public static void Patch<T>(this ICollection<T> source, ICollection<T> target, Action<T, T> patch)
        {
            source.Patch(target, EqualityComparer<T>.Default, patch);
        }

        public static void Patch<T>(this ICollection<T> source, ICollection<T> target, IEqualityComparer<T> comparer, Action<T, T> patch)
        {
            Action<EntryState, T, T> patchAction = (state, x, y) =>
            {
                if (state == EntryState.Modified)
                {
                    patch(x, y);
                }
                else if (state == EntryState.Added)
                {
                    target.Add(x);
                }
                else if (state == EntryState.Deleted)
                {
                    target.Remove(x);
                }
            };

            source.CompareTo(target, comparer, patchAction);
        }

        public static void CompareTo<T>(this ICollection<T> source, ICollection<T> target, IEqualityComparer<T> comparer, Action<EntryState, T, T> action)
        {
            //Change
            foreach (var sourceItem in source)
            {
                var targetItem = target.FirstOrDefault(x => comparer.Equals(x, sourceItem));
                if (targetItem != null && !targetItem.Equals(default(T)))
                {
                    action(EntryState.Modified, sourceItem, targetItem);
                }
            }

            //Add
            foreach (var newItem in source.Except(target, comparer))
            {
                action(EntryState.Added, newItem, newItem);
            }

            //Remove 
            foreach (var removedItem in target.Except(source, comparer).ToArray())
            {
                action(EntryState.Deleted, removedItem, removedItem);
            }
        }
    }
}
