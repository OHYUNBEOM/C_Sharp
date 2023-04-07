using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf05_loginui
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtid.Text=="abcd" && txtpw.Text=="1234")
            {
                lblResult.Text = "로그인 성공";
            }
            else
            {
                lblResult.Text = "로그인 실패";
            }
        }

        private void txtpw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
