using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppCs
{
    class Program
    {
        public static void Main()
        {
            while (true)
            {
                var list = CreateRandomList(out var toCount);

                var cnt1 = list.Count(i => i == toCount);
                var cnt2 = list.MyCnt(i => i == toCount);

                DoWork(cnt1, cnt2);
            }
        }

        private static List<int> CreateRandomList(out int toCount)
        {
            var rnd = new Random();
            int rndRange = rnd.Next(100000);
            int rndCapacity = rnd.Next(200, 50000);
            var list = new List<int>(rndCapacity);

            for (int i = 0; i < rndCapacity; i++)
            {
                list.Add(rnd.Next(0, rndRange));
            }

            toCount = rnd.Next() % 2 == 0 ? list[rnd.Next(0, list.Count)] : rnd.Next(0, rndRange * 5);

            return list;
        }

        private static int DoWork(int cnt1, int cnt2)
        {
            cnt1 += cnt2;
            cnt2 += cnt1;
            return cnt2;
        }
    }

    static class Ext
    {
        public static int MyCnt(this List<int> list, Func<int, bool> pred)
        {
            int cnt = 0;

            for (var i = 0; i < list.Count; i++)
            {
                if (pred(i))
                    cnt++;
            }

            return cnt;
        }
    }
}
