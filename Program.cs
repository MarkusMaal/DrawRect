using System;
using System.Linq;

namespace DrawRect
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Contains("/?"))
            {
                Console.WriteLine("\nRectangle draw\n\n<--Help-->\n\n-showlengths -- shows specified lengths of rectangles\n-showperimeter -- shows the perimeter of the rectangle\n-showarea -- shows the area of rectangle\n-x:[width] -- sets the width of the rectangle\n-y:[height] -- sets the height of the rectangle\n-y-margin:[height] -- sets the top margin of the rectangle\n-x-margin:[width] -- sets the left margin of the rectangle\n-scew-x:[multiplier] -- sets the horizontal scew for the rectangle\n-scew-y:[multiplier] -- sets the vertical scew for the rectangle\n-char:[character] -- sets the display character for the rectangle");
                return;
            }
            Rectangle rect1 = new Rectangle();
            //default values
            rect1.x = 20;
            rect1.y = 20;
            rect1.mx = 0;
            rect1.my = 0;
            rect1.scewx = 0;
            rect1.scewy = 0;
            rect1.c = '.';
            foreach (string element in args)
            {
                if (element.StartsWith("-x:"))
                {
                    rect1.x = Convert.ToInt32(element.Replace("-x:", ""));
                }
                else if (element.StartsWith("-y:"))
                {
                    rect1.y = Convert.ToInt32(element.Replace("-y:", ""));
                }
                else if (element.StartsWith("-y-margin:"))
                {
                    rect1.my = Convert.ToInt32(element.Replace("-y-margin:", ""));
                }
                else if (element.StartsWith("-x-margin:"))
                {
                    rect1.mx = Convert.ToInt32(element.Replace("-x-margin:", ""));
                }
                else if (element.StartsWith("-scew-x:"))
                {
                    rect1.scewx = Convert.ToDouble(element.Replace("-scew-x:", "").Replace(".", ","));
                }
                else if (element.StartsWith("-scew-y:"))
                {
                    rect1.scewy = Convert.ToInt32(element.Replace("-scew-y:", ""));
                }
                else if (element.StartsWith("-char:"))
                {
                    rect1.c = Convert.ToChar(element.Replace("-char:", ""));
                }
            }
            int surface = rect1.GetArea();
            rect1.DrawRectangle();
            if (args.Contains("-showlengths")) { Console.WriteLine("a={0}, b={1}", rect1.x.ToString(), rect1.y.ToString()); }
            if (args.Contains("-showperimeter")) { Console.WriteLine("P={0}", rect1.GetPerimeter().ToString()); }
            if (args.Contains("-showarea")) { Console.WriteLine("S={0}", surface.ToString()); }
            if (args.Contains("-pause") ){ Console.ReadLine(); }
        }

        struct Rectangle
        {
            public int x;
            public int y;
            public double mx;
            public int my;
            public char c;
            public double scewx;
            public int scewy;

            public void DrawRectangle()
            {
                int x; int y; double mx; int my;
                x = this.x;
                y = this.y;
                mx = this.mx;
                my = this.my;
                if (scewy != 0)
                {
                    my += scewy;
                    y -= scewy;
                    x += scewy;
                    this.x = x;
                    this.y = y;
                    mx -= scewy;
                }
                for (int i = 0; i < my; i++) {
                    Console.WriteLine();
                }
                string rectline = "";
                for (int i = 0; i < x; i++)
                {
                    rectline += this.c.ToString();
                }
                for (int i = 0; i < y; i++)
                {
                    mx += scewx;
                    string spaces = "";
                    for (int j = 0; j < Convert.ToInt32(mx); j++)
                    {
                        spaces += " ";
                    }
                    Console.WriteLine("{0}{1}", spaces, rectline);
                }
            }

            public int GetArea()
            {
                int x; int y;
                x = this.x;
                y = this.y;
                int Result = x * y;
                return Result;
            }

            public int GetPerimeter()
            {
                int x; int y;
                x = this.x;
                y = this.y;
                int p = 2 * (x + y);
                return p;
            }
        }
    }
}
