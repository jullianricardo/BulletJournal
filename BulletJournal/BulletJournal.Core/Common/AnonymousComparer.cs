using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Core.Common
{
    public static class AnonymousComparer
    {
        #region ICompare<T>

        private class Comparer<T> : IComparer<T>
        {
            private readonly Func<T, T, int> _compare;

            public Comparer(Func<T, T, int> compare)
            {
                _compare = compare;
            }

            public int Compare(T x, T y) => _compare(x, y);
        }

        #endregion

        #region IEqualityComparer<T>

        public static IComparer<T> Create<T>(Func<T, T, int> compare)
        {
            if (compare == null)
                throw new ArgumentNullException(nameof(compare));

            return new Comparer<T>(compare);
        }

        public static IEqualityComparer<T> Create<T, TKey>(Func<T, TKey> compareKeySelector)
        {
            if (compareKeySelector == null)
                throw new ArgumentNullException(nameof(compareKeySelector));

            return new EqualityComparer<T>(
                (x, y) =>
                {
                    if (object.ReferenceEquals(x, y))
                        return true;

                    if (x == null || y == null)
                        return false;

                    return compareKeySelector(x).Equals(compareKeySelector(y));
                },
                obj =>
                {
                    if (obj == null)
                        return 0;

                    var retVal = compareKeySelector(obj);

                    if (retVal == null)
                        return 0;

                    return retVal.GetHashCode();
                });
        }

        public static IEqualityComparer<T> Create<T>(Func<T, T, bool> equals, Func<T, int> getHashCode)
        {
            if (equals == null)
                throw new ArgumentNullException(nameof(equals));

            if (getHashCode == null)
                throw new ArgumentNullException(nameof(getHashCode));

            return new EqualityComparer<T>(equals, getHashCode);
        }

        private class EqualityComparer<T> : IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> _equals;
            private readonly Func<T, int> _getHashCode;

            public EqualityComparer(Func<T, T, bool> equals, Func<T, int> getHashCode)
            {
                _equals = equals;
                _getHashCode = getHashCode;
            }

            public bool Equals(T x, T y)
            {
                return _equals(x, y);
            }

            public int GetHashCode(T obj)
            {
                return _getHashCode(obj);
            }
        }

        #endregion
    }
}
