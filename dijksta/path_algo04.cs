using System;
using System.Collections.Generic;
using System.Text;

namespace dijksta
{
    class path_algo04:PathFinder
    {
        path_algo04(int width, int height) : base(width, height) { }

        protected override void makePath(Destination[] dest, int startpoint, out List<int> path)
        {
            var _path = new List<int>();
            _path.Add(startpoint);
            var prev = startpoint;
            while (_path.Count < dest.Length)
            {
                int mincost = int.MaxValue;
                int mindistance = int.MaxValue;
                int mindest = startpoint;
                for(int j = 0; j < dest.Length; j++)
                {
                    if (j != prev && (dest[prev].cost[j] < mincost || dest[prev].cost[j] == mincost && dest[startpoint].cost[j] < mindistance))
                    {
                        mincost = dest[prev].cost[j];
                        mindistance = dest[startpoint].cost[j];
                        mindest = j;
                    }
                }
                _path.Add(mindest);
                prev = mindest;
            }
            _path.Add(startpoint);
            path = _path;
        }
    }
}
