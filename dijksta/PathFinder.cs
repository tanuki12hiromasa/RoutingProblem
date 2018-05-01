using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace dijksta
{
    class PathFinder
    {

        struct Destination
        {
            public string name;
            public int pos;
            public int[] cost;
            public List<int>[] route;
        }

        int _width;int _height;
        int nCross; //交差点の数 width*height 
        int[,] map; //グラフ（地図）データ
        Destination[] dest; //配達地点　並びはcsvの順
        List<int> path; //配達順
        int startpoint; //開始点/終着点
        int[] isDest; //その場所がDestかどうか(Destならその番号、違うなら-1)

        PathFinder(int width,int height)
        {
            _width = width; _height = height;
            nCross = _width * _height;
            map = new int[nCross, nCross];
            isDest = new int[nCross];
        }

        public int ex(string mapfile,string destsfile) //一連の計算を行う
        {
            ReadMap(mapfile);
            ReadDest(destsfile);
            findRoute();

            return 1;
        }

        void findRoute()
        {

            for(int i = 0; i < dest.Length; i++)
            {
                var cost = new int[nCross];
                var prev = new int[nCross];
                var isYet = new bool[nCross];
                int dLeft = dest.Length - 1;
                List<int> lastnode = new List<int>();
                lastnode.Add(startpoint);
                cost[startpoint] = 0;
                prev[startpoint] = -1;
                isYet[startpoint] = true;
                while (dLeft > 0)
                {
                    var pnode = new List<int>(lastnode);
                    lastnode.Clear();
                    foreach (int n in pnode)
                    {
                        for(int x = 0; x < nCross; x++)
                        {
                            if( map[n,x] == 1 && !isYet[x])
                            {
                                cost[x] = cost[n] + 1;
                                prev[x] = n;
                                isYet[x] = true;
                                lastnode.Add(x);
                                if (isDest[x] != 0) dLeft--;
                            }
                        }
                    }
                    
                }
                for(int j = 0; j < dest.Length; j++) //prevを辿ってrouteに格納
                {
                    var pos = dest[j].pos;
                    while (pos != dest[i].pos)
                    {
                        dest[i].route[j].Add(pos);
                        pos = prev[pos];
                    }
                    dest[i].route[j].Reverse();
                }
            }
        }

        void makePath()
        {
            int deltaAddCost(int prev, int addDest, int next) => (dest[prev].cost[addDest] + dest[addDest].cost[next]) - dest[prev].cost[next];
            int searchShortPath(int prev, int next, int inv = 1)
            {
                int minCost = int.MaxValue;
                int mDest = startpoint;
                foreach (int i in yetList)
                {
                    if (i != prev && i != next)
                    {
                        var addCost = (dest[prev].cost[i] + dest[next].cost[i]) * inv;
                        if (addCost < minCost ||
                            (addCost == minCost && dest[startpoint].cost[i] > dest[startpoint].cost[mDest]))
                        {
                            minCost = addCost;
                            mDest = i;
                        }
                    }
                }
                return mDest;
            }

            path = new List<int>();
            List<int> yetList = new List<int>();
            for (int i = 0; i < dest.Length; i++) if (i != startpoint) yetList.Add(i);
            path.Add(startpoint);
            path.Add(startpoint);
            var farDest = searchShortPath(startpoint, startpoint, -1);
            path.Insert(1, farDest);
            yetList.Remove(farDest);
            while (path.Count <= dest.Length)
            {
                int minCost = int.MaxValue;
                int minDest = startpoint;
                int minPlace = 0;
                for (int i = 0; i < path.Count - 1; i++)
                {
                    var sDest = searchShortPath(path[i], path[i + 1]);
                    if (deltaAddCost(i, sDest, i + 1) < minCost)
                    {
                        minCost = deltaAddCost(i, sDest, i + 1);
                        minDest = sDest;
                        minPlace = i + 1;
                    }
                }
                path.Insert(minPlace, minDest);
            }
        }

        

        void ReadMap(string file)
        {
            try
            {
                using (var str = new System.IO.StreamReader(file))
                {
                    var line = str.ReadLine();

                }
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        void ReadDest(string file)
        {

        }

        public void WritePath()
        {

        }
    }
}
