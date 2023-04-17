using BookRentalShop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShop
{
    public partial class FrmMain : Form
    {
        #region <각화면 폼>
        FrmGenre frmGenre = null; // 책장르관리 객체변수
        FrmBooks frmBooks = null;
        #endregion
        #region<생성자>
        public FrmMain()
        {
            InitializeComponent();
        }
        #endregion
        #region<이벤트 핸들러>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmLogin frm= new FrmLogin();
            frm.ShowDialog();

            LblUserID.Text = Commons.LoginID;
            LblLoginDatetime.Text ="/ "+DateTime.Now.ToString();
        }
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();//전체 프로그램 종료
        }

        private void MniGenre_Click(object sender, EventArgs e)
        {
            //FrmGenre frm = new FrmGenre();
            //frm.TopLevel = false;
            //this.Controls.Add(frm);
            //frm.Show();
            frmGenre = ShowActiveForm(frmGenre, typeof(FrmGenre)) as FrmGenre;
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void MniBookInfo_Click(object sender, EventArgs e)
        {
            frmBooks = ShowActiveForm(frmBooks, typeof(FrmBooks)) as FrmBooks;
        }

        private void MniMember_Click(object sender, EventArgs e)
        {

        }

        private void MniRental_Click(object sender, EventArgs e)
        {

        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
        //새 자식창을 띄울 때 다른 자식창은 전부다 닫고 시작
        private Form ShowActiveForm(Form form, Type type)
        {
            if(form == null)//한번도 자식창을 열지 않았을 때
            {
                form=(Form)Activator.CreateInstance(type);//리플렉션으로 타입에 맞는 창을 새로 생성
                form.MdiParent = this;//FrmMain이 MDI부모
                form.WindowState = FormWindowState.Normal;
                form.Show();
            }
            else
            {
                if(form.IsDisposed)//컨트롤이 제거됐으면, 한번 닫혔을때
                {
                    form = (Form)Activator.CreateInstance(type);//리플렉션으로 타입에 맞는 창을 새로 생성
                    form.MdiParent = this;//FrmMain이 MDI부모
                    form.WindowState = FormWindowState.Normal;
                    form.Show();
                }
                else// 창이 열려있을 때
                {
                    form.Activate();//화면이 있으면 해당 화면 활성화
                }
            }
            return form;
        }
    }
}
