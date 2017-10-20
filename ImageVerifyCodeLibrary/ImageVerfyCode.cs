using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageVerifyCodeLibrary
{
    public class ImageVerfyCode
    {
        string code;
        Random random = new Random(DateTime.Now.Millisecond);
        int width = 70;
        int height = 30;
        public Image ImageCreate()
        {
            code = "";
            Font font;
            Image img = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(img);
            SolidBrush brush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, 0, 0, width, height);
            Array array = Enum.GetValues(typeof(FontStyle));
            for (int i = 0; i < 4; i++)
            {
                if (random.Next(2) == 0)
                {
                    if (random.Next(2) == 0)
                    {
                        code += (char)random.Next(65, 91);
                    }
                    else
                    {
                        code += (char)random.Next(97, 123);
                    }
                }
                else
                {
                    code += random.Next(0, 10).ToString();
                }
            }
            Console.WriteLine(code);
            brush = new SolidBrush(Color.White);
            int dis = 0;
            foreach (char c in code)
            {
                font = new Font("Aria", 16, (FontStyle)random.Next(array.Length));
                g.DrawString(c.ToString(), font, brush, new Point(dis, 5));
                dis += 13;
            }
            Pen pen = new Pen(Color.White, 2);
            for (int i = 0; i < 6; i++)
            {
                g.DrawLine(pen, new Point(random.Next(height), random.Next(width)), new Point(random.Next(height), random.Next(width)));
            }
            pen.Width = 1;
            for (int i = 0; i < 20; i++)
            {
                int x = random.Next(height);
                int y = random.Next(width);
                g.DrawLine(pen, new Point(x, y), new Point(x + 1, y + 1));
            }

            g.Dispose();
            pen.Dispose();

            return img;
        }

        public String Getcode()
        {
            return code;
        }
    }
}
