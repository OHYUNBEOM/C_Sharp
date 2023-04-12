using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf11_mditest
{
    public partial class FrmMain : Form
    {
        FrmChild1 child1 = null;
        FrmChild2 child2 = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void MniForm1_Click(object sender, EventArgs e)
        {//폼1 클릭 시
            child1 = new FrmChild1();
            child1.TopLevel = false;
            //toplevel을 false로 수정해야 최상위 클래스를 FrmMain으로 잡고 그밑에다 생성
            this.Controls.Add(child1);
            child1.Show();
        }

        private void MniForm2_Click(object sender, EventArgs e)
        {//폼2 클릭 시
            child2=new FrmChild2();
            child2.TopLevel = false;
            this.Controls.Add(child2);
            child2.Show();
        }

        private void MniExit_Click(object sender, EventArgs e)
        {//끝내기 클릭
            Application.Exit();
        }

        private void MniAbout_Click(object sender, EventArgs e)
        {//이 프로그램 클릭 시
            FrmAbout about = new FrmAbout();
            about.ShowDialog();
        }
    }
}
