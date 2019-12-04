using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoupleCards 
{
    class Card
    {
        public Card()
        {
            Picture = new PictureBox();
            Picture.BackColor = Color.Black;
        }

        public PictureBox Picture;
        public bool Clicked = false;
        public bool Open = false;

        public string Source;

        Timer timer = new Timer();

        public void OnClick()
        {
            if (Open || Clicked) return;
            Clicked = true;

            
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object Sender, EventArgs e)
        {
            Clicked = false;
            timer.Enabled = false;
        }
    }

}
