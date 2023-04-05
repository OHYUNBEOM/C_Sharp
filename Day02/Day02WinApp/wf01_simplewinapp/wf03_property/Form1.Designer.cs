namespace wf03_property
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gbxmain = new System.Windows.Forms.GroupBox();
            this.fontsize = new System.Windows.Forms.NumericUpDown();
            this.result = new System.Windows.Forms.TextBox();
            this.italic = new System.Windows.Forms.CheckBox();
            this.bold = new System.Windows.Forms.CheckBox();
            this.fontname = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontsize)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxmain
            // 
            this.gbxmain.Controls.Add(this.fontsize);
            this.gbxmain.Controls.Add(this.result);
            this.gbxmain.Controls.Add(this.italic);
            this.gbxmain.Controls.Add(this.bold);
            this.gbxmain.Controls.Add(this.fontname);
            this.gbxmain.Controls.Add(this.label2);
            this.gbxmain.Controls.Add(this.label1);
            this.gbxmain.Location = new System.Drawing.Point(12, 12);
            this.gbxmain.Name = "gbxmain";
            this.gbxmain.Size = new System.Drawing.Size(395, 174);
            this.gbxmain.TabIndex = 0;
            this.gbxmain.TabStop = false;
            this.gbxmain.Text = "groupBox1";
            // 
            // fontsize
            // 
            this.fontsize.Location = new System.Drawing.Point(97, 48);
            this.fontsize.Name = "fontsize";
            this.fontsize.Size = new System.Drawing.Size(121, 21);
            this.fontsize.TabIndex = 4;
            this.fontsize.ValueChanged += new System.EventHandler(this.fontsize_ValueChanged);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(29, 75);
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(337, 93);
            this.result.TabIndex = 5;
            // 
            // italic
            // 
            this.italic.AutoSize = true;
            this.italic.Location = new System.Drawing.Point(316, 24);
            this.italic.Name = "italic";
            this.italic.Size = new System.Drawing.Size(50, 16);
            this.italic.TabIndex = 3;
            this.italic.Text = "Italic";
            this.italic.UseVisualStyleBackColor = true;
            this.italic.CheckedChanged += new System.EventHandler(this.italic_CheckedChanged);
            // 
            // bold
            // 
            this.bold.AutoSize = true;
            this.bold.Location = new System.Drawing.Point(242, 25);
            this.bold.Name = "bold";
            this.bold.Size = new System.Drawing.Size(49, 16);
            this.bold.TabIndex = 2;
            this.bold.Text = "Bold";
            this.bold.UseVisualStyleBackColor = true;
            this.bold.CheckedChanged += new System.EventHandler(this.bold_CheckedChanged);
            // 
            // fontname
            // 
            this.fontname.FormattingEnabled = true;
            this.fontname.Location = new System.Drawing.Point(97, 22);
            this.fontname.Name = "fontname";
            this.fontname.Size = new System.Drawing.Size(121, 20);
            this.fontname.TabIndex = 1;
            this.fontname.SelectedIndexChanged += new System.EventHandler(this.fontname_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "글자크기";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "글자체";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 198);
            this.Controls.Add(this.gbxmain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "속성확인";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxmain.ResumeLayout(false);
            this.gbxmain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontsize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxmain;
        private System.Windows.Forms.CheckBox italic;
        private System.Windows.Forms.CheckBox bold;
        private System.Windows.Forms.ComboBox fontname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.NumericUpDown fontsize;
    }
}

