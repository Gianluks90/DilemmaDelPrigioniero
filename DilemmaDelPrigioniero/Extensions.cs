using System;
using System.Collections.Generic;
using System.Text;
using DilemmaDelPrigioniero.Players;

namespace DilemmaDelPrigioniero
{
    public static class Extensions
    {
        public static void BubbleSortComparable<T>(IList<T> myList, IComparer<T> comparer)      // BubbleSort di elementi Generici;
        {
            for (int i = myList.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comparer.Compare(myList[j], myList[j+1]) > 0)
                    {
                       Swap(myList, j, j + 1);
                    }
                }
            }
        }
        private static void Swap<T>(IList<T> a, int j, int v)
        {
            var temp = a[j];
            a[j] = a[v];
            a[v] = temp;
        }

        internal static void BubbleSortComparable(List<Player> players)
        {
            throw new NotImplementedException();
        }
    }
}