using System;
using System.Collections.Generic;
using System.Text;

namespace DilemmaDelPrigioniero
{
    class Extensions
    {
        public static void BubbleSortComparable(IList<IComparable> myList)      // BobbleSort con ogni tipo di List (Generics)
        {
            for (int i = 0; i < myList.Count-1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int res = myList[j].CompareTo(myList[j + 1]);
                    if (res > 0)
                    {
                        Swap(myList, j, j + 1);
                    }
                }
            }
        }

        private static void Swap(IList<IComparable> a, int j, int v)
        {
            var temp = a[j];
            a[j] = a[v];
            a[v] = temp;
        }
    }
}
