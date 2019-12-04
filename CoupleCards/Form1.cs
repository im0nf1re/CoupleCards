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
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    
                    Cards[i, j] = new Card();
                    //this.Cards[i, j].Picture.Click += new System.EventHandler();
                    Cards[i, j].Picture.Size = new Size(120, 120);
                    Cards[i, j].Picture.SizeMode = PictureBoxSizeMode.StretchImage;

                    Cards[i, j].Picture.Location = new Point(15 + 150 * i, 15 + 150 * j);
                    this.Controls.Add(Cards[i, j].Picture);
                    /*
                    Masks[i, j] = new PictureBox();
                    Masks[i, j].Size = new Size(120, 120);
                    Masks[i, j].Location = new Point(15 + 150 * i, 15 + 150 * j);

                    Masks[i, j].BackColor = Color.Black;
                    this.Controls.Add(Masks[i, j]);
                    */
                                        
                }
            }
            Images = new JojoImg[] { Dio, Dzorno, Igy, Jonathan, Jozeph, Kakein, Strohaim, Valacas };
            for (int i = 0; i < 8; i++)
            {
                Images[i].Id = i;
            }
            
        }

        Card[,] Cards = new Card[4, 4];
        //PictureBox[,] Masks = new PictureBox[4, 4];

        JojoImg[] Images;
        JojoImg Dio = new JojoImg("//192.168.32.241/a311/Пр-17-1/Синкевич/CoupleCards/dio.jpeg");
        JojoImg Dzorno = new JojoImg("//192.168.32.241/a311/Пр-17-1/Синкевич/CoupleCards/dzorno.jfif");
        JojoImg Igy = new JojoImg("//192.168.32.241/a311/Пр-17-1/Синкевич/CoupleCards/igy.jpg");
        JojoImg Jonathan = new JojoImg("//192.168.32.241/a311/Пр-17-1/Синкевич/CoupleCards/jonatan.jpg");
        JojoImg Jozeph = new JojoImg("//192.168.32.241/a311/Пр-17-1/Синкевич/CoupleCards/jozeph.png");
        JojoImg Kakein = new JojoImg("//192.168.32.241/a311/Пр-17-1/Синкевич/CoupleCards/kakein.jpg");
        JojoImg Strohaim = new JojoImg("//192.168.32.241/a311/Пр-17-1/Синкевич/CoupleCards/strohaim.jfif");
        JojoImg Valacas = new JojoImg("//192.168.32.241/a311/Пр-17-1/Синкевич/CoupleCards/valacas.jfif");

        private void Form1_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    RandomPic(Cards[i, j]);
                }
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
            card.Picture.ImageLocation = card.Source;
            Images[num].count++;
        
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
