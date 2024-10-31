namespace APP_THI_TRAC_NGHIEM.Function
{
    partial class frmCaThi
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
            this.dgvCathi = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCLear = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.txtMaMonThi = new System.Windows.Forms.ComboBox();
            this.txtTGKetTHuc = new System.Windows.Forms.DateTimePicker();
            this.txtTGBatDau = new System.Windows.Forms.DateTimePicker();
            this.txtNumQuest = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRules = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtChuThich = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThoiGianLamBai = new System.Windows.Forms.TextBox();
            this.txtTenCaThi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCathi)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCathi
            // 
            this.dgvCathi.AllowUserToAddRows = false;
            this.dgvCathi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCathi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCathi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCathi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column9,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvCathi.Location = new System.Drawing.Point(0, -6);
            this.dgvCathi.Name = "dgvCathi";
            this.dgvCathi.RowHeadersWidth = 51;
            this.dgvCathi.RowTemplate.Height = 24;
            this.dgvCathi.Size = new System.Drawing.Size(1356, 492);
            this.dgvCathi.TabIndex = 0;
            this.dgvCathi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCathi_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btCLear);
            this.panel1.Controls.Add(this.btXoa);
            this.panel1.Controls.Add(this.btSua);
            this.panel1.Controls.Add(this.btThem);
            this.panel1.Controls.Add(this.txtMaMonThi);
            this.panel1.Controls.Add(this.txtTGKetTHuc);
            this.panel1.Controls.Add(this.txtTGBatDau);
            this.panel1.Controls.Add(this.txtNumQuest);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtRules);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtChuThich);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtThoiGianLamBai);
            this.panel1.Controls.Add(this.txtTenCaThi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 498);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1356, 255);
            this.panel1.TabIndex = 1;
            // 
            // btCLear
            // 
            this.btCLear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCLear.Location = new System.Drawing.Point(967, 128);
            this.btCLear.Name = "btCLear";
            this.btCLear.Size = new System.Drawing.Size(88, 46);
            this.btCLear.TabIndex = 15;
            this.btCLear.Text = "Clear";
            this.btCLear.UseVisualStyleBackColor = true;
            this.btCLear.Click += new System.EventHandler(this.btCLear_Click);
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(873, 128);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(88, 46);
            this.btXoa.TabIndex = 16;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btSua
            // 
            this.btSua.Location = new System.Drawing.Point(967, 70);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(88, 46);
            this.btSua.TabIndex = 17;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(873, 70);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(88, 46);
            this.btThem.TabIndex = 18;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // txtMaMonThi
            // 
            this.txtMaMonThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtMaMonThi.FormattingEnabled = true;
            this.txtMaMonThi.Location = new System.Drawing.Point(117, 23);
            this.txtMaMonThi.Name = "txtMaMonThi";
            this.txtMaMonThi.Size = new System.Drawing.Size(121, 24);
            this.txtMaMonThi.TabIndex = 14;
            // 
            // txtTGKetTHuc
            // 
            this.txtTGKetTHuc.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.txtTGKetTHuc.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTGKetTHuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTGKetTHuc.Location = new System.Drawing.Point(109, 192);
            this.txtTGKetTHuc.Name = "txtTGKetTHuc";
            this.txtTGKetTHuc.Size = new System.Drawing.Size(220, 28);
            this.txtTGKetTHuc.TabIndex = 13;
            // 
            // txtTGBatDau
            // 
            this.txtTGBatDau.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.txtTGBatDau.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTGBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTGBatDau.Location = new System.Drawing.Point(109, 148);
            this.txtTGBatDau.Name = "txtTGBatDau";
            this.txtTGBatDau.Size = new System.Drawing.Size(220, 28);
            this.txtTGBatDau.TabIndex = 13;
            // 
            // txtNumQuest
            // 
            this.txtNumQuest.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumQuest.Location = new System.Drawing.Point(463, 23);
            this.txtNumQuest.Multiline = true;
            this.txtNumQuest.Name = "txtNumQuest";
            this.txtNumQuest.Size = new System.Drawing.Size(156, 25);
            this.txtNumQuest.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(374, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Số câu hỏi";
            // 
            // txtRules
            // 
            this.txtRules.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRules.Location = new System.Drawing.Point(463, 65);
            this.txtRules.Multiline = true;
            this.txtRules.Name = "txtRules";
            this.txtRules.Size = new System.Drawing.Size(156, 25);
            this.txtRules.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(374, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Rules";
            // 
            // txtChuThich
            // 
            this.txtChuThich.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChuThich.Location = new System.Drawing.Point(109, 107);
            this.txtChuThich.Multiline = true;
            this.txtChuThich.Name = "txtChuThich";
            this.txtChuThich.Size = new System.Drawing.Size(507, 25);
            this.txtChuThich.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Chú thích";
            // 
            // txtThoiGianLamBai
            // 
            this.txtThoiGianLamBai.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThoiGianLamBai.Location = new System.Drawing.Point(463, 152);
            this.txtThoiGianLamBai.Multiline = true;
            this.txtThoiGianLamBai.Name = "txtThoiGianLamBai";
            this.txtThoiGianLamBai.Size = new System.Drawing.Size(156, 25);
            this.txtThoiGianLamBai.TabIndex = 12;
            // 
            // txtTenCaThi
            // 
            this.txtTenCaThi.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenCaThi.Location = new System.Drawing.Point(109, 65);
            this.txtTenCaThi.Multiline = true;
            this.txtTenCaThi.Name = "txtTenCaThi";
            this.txtTenCaThi.Size = new System.Drawing.Size(212, 25);
            this.txtTenCaThi.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên Ca thi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "TG kết thúc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "TG làm bài";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "TG bắt đầu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mã môn thi";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 60F;
            this.Column1.HeaderText = "Mã Ca thi";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên Ca thi";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Chú thích";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.FillWeight = 60F;
            this.Column4.HeaderText = "Mã môn thi";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column9
            // 
            this.Column9.FillWeight = 40F;
            this.Column9.HeaderText = "Số câu";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "TG bắt đầu";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "TG kết thúc";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.FillWeight = 40F;
            this.Column7.HeaderText = "TG làm";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Rules";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            // 
            // frmCaThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 753);
            this.Controls.Add(this.dgvCathi);
            this.Controls.Add(this.panel1);
            this.Name = "frmCaThi";
            this.Text = "frmCaThi";
            this.Load += new System.EventHandler(this.frmCaThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCathi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCathi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker txtTGBatDau;
        private System.Windows.Forms.TextBox txtTenCaThi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRules;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtChuThich;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtThoiGianLamBai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtTGKetTHuc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txtMaMonThi;
        private System.Windows.Forms.Button btCLear;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.TextBox txtNumQuest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}