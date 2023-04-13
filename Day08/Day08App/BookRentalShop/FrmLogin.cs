using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookRentalShop
{
    public partial class FrmLogin : Form
    {
        private bool isLogined = false;//로그인 성공/실패 유무
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            isLogined = LoginProcess();//로그인 성공 시 true
            if (isLogined)
            {
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Environment.Exit(0);//완전 종료
        }

        //해당 이벤트 작성하지 않으면 X 버튼, Alt+F4 했을 때 메인폼이 그대로 나타남
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isLogined != true)//로그인 실패 시 창 닫으면 프로그램 모두 종료
            {
                Environment.Exit(0);
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//엔터 입력 시
            {
                BtnLogin_Click(sender, e);//버튼클릭 이벤트 핸들러 호출
            }
        }
        private void TxtUserid_KeyPress(object sender, KeyPressEventArgs e)
        {//useridTextBox에서 Enter 입력 시
            if (e.KeyChar == 13)
            {
                TxtPassword.Focus();
            }
        }
        //로그인 핵심 , DB userTBL에서 정보 확인 로그인 처리
        private bool LoginProcess()
        {
            //Validation Check(id,pwd가 null 이나 빈값이면)
            if (string.IsNullOrEmpty(TxtUserid.Text) || string.IsNullOrEmpty(TxtPassword.Text))
            {
                MessageBox.Show("아이디/패스워드를 입력하세요!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string strUserId = "";
            string strPassword = "";

            try
            {
                string connectionSTring = "Server=localhost;Port=3306;Database=bookrentalShop;Uid=root;Pwd=12345";
                //DB처리
                using (MySqlConnection conn = new MySqlConnection(connectionSTring))
                {
                    conn.Open();
                    #region<DB 쿼리를 위한 구성>
                    string selQuery = @"SELECT userid
                                            , password
                                        FROM usertbl
                                        WHERE userid = @userid AND password = @password";
                    MySqlCommand selCmd = new MySqlCommand(selQuery, conn);
                    //@userid와 @password 할당 해줘야함
                    MySqlParameter prmUserid = new MySqlParameter("@userid", TxtUserid.Text);
                    MySqlParameter prmPassword = new MySqlParameter("@password", TxtPassword.Text);

                    selCmd.Parameters.Add(prmUserid);
                    selCmd.Parameters.Add(prmPassword);
                    #endregion

                    MySqlDataReader reader = selCmd.ExecuteReader();//userid,password 받아옴
                    reader.Read();

                    strUserId = reader["userid"] != null ? reader["userid"].ToString() : "-";//null이 아니면 tostring, DB의 userid 정보 받아와서 문자열 형태로 바꾼 후 strUserID에 저장
                    strPassword = reader["password"] != null ? reader["password"].ToString() : "--";//null이아니면 DB의 password 받아와서 문자열 형태로 바꾼 후 strPassword에 저장

                    return true;

                }//conn.Close() <- using 키워드를 사용하면 close 필요없음
            }
            catch (Exception ex)
            {
                MessageBox.Show("로그인 정보 오류!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
