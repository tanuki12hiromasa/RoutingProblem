﻿using System;
using System.Collections.Generic;
using System.Text;

namespace dijksta
{
    class path_algo03:PathFinder
    {
        public path_algo03(int width, int height) : base(width, height) { }

        protected override void makePath(Destination[] dest, int startpoint, out List<int> path)
        {
            List<int> _path;
            base.makePath(dest, startpoint, out _path); //


            //ノード入れ替えを行う
            bool update = true;
            while (update)
            {
                update = false;
                for(int i = 1; i < _path.Count - 1; i++)
                {
                    var cDest = _path[i];
                    for(int j = 0; j < _path.Count - 1; j++)
                    {
                        int deltaCost(int prev, int next) => dest[_path[prev]].cost[_path[next]];

                        if ((deltaCost(i-1,i)+deltaCost(i,i+1)+deltaCost(j,j+1)) - (deltaCost(i-1,i+1)+deltaCost(j,i)+deltaCost(i,j+1)) > 0 && i!=j && i!=j+1 && update == false)
                        {
                            _path.RemoveAt(i);
                            _path.Insert(j, cDest);
                            update = true;
                        }
                    }
                }
            }

            path = _path;

            
        }
    }
}
