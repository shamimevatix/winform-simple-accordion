namespace WinFormsAccordionDemoApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            button2 = new Button();
            panel3 = new Panel();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Location = new Point(-4, -1);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(805, 439);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(802, 286);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaptionText;
            button1.ForeColor = SystemColors.ActiveCaption;
            button1.Image = Properties.Resources.ic_arrow_down;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(8, 610);
            button1.Name = "button1";
            button1.Size = new Size(372, 43);
            button1.TabIndex = 0;
            button1.Text = "                    Click Me";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaptionText;
            pictureBox1.Image = Properties.Resources.ic_arrow_down;
            pictureBox1.Location = new Point(12, 444);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(21, 15);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(8, 473);
            panel2.Name = "panel2";
            panel2.Size = new Size(566, 100);
            panel2.TabIndex = 2;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.ActiveCaptionText;
            pictureBox3.Image = Properties.Resources.ic_protect;
            pictureBox3.Location = new Point(415, 29);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(17, 22);
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ActiveCaptionText;
            pictureBox2.Image = Properties.Resources.ic_resolve_ip;
            pictureBox2.Location = new Point(388, 29);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(21, 22);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaptionText;
            button2.ForeColor = SystemColors.ActiveCaption;
            button2.Image = Properties.Resources.ic_arrow_down;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(10, 29);
            button2.Name = "button2";
            button2.Size = new Size(372, 43);
            button2.TabIndex = 1;
            button2.Text = "                    Click Me";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Location = new Point(8, 677);
            panel3.Name = "panel3";
            panel3.Size = new Size(780, 187);
            panel3.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 884);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Button button1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Button button2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Panel panel3;
    }
}
