using System;
using System.Collections.Generic;
using System.Text;

namespace dijksta
{
    class SAalgo:PathFinder
    {
        public SAalgo(int width,int height) : base(width, height) { outfile = "SApath.txt"; }

        const double T0 = 100;
        

        protected override void makePath(Destination[] dest, int startpoint, out List<int> path)
        {
            var curpath = new List<int>();

            double T = T0;
            curpath.Add(startpoint); //初期状態の設定（ただのアルファベット順）
            for(int i = 0; i < dest.Length; i++) { if (i != startpoint) curpath.Add(i); }
            curpath.Add(startpoint);

            var starttime = DateTime.Now;
            var timelimit = new TimeSpan(0,0,30);
            var numofnode = curpath.Count;
            var random = new Random(334);
            Int64 count = 0;

            while (DateTime.Now - starttime < timelimit)
            {
                var nextpath = new List<int>(curpath);
                var transpNum =  random.Next(1, numofnode - 2);
                var transTo = random.Next(1, numofnode - 2);
                nextpath.RemoveAt(transpNum);
                nextpath.Insert(transTo, curpath[transpNum]);
                var deltaE = SumCost(nextpath) - SumCost(curpath);
                if (deltaE <= 0 || Math.Exp(-deltaE / T) > random.NextDouble())
                    curpath = nextpath;
                T *= 0.995;
                count++;
                //Console.WriteLine("deltaE:" + deltaE);
            }

            path = curpath;
            Console.WriteLine("sumcost:" + SumCost(curpath) + ",count:" + count);

            int SumCost(List<int> _path){
                int sum = 0;
                for (int i = 0; i < _path.Count - 1; i++) sum += dest[_path[i]].cost[_path[i + 1]];
                return sum;
            }
        }
    }
}
