using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BookRentalShop
{
    public partial class FrmGenre : Form
    {
        bool isNew = false; //false(UPDATE) , true(INSERT)
        #region<생성자>        
        public FrmGenre()
        {
            InitializeComponent();
        }
        #endregion

        #region<이벤트 핸들러>
        private void FrmGenre_Load(object sender, EventArgs e)
        {//DB divtbl 데이터 조회 DgvResult에 뿌림
            isNew = true;//신규부터 시작
            RefreshData();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidation() != true)
            {
                return;
            }
            //INSERT(신규) 
            SaveData();//데이터 저장/수정
            RefreshData();//신규 저장 되자마자 다시 그려주면서 뿌리기
            ClearInputs();//입력창 클리어
        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (isNew == true) // 신규일때는 삭제 x
            {
                MessageBox.Show("삭제할 데이터를 선택하세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //아니오 클릭 시 삭제 진행 X
            if (MessageBox.Show(this, "삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //Yes를 누르면 계속 진행 -> SaveData()에 있는 로직을 그대로 사용

            DeleteData();//데이터 삭제처리
            RefreshData();//지우고나서 재조회
            ClearInputs();//입력창 데이터 지우기
        }
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {//GridView(책장르목록) 을 클릭하면 발생 이벤트
            if (e.RowIndex > -1)//첫번째 인덱스 선택하면 RowIndex : 0
            {
                var selData = DgvResult.Rows[e.RowIndex];
                //Debug.WriteLine(selData.ToString()); //디버깅 하지 않고 출력으로 결과값 바로 보고싶을 때 
                //Debug.WriteLine(selData.Cells[0].Value);//B002 출력
                //Debug.WriteLine(selData.Cells[1].Value);//로맨스 출력
                TxtDivision.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();
                TxtDivision.ReadOnly = true; // PK 수정 못하도록 막음

                //수정,PK는 수정 못함
                isNew = false;
            }
        }
        #endregion

        #region <커스텀 메서드>
        private void RefreshData()
        {//DB divtbl 데이터 조회 후 DgvResult에 뿌려줌
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    //쿼리 작성
                    var SelQuery = @"SELECT Division
	                                        , Names
                                        FROM divtbl";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(SelQuery, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "divtbl");//divtbl으로 DataSet접근가능

                    //39행 / 41행+42행 같은 의미
                    //DgvResult.DataSource = ds.Tables[0];
                    DgvResult.DataSource = ds;
                    DgvResult.DataMember = "divtbl";

                    //바인딩 된 이후
                    DgvResult.Columns[0].HeaderText = "장르코드";
                    DgvResult.Columns[1].HeaderText = "장르명";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearInputs()
        {// 
            TxtDivision.Text = TxtNames.Text = string.Empty;
            TxtDivision.ReadOnly = false;//신규일 땐 입력가능
            TxtDivision.Focus();
            isNew = true;//신규
        }
        private bool CheckValidation()
        {//입력검증
            var result = true;
            var errorMsg = string.Empty;

            if (string.IsNullOrEmpty(TxtDivision.Text))
            {
                result = false;
                errorMsg += "※ 장르코드을 입력하세요.\r\n";
                //Validation 체크(입력검증)
            }

            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                result = false;
                errorMsg += "※ 장르명을 입력하세요\r\n";
                //Validation 체크(입력검증)
            }
            if (result == false)
            {
                MessageBox.Show(errorMsg, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }
            else
            {
                return result;
            }
        }
        private void SaveData()
        {// isNew=true이면 Insert이고 isNew=False이면 Udpate
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    var query = "";
                    if (isNew)//신규일때는 Insert
                    {
                        query = @"INSERT INTO divtbl
	                              VALUES(@Division, @Names)";
                    }
                    else//신규가 아니면 Update
                    {
                        query = @"UPDATE divtbl
	                                SET Names = @Names
                                    WHERE Division = @Division";
                    }
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", TxtDivision.Text);
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtNames.Text);
                    cmd.Parameters.Add(prmDivision);
                    cmd.Parameters.Add(prmNames);

                    // 2개를 UPDATE하면 result값으로 2 들어감
                    var result = cmd.ExecuteNonQuery();//INSERT,UPDATE,DELETE 시 실행

                    if (result != 0)
                    {
                        //저장성공
                        MessageBox.Show("저장 성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //저장실패
                        MessageBox.Show("저장실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteData()
        {//데이터 삭제
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    var query = @"DELETE FROM divtbl
	                              WHERE Division = @Division";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", TxtDivision.Text);
                    cmd.Parameters.Add(prmDivision);

                    // 2개를 UPDATE하면 result값으로 2 들어감
                    var result = cmd.ExecuteNonQuery();//INSERT,UPDATE,DELETE 시 실행

                    if (result != 0)
                    {
                        //삭제성공
                        MessageBox.Show("삭제 성공!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //삭제실패
                        MessageBox.Show("삭제실패!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
