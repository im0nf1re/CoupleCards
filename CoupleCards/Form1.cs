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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartGameTimer.Interval = 1000;
            StartGameTimer.Tick += new System.EventHandler(StartGameTimer_Tick);

            Images = new JojoImg[] { Dio, Dzorno, Igy, Jonathan, Jozeph, Kakein, Strohaim, Valacas };
            for (int i = 0; i < 8; i++)
            {
                Images[i].Id = i;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Cards[i, j] = new Card(i + j/10.0);
                    Cards[i, j].Picture.Click += new EventHandler(Cards[i, j].OnClick);
                    Cards[i, j].Picture.Size = new Size(120, 120);
                    Cards[i, j].Picture.SizeMode = PictureBoxSizeMode.StretchImage;

                    Cards[i, j].Picture.Location = new Point(15 + 150 * i, 50 + 150 * j);
                    this.Controls.Add(Cards[i, j].Picture);

                    RandomPic(Cards[i, j]);
                    Cards[i, j].Picture.ImageLocation = Cards[i, j].Source;
                }
            }
        }

        static public Card[,] Cards = new Card[4, 4];

        JojoImg[] Images;
        JojoImg Dio = new JojoImg(@"img/dio.jpeg");
        JojoImg Dzorno = new JojoImg(@"img/dzorno.jfif");
        JojoImg Igy = new JojoImg(@"img/igy.jpg");
        JojoImg Jonathan = new JojoImg(@"img/jonatan.jpg");
        JojoImg Jozeph = new JojoImg(@"img/jozeph.png");
        JojoImg Kakein = new JojoImg(@"img/kakein.jpg");
        JojoImg Strohaim = new JojoImg(@"img/strohaim.jfif");
        JojoImg Valacas = new JojoImg(@"img/valacas.jfif");

        private void Form1_Load(object sender, EventArgs e)
        {
            SecToStartLabel.Text = SecToStart.ToString() + "...";
            StartGameTimer.Start();
        }       

        private Timer StartGameTimer = new Timer();
        private int SecToStart = 3;

        private void StartGameTimer_Tick(object Sender, EventArgs e)
        {
            SecToStart--;
            SecToStartLabel.Text = SecToStart.ToString() + "...";
            if (SecToStart == 0)
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        Cards[i, j].Picture.ImageLocation = "";

                SecToStartLabel.Text = "Игра началась";
                SecToStartLabel.Location = new Point(205, 9);
                StartGameTimer.Stop();
            }
        }

        Random rnd = new Random();
        private void RandomPic(Card card)
        {
            int num;
            do
            {
                num = rnd.Next(0, 8);
            } while (Images[num].count >= 2);

            card.Source = Images[num].Loc;
            
            Images[num].count++;
        }

        static public void Win()
        {
            SecToStartLabel.Text = "Nice";
            SecToStartLabel.Location = new Point(270, 9);
            MessageBox.Show("ТЫ ПОБЕДИЛ, ЕЕЕЕЕ!");
        }
    }
}
