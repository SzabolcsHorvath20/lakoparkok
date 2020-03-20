namespace lakoparkok
{
    partial class Lakoparkok
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lakoparkok));
            this.pbNev = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bLeft = new System.Windows.Forms.Button();
            this.bRight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbNev)).BeginInit();
            this.SuspendLayout();
            // 
            // pbNev
            // 
            this.pbNev.BackColor = System.Drawing.Color.Transparent;
            this.pbNev.Location = new System.Drawing.Point(9, 10);
            this.pbNev.Margin = new System.Windows.Forms.Padding(2);
            this.pbNev.Name = "pbNev";
            this.pbNev.Size = new System.Drawing.Size(139, 196);
            this.pbNev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNev.TabIndex = 0;
            this.pbNev.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(182, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 317);
            this.panel1.TabIndex = 1;
            // 
            // bLeft
            // 
            this.bLeft.Image = ((System.Drawing.Image)(resources.GetObject("bLeft.Image")));
            this.bLeft.Location = new System.Drawing.Point(325, 334);
            this.bLeft.Margin = new System.Windows.Forms.Padding(2);
            this.bLeft.Name = "bLeft";
            this.bLeft.Size = new System.Drawing.Size(96, 57);
            this.bLeft.TabIndex = 2;
            this.bLeft.UseVisualStyleBackColor = false;
            this.bLeft.Visible = false;
            this.bLeft.Click += new System.EventHandler(this.bLeft_Click);
            // 
            // bRight
            // 
            this.bRight.Image = ((System.Drawing.Image)(resources.GetObject("bRight.Image")));
            this.bRight.Location = new System.Drawing.Point(425, 334);
            this.bRight.Margin = new System.Windows.Forms.Padding(2);
            this.bRight.Name = "bRight";
            this.bRight.Size = new System.Drawing.Size(97, 57);
            this.bRight.TabIndex = 3;
            this.bRight.UseVisualStyleBackColor = false;
            this.bRight.Visible = false;
            this.bRight.Click += new System.EventHandler(this.bRight_Click);
            // 
            // Lakoparkok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 395);
            this.Controls.Add(this.bRight);
            this.Controls.Add(this.bLeft);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbNev);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Lakoparkok";
            this.Text = "lakópark";
            this.Load += new System.EventHandler(this.Lakoparkok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbNev)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbNev;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bLeft;
        private System.Windows.Forms.Button bRight;
    }
}

