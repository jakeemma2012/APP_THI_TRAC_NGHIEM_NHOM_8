namespace APP_THI_TRAC_NGHIEM.StudentFormExam
{
    partial class frmEnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnd));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtName = new System.Windows.Forms.Label();
            this.txtNumQ = new System.Windows.Forms.Label();
            this.txtNumRight = new System.Windows.Forms.Label();
            this.txtPoint = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(60, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 197);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(264, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(222, 25);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Kết quả bài thi của bạn :";
            // 
            // txtNumQ
            // 
            this.txtNumQ.AutoSize = true;
            this.txtNumQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumQ.Location = new System.Drawing.Point(311, 105);
            this.txtNumQ.Name = "txtNumQ";
            this.txtNumQ.Size = new System.Drawing.Size(175, 25);
            this.txtNumQ.TabIndex = 1;
            this.txtNumQ.Text = "- Số câu đã trả lời :";
            // 
            // txtNumRight
            // 
            this.txtNumRight.AutoSize = true;
            this.txtNumRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumRight.Location = new System.Drawing.Point(311, 153);
            this.txtNumRight.Name = "txtNumRight";
            this.txtNumRight.Size = new System.Drawing.Size(197, 25);
            this.txtNumRight.TabIndex = 1;
            this.txtNumRight.Text = "- Số câu trả lời đúng :";
            // 
            // txtPoint
            // 
            this.txtPoint.AutoSize = true;
            this.txtPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoint.Location = new System.Drawing.Point(311, 197);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(211, 25);
            this.txtPoint.TabIndex = 1;
            this.txtPoint.Text = "- Điểm bài thi của bạn :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(419, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Kết thúc";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btEnd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(311, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(565, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "-------------------------------------------------------------------------------";
            // 
            // frmEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(897, 364);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPoint);
            this.Controls.Add(this.txtNumRight);
            this.Controls.Add(this.txtNumQ);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmEnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEnd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEnd_FormClosing);
            this.Load += new System.EventHandler(this.frmEnd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtNumQ;
        private System.Windows.Forms.Label txtNumRight;
        private System.Windows.Forms.Label txtPoint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
    }
}