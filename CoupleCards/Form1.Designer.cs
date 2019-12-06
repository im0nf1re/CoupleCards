namespace CoupleCards
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            SecToStartLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 641);
            this.Controls.Add(SecToStartLabel);
            this.Name = "Form1";
            this.Text = "Jojo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        static public System.Windows.Forms.Label SecToStartLabel;
    }
}

