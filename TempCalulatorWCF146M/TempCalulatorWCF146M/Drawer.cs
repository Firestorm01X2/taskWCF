using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TempCalulatorWCF146M
{
    //Ещё один комментарий
    public class Drawer
    {
        public void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Red, 0, 0, 100, 100);
        }
    }
}
