
namespace UDP_VideoCam
{
    partial class Form_TV
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_TV = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TV)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_TV
            // 
            this.pictureBox_TV.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox_TV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_TV.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_TV.Name = "pictureBox_TV";
            this.pictureBox_TV.Size = new System.Drawing.Size(802, 603);
            this.pictureBox_TV.TabIndex = 0;
            this.pictureBox_TV.TabStop = false;
            // 
            // Form_TV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 603);
            this.Controls.Add(this.pictureBox_TV);
            this.Name = "Form_TV";
            this.Text = "TV";
            this.Load += new System.EventHandler(this.Form_TV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_TV;
    }
}

