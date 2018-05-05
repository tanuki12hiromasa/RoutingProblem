using System;
using System.Collections.Generic;
using System.Text;

namespace dijksta
{
    class path_algo01:PathFinder
    {
        public path_algo01(int width, int height) : base(width, height) { }

        protected override void makePath(Destination[] dest, int startpoint, out List<int> path)
        {
            var _path = new List<int>();
            var yetList = new List<int>();
            for (int i = 0; i < dest.Length; i++) yetList.Add(i);
            _path.Add(startpoint);
            _path.Add(startpoint);
            yetList.Remove(startpoint);
            while (yetList.Count != 0)
            {
                var fardests = farDests();
                int maxCost = int.MinValue;
                int mDest=startpoint;
                foreach(int d in fardests)
                {
                    var mC = minAddCost(d);
                    if (mC > maxCost)
                    {
                        maxCost = mC;
                        mDest = d;
                    }
                }
                int mi = 1;
                int minCost = int.MaxValue;
                for (int i = 0; i < _path.Count - 1; i++)
                {
                    if (deltaAddCost(_path[i], mDest, _path[i + 1]) < minCost)
                    {
                        mi = i;
                        minCost = deltaAddCost(_path[i], mDest, _path[i + 1]);
                    }
                }
                _path.Insert(mi + 1, mDest);
                yetList.Remove(mDest);
            }
            path = _path;

            List<int> farDests()
            {
                var fardests = new List<int>();
                int maxcost = int.MinValue;
                foreach(int i in yetList)
                {
                    if (dest[startpoint].cost[i] > maxcost)
                    {
                        fardests.Clear();
                        fardests.Add(i);
                    }
                    else if (dest[startpoint].cost[i] == maxcost)
                    {
                        fardests.Add(i);
                    }
                }

                return fardests;
            }

            int minAddCost(int idest)
            {
                int mincost = int.MaxValue;
                for(int i = 0; i < _path.Count - 1; i++)
                {
                    mincost = Math.Min(deltaAddCost(_path[i], idest, _path[i + 1]), mincost);
                }
                return mincost;
            }

            int deltaAddCost(int prev, int addDest, int next) => (dest[prev].cost[addDest] + dest[addDest].cost[next]) - dest[prev].cost[next];
        }
    }
}
