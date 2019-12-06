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
    public class Card
    {
        public Card(double id)
        {
            Id = id;
            Picture = new PictureBox();
            Picture.BackColor = Color.Black;
        }

        private double Id;
        public PictureBox Picture;
        public bool Clicked = false;
        public bool Open = false;
        static private bool Match = false;

        public string Source;

        Timer OpenTimer = new Timer();

        public void OnClick(object sender, EventArgs e)
        {        
            if (Open || Clicked || AreTwoCardsClicked()) return;
            
            if (!CheckClicked())
            {
                Picture.ImageLocation = Source;
                Clicked = true;
            }
            else
            {
                Picture.ImageLocation = Source;
                Clicked = true;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                        if (Form1.Cards[i, j].Clicked && Form1.Cards[i, j].Picture.ImageLocation == this.Picture.ImageLocation && Form1.Cards[i, j].Id != Id)
                        {
                            Match = true;
                            Form1.Cards[i, j].Open = true;
                            Open = true;

                            Form1.Cards[i, j].Clicked = false;
                            Clicked = false;
                            break;
                        }

                    if (Match) break;
                }
                                      
                if (!Match)
                {
                    OpenTimer.Interval = 1000;
                    OpenTimer.Tick += new System.EventHandler(OpenTimer_Tick);

                    OpenTimer.Start();
                    
                }

                Match = false;

                CheckWin();
            }
        }

        private bool AreTwoCardsClicked()
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (Form1.Cards[i, j].Clicked) count++;

            if (count >= 2) return true;
            return false;
        }
        private bool CheckClicked()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (Form1.Cards[i, j].Clicked) return true;

            return false;  
        }

        private void CloseAllCards()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    Form1.Cards[i, j].Clicked = false;
                    if (!Form1.Cards[i, j].Open)
                        Form1.Cards[i, j].Picture.ImageLocation = "";
                }           
        }

        private void OpenTimer_Tick(object Sender, EventArgs e)
        {
            CloseAllCards();
            OpenTimer.Stop();
        }

        private void CheckWin()
        {
            bool allOpen = true;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (!Form1.Cards[i, j].Open) allOpen = false;

            if (allOpen) Form1.Win();
        }
    }

}
