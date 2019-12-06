using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace CoupleCards
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Controls.Add(RestartBtn);
            Controls.Add(ScoreLabel);
            Controls.Add(label1);
            Controls.Add(SecToStartLabel);

            RestartBtn.Click += new EventHandler(RestartBtn_Click);
            StartGameTimer.Tick += new EventHandler(StartGameTimer_Tick);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Cards[i, j].Picture.Click += new EventHandler(Cards[i, j].OnClick);
                }
            }
        }

        private void SetStartSettings()
        {
            // SecToStartLabel
            // 
            SecToStartLabel.AutoSize = true;
            SecToStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            SecToStartLabel.Location = new System.Drawing.Point(284, 9);
            SecToStartLabel.Name = "SecToStartLabel";
            SecToStartLabel.Size = new System.Drawing.Size(86, 31);
            SecToStartLabel.TabIndex = 0;
            SecToStartLabel.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label1.Location = new System.Drawing.Point(12, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 25);
            label1.TabIndex = 1;
            label1.Text = "Очки:";
            // 
            // ScoreLabel
            // 
            ScoreLabel.AutoSize = true;
            ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            ScoreLabel.Location = new System.Drawing.Point(70, 15);
            ScoreLabel.Name = "ScoreLabel";
            ScoreLabel.Size = new System.Drawing.Size(23, 25);
            ScoreLabel.TabIndex = 2;
            ScoreLabel.Text = "0";
            // 
            // RestartBtn
            // 
            RestartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            RestartBtn.Location = new System.Drawing.Point(472, 9);
            RestartBtn.Name = "RestartBtn";
            RestartBtn.Size = new Size(120, 31);
            RestartBtn.TabIndex = 3;
            RestartBtn.Text = "Переиграть";
            RestartBtn.UseVisualStyleBackColor = true;
            RestartBtn.Visible = false;

            

            StartGameTimer.Interval = 1000;
            

            Images = new JojoImg[] { Dio, Dzorno, Igy, Jonathan, Jozeph, Kakein, Strohaim, Valacas };

            for (int i = 0; i < 8; i++)
            {
                Images[i].Id = i;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Cards[i, j] = new Card(i + j / 10.0);
                    
                    Cards[i, j].Picture.Size = new Size(120, 120);
                    Cards[i, j].Picture.SizeMode = PictureBoxSizeMode.StretchImage;

                    Cards[i, j].Picture.Location = new Point(15 + 150 * i, 50 + 150 * j);
                    this.Controls.Add(Cards[i, j].Picture);

                    RandomPic(Cards[i, j]);
                    Cards[i, j].Picture.ImageLocation = Cards[i, j].Source;
                }
            }

            Score = 0;

            SecToStart = 3;
            SecToStartLabel.Text = SecToStart.ToString() + "...";
            StartGameTimer.Start();
        }

        static public Label label1 = new Label();
        static public Button RestartBtn = new Button();
        static public Label ScoreLabel = new Label();
        static public Label SecToStartLabel = new Label();

        static public int Score;

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
            SetStartSettings();
        }       

        private Timer StartGameTimer = new Timer();
        private int SecToStart;

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
            RestartBtn.Visible = true;
            SoundPlayer winSound = new SoundPlayer(@"sound/win.wav");
            winSound.Play();
            SecToStartLabel.Text = "Nice";
            SecToStartLabel.Location = new Point(270, 9);
            MessageBox.Show("ТЫ ПОБЕДИЛ, ЕЕЕЕЕ!");
        }

        static public void Lose()
        {
            RestartBtn.Visible = true;
            SoundPlayer loseSound = new SoundPlayer(@"sound/lose.wav");
            loseSound.Play();
            SecToStartLabel.Text = "KONO DIO DA";
            SecToStartLabel.Location = new Point(210, 9);
            MessageBox.Show("ты проиграл...");
        }

        private void RestartBtn_Click(object sender, EventArgs e)
        {
            SetStartSettings();
        }
    }
}
