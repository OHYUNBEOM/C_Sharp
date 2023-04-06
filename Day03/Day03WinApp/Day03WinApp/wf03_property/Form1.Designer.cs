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
            this.rboIndent = new System.Windows.Forms.RadioButton();
            this.rboNormal = new System.Windows.Forms.RadioButton();
            this.fontsize = new System.Windows.Forms.NumericUpDown();
            this.result = new System.Windows.Forms.TextBox();
            this.italic = new System.Windows.Forms.CheckBox();
            this.bold = new System.Windows.Forms.CheckBox();
            this.fontname = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pgbdummy = new System.Windows.Forms.ProgressBar();
            this.trbdummy = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnmsgbox = new System.Windows.Forms.Button();
            this.btnmodaless = new System.Windows.Forms.Button();
            this.btnmodal = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnaddchild = new System.Windows.Forms.Button();
            this.btnaddroot = new System.Windows.Forms.Button();
            this.lsvdummy = new System.Windows.Forms.ListView();
            this.trvdummy = new System.Windows.Forms.TreeView();
            this.btnload = new System.Windows.Forms.Button();
            this.pcbdummy = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gbxmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontsize)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbdummy)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbdummy)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxmain
            // 
            this.gbxmain.Controls.Add(this.rboIndent);
            this.gbxmain.Controls.Add(this.rboNormal);
            this.gbxmain.Controls.Add(this.fontsize);
            this.gbxmain.Controls.Add(this.result);
            this.gbxmain.Controls.Add(this.italic);
            this.gbxmain.Controls.Add(this.bold);
            this.gbxmain.Controls.Add(this.fontname);
            this.gbxmain.Controls.Add(this.label2);
            this.gbxmain.Controls.Add(this.label1);
            this.gbxmain.Location = new System.Drawing.Point(12, 12);
            this.gbxmain.Name = "gbxmain";
            this.gbxmain.Size = new System.Drawing.Size(350, 174);
            this.gbxmain.TabIndex = 0;
            this.gbxmain.TabStop = false;
            this.gbxmain.Text = "groupBox1";
            // 
            // rboIndent
            // 
            this.rboIndent.AutoSize = true;
            this.rboIndent.Location = new System.Drawing.Point(277, 49);
            this.rboIndent.Name = "rboIndent";
            this.rboIndent.Size = new System.Drawing.Size(71, 16);
            this.rboIndent.TabIndex = 6;
            this.rboIndent.Text = "들여쓰기";
            this.rboIndent.UseVisualStyleBackColor = true;
            this.rboIndent.CheckedChanged += new System.EventHandler(this.rboIndent_CheckedChanged);
            // 
            // rboNormal
            // 
            this.rboNormal.AutoSize = true;
            this.rboNormal.Checked = true;
            this.rboNormal.Location = new System.Drawing.Point(224, 49);
            this.rboNormal.Name = "rboNormal";
            this.rboNormal.Size = new System.Drawing.Size(47, 16);
            this.rboNormal.TabIndex = 6;
            this.rboNormal.TabStop = true;
            this.rboNormal.Text = "일반";
            this.rboNormal.UseVisualStyleBackColor = true;
            this.rboNormal.CheckedChanged += new System.EventHandler(this.rboNormal_CheckedChanged);
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
            this.result.Size = new System.Drawing.Size(298, 93);
            this.result.TabIndex = 5;
            // 
            // italic
            // 
            this.italic.AutoSize = true;
            this.italic.Location = new System.Drawing.Point(277, 24);
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
            this.bold.Location = new System.Drawing.Point(224, 25);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pgbdummy);
            this.groupBox1.Controls.Add(this.trbdummy);
            this.groupBox1.Location = new System.Drawing.Point(12, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 106);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "트랙바 및 진행바";
            // 
            // pgbdummy
            // 
            this.pgbdummy.Location = new System.Drawing.Point(6, 71);
            this.pgbdummy.Maximum = 20;
            this.pgbdummy.Name = "pgbdummy";
            this.pgbdummy.Size = new System.Drawing.Size(321, 23);
            this.pgbdummy.TabIndex = 7;
            // 
            // trbdummy
            // 
            this.trbdummy.Location = new System.Drawing.Point(6, 20);
            this.trbdummy.Maximum = 20;
            this.trbdummy.Name = "trbdummy";
            this.trbdummy.Size = new System.Drawing.Size(321, 45);
            this.trbdummy.TabIndex = 6;
            this.trbdummy.Scroll += new System.EventHandler(this.trbdummy_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnmsgbox);
            this.groupBox2.Controls.Add(this.btnmodaless);
            this.groupBox2.Controls.Add(this.btnmodal);
            this.groupBox2.Location = new System.Drawing.Point(18, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 54);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "모달/리스/메시지창";
            // 
            // btnmsgbox
            // 
            this.btnmsgbox.Location = new System.Drawing.Point(168, 20);
            this.btnmsgbox.Name = "btnmsgbox";
            this.btnmsgbox.Size = new System.Drawing.Size(103, 23);
            this.btnmsgbox.TabIndex = 10;
            this.btnmsgbox.Text = "MessageBox";
            this.btnmsgbox.UseVisualStyleBackColor = true;
            this.btnmsgbox.Click += new System.EventHandler(this.btnmsgbox_Click);
            // 
            // btnmodaless
            // 
            this.btnmodaless.Location = new System.Drawing.Point(87, 20);
            this.btnmodaless.Name = "btnmodaless";
            this.btnmodaless.Size = new System.Drawing.Size(75, 23);
            this.btnmodaless.TabIndex = 9;
            this.btnmodaless.Text = "Modaless";
            this.btnmodaless.UseVisualStyleBackColor = true;
            this.btnmodaless.Click += new System.EventHandler(this.btnmodaless_Click);
            // 
            // btnmodal
            // 
            this.btnmodal.Location = new System.Drawing.Point(6, 20);
            this.btnmodal.Name = "btnmodal";
            this.btnmodal.Size = new System.Drawing.Size(75, 23);
            this.btnmodal.TabIndex = 8;
            this.btnmodal.Text = "Modal";
            this.btnmodal.UseVisualStyleBackColor = true;
            this.btnmodal.Click += new System.EventHandler(this.btnmodal_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnaddchild);
            this.groupBox3.Controls.Add(this.btnaddroot);
            this.groupBox3.Controls.Add(this.lsvdummy);
            this.groupBox3.Controls.Add(this.trvdummy);
            this.groupBox3.Location = new System.Drawing.Point(381, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(396, 203);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "트리뷰/리스트뷰";
            // 
            // btnaddchild
            // 
            this.btnaddchild.Location = new System.Drawing.Point(87, 171);
            this.btnaddchild.Name = "btnaddchild";
            this.btnaddchild.Size = new System.Drawing.Size(75, 23);
            this.btnaddchild.TabIndex = 14;
            this.btnaddchild.Text = "자식 추가";
            this.btnaddchild.UseVisualStyleBackColor = true;
            this.btnaddchild.Click += new System.EventHandler(this.btnaddchild_Click);
            // 
            // btnaddroot
            // 
            this.btnaddroot.Location = new System.Drawing.Point(6, 171);
            this.btnaddroot.Name = "btnaddroot";
            this.btnaddroot.Size = new System.Drawing.Size(75, 23);
            this.btnaddroot.TabIndex = 13;
            this.btnaddroot.Text = "루트 추가";
            this.btnaddroot.UseVisualStyleBackColor = true;
            this.btnaddroot.Click += new System.EventHandler(this.btnaddroot_Click);
            // 
            // lsvdummy
            // 
            this.lsvdummy.HideSelection = false;
            this.lsvdummy.Location = new System.Drawing.Point(209, 22);
            this.lsvdummy.Name = "lsvdummy";
            this.lsvdummy.Size = new System.Drawing.Size(174, 143);
            this.lsvdummy.TabIndex = 12;
            this.lsvdummy.UseCompatibleStateImageBehavior = false;
            // 
            // trvdummy
            // 
            this.trvdummy.Location = new System.Drawing.Point(6, 22);
            this.trvdummy.Name = "trvdummy";
            this.trvdummy.Size = new System.Drawing.Size(186, 143);
            this.trvdummy.TabIndex = 11;
            // 
            // btnload
            // 
            this.btnload.Location = new System.Drawing.Point(305, 12);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(79, 29);
            this.btnload.TabIndex = 5;
            this.btnload.Text = "로드";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // pcbdummy
            // 
            this.pcbdummy.Location = new System.Drawing.Point(6, 12);
            this.pcbdummy.Name = "pcbdummy";
            this.pcbdummy.Size = new System.Drawing.Size(293, 110);
            this.pcbdummy.TabIndex = 6;
            this.pcbdummy.TabStop = false;
            this.pcbdummy.Click += new System.EventHandler(this.pcbdummy_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnload);
            this.groupBox4.Controls.Add(this.pcbdummy);
            this.groupBox4.Location = new System.Drawing.Point(381, 230);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(396, 128);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "픽쳐박스";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 386);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxmain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "속성확인";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxmain.ResumeLayout(false);
            this.gbxmain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontsize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbdummy)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbdummy)).EndInit();
            this.groupBox4.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar pgbdummy;
        private System.Windows.Forms.TrackBar trbdummy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnmsgbox;
        private System.Windows.Forms.Button btnmodaless;
        private System.Windows.Forms.Button btnmodal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lsvdummy;
        private System.Windows.Forms.TreeView trvdummy;
        private System.Windows.Forms.Button btnaddchild;
        private System.Windows.Forms.Button btnaddroot;
        private System.Windows.Forms.RadioButton rboIndent;
        private System.Windows.Forms.RadioButton rboNormal;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.PictureBox pcbdummy;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

