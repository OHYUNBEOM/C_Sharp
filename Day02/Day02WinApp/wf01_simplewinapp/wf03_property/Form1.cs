using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf03_property
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //생성자에서 되도록 설정부분 넣지 않는다
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gbxmain.Text = "컨트롤 학습";
            var fonts = FontFamily.Families.ToList(); // 내 OS 폰트명 가져오기
            foreach ( var font in fonts ) 
            {
                fontname.Items.Add( font.Name );
            }
            //글자크기 min,max 값 지정
            fontsize.Minimum = 5;fontsize.Maximum = 40;
            //텍스트박스 초기화
            result.Text = "Hello, WinForm";
        }

        private void changefontstyle()
        {
            if (fontname.SelectedIndex < 0) return;
            FontStyle style = FontStyle.Regular;
            if(bold.Checked==true)
            {
                style |= FontStyle.Bold;
            }
            if(italic.Checked==true) 
            {
                style |= FontStyle.Italic;
            }
            decimal font_size=fontsize.Value; // font_size를 fontsize.Value 값으로 바꿈
            result.Font = new Font((string)fontname.SelectedItem, (float)font_size, style);
        }

        private void fontname_SelectedIndexChanged(object sender, EventArgs e)
        {
            changefontstyle();
        }

        private void bold_CheckedChanged(object sender, EventArgs e)
        {
            changefontstyle();
        }

        private void italic_CheckedChanged(object sender, EventArgs e)
        {
            changefontstyle();
        }

        private void fontsize_ValueChanged(object sender, EventArgs e)
        {
            changefontstyle();
        }
    }
}
