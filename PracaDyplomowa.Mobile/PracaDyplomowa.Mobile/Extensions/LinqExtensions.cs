using System;
using System.Collections.Generic;
using System.Text;

namespace PracaDyplomowa.Mobile.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<ICollection<T>> PairUp<T>(this IEnumerable<T> source)
        {
            using (var iterator = source.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    var pair = new List<T>();
                    pair.Add(iterator.Current);

                    if (iterator.MoveNext())
                    {
                        pair.Add(iterator.Current);
                    }

                    yield return pair;
                }
            }
        }
    }
}
