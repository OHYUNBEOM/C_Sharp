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
        Random rnd = new Random(45);
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
            if (fontname.SelectedIndex < 0)
            {
                fontname.SelectedIndex = 275; // 디폴트는 나눔고딕
            }
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

        void changeindent()
        {
            if (rboNormal.Checked) // RadioButton 이벤트
            {
                result.Text = result.Text.Trim();
            }
            else if (rboIndent.Checked)
            {
                result.Text = "    " + result.Text;
            }
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
        private void trbdummy_Scroll(object sender, EventArgs e)
        {
            pgbdummy.Value = trbdummy.Value;
        }
        private void btnmodal_Click(object sender, EventArgs e)
        {
            Form frm = new Form()
            {
                Text = "Modal Form",
                Width = 300,
                Height = 200,
                Left = 10,
                Top = 20,
                BackColor = Color.Crimson,
                StartPosition = FormStartPosition.CenterParent
            };
            frm.ShowDialog(); // 모달 방식으로 새 창 띄우기
        }
        private void btnmodaless_Click(object sender, EventArgs e)
        {
            Form frm = new Form()
            {
                Text = "Modaless Form",
                Width = 300,
                Height = 200,
                StartPosition = FormStartPosition.CenterScreen,//Madaless는 CenterParent 안먹힘
                BackColor = Color.GreenYellow
            };
            frm.Show();//모달리스 방식으로 새창 띄우기
        }
        // 기본적으로 MessageBox는 모달
        private void btnmsgbox_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(result.Text); // 기본
            //MessageBox.Show(result.Text, caption: "메시지창",MessageBoxButtons.YesNoCancel);//버튼추가
            //MessageBox.Show(result.Text, caption: "메시지창", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);//아이콘추가
            MessageBox.Show(result.Text, caption: "메시지창",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);//디폴트버튼설정
            //MessageBox.Show(result.Text, caption: "메시지창", MessageBoxButtons.YesNo, 
            //                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2,MessageBoxOptions.RightAlign);//글자 오른쪽 정렬
        }

        private void btnaddroot_Click(object sender, EventArgs e)
        {
            trvdummy.Nodes.Add(rnd.Next(50).ToString());//0부터 45까지 랜덤으로 생성
        }

        private void btnaddchild_Click(object sender, EventArgs e)
        {
            if(trvdummy.SelectedNode!=null)
            {
                trvdummy.SelectedNode.Nodes.Add(rnd.Next(50, 100).ToString());
                trvdummy.SelectedNode.Expand();//트리노드 하위 펼치기 , 합치기 : Collapse
                treetolist();
            }
        }
        void treetolist()
        {
            lsvdummy.Items.Clear(); //리스트뷰,트리뷰 등 모든 아이템을 제거 및 초기화
            foreach (TreeNode item in trvdummy.Nodes)
            {
                treetolist(item);
            }
        }
        private void treetolist(TreeNode item)
        {
            lsvdummy.Items.Add(
                new ListViewItem(new[]{item.Text,item.FullPath.ToString()}));

            foreach(TreeNode node in item.Nodes)
            {
                treetolist(node);//재귀호출
            }
        }

        private void rboNormal_CheckedChanged(object sender, EventArgs e)
        {
            changeindent();
            //changefontstyle();
        }

        private void rboIndent_CheckedChanged(object sender, EventArgs e)
        {
            changeindent();
            //changefontstyle();
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            pcbdummy.Image = Bitmap.FromFile("cat.png");
        }

        private void pcbdummy_Click(object sender, EventArgs e)
        {
            if(pcbdummy.SizeMode==PictureBoxSizeMode.Normal)
            {
                pcbdummy.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pcbdummy.SizeMode = PictureBoxSizeMode.Normal;
            }
        }
    }
}
