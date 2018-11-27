using DilemmaDelPrigioniero.Competition;
using System;
using System.Collections;

namespace DilemmaDelPrigioniero
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Tournament();
            t.Giostra();
            t.Sort();
            t.ShowResult();
            var e = new Evolution();
            e.Evolve();
        }
    }
}
