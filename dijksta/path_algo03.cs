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
            base.makePath(dest, startpoint, out path);

        }
    }
}
