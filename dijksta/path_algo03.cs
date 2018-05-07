using System;
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
                for(int i = 0; i < _path.Count; i++)
                {

                }
                
                update = false;
            }

            path = _path;
        }
    }
}
