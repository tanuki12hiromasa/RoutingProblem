using System;

namespace dijksta
{
    class salesman
    {
        const int width = 9;
        const int hight = 9;

        static void Main(string[] args)
        {
            var wld = new salesman();
            var csvdata = Csvreader.Read("neighbor_mat.csv");
            wld.earth = new int[width * hight, width * hight];
            for(int i = 0; i < width * hight; i++)
            {
                var lines = csvdata[i].Split(',');
            }
        }


        struct Dest
        {
            int point;
            string name;
        }
        int[,] earth;
        Dest[] dest;

        static int XYtoNum(int x,int y,int width)
        {
            return y * width + x;
        }
    }
}
