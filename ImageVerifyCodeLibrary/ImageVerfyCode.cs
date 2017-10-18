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
        Random random;
        int width = 91;
        int height = 45;
        public Image ImageCreate()
        {
            code = "";
            Image image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            Font f;
            Array array = Enum.GetValues(typeof(FontStyle));
            for (int i = 1; i <= 4; i++)
            {
                random = new Random(DateTime.UtcNow.Millisecond * i + i / i);
                int n = random.Next(2);
                if (n == 1)
                {
                    random = new Random(DateTime.UtcNow.Millisecond * i + i);
                    code += (char)random.Next(65, 88);
                }
                else
                {
                    random = new Random(DateTime.UtcNow.Millisecond / i + i);
                    code += random.Next(0, 9).ToString();
                }
            }
            Brush b = new SolidBrush(Color.Black);
            g.FillRectangle(b, 0, 0, width, height);
            b = new SolidBrush(Color.White);
            Pen p = new Pen(Color.White, 2);

            int dis = 0;
            foreach (char a in code)
            {
                random = new Random(DateTime.UtcNow.Millisecond + dis);
                f = new Font("Arial", 16, (FontStyle)array.GetValue(random.Next(array.Length)));
                g.DrawString(a.ToString(), f, b, dis, 20);
                dis += 13;
            }

            for (int i = 1; i <= 16; i++)
            {
                random = new Random(DateTime.UtcNow.Millisecond * i);
                int x = random.Next(10, width);
                int y = random.Next(10, height);
                g.DrawLine(p, new Point(x, y), new Point(x + 1, y + 1));
            }

            for (int i = 1; i <= 3; i++)
            {
                random = new Random(DateTime.UtcNow.Millisecond * i);
                int x = random.Next(0, width);
                int y = random.Next(0, height);
                g.DrawLine(p, new Point(x, y), new Point(x + y, y + x));
            }
            g.Dispose();
            p.Dispose();
            b.Dispose();
            return image;
        }

        public String Getcode()
        {
            return code;
        }
    }
}
