using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using BookRentalShop.Helpers;

namespace BookRentalShop
{
    public partial class FrmBooks : Form
    {
        bool isNew = false; //false(UPDATE) , true(INSERT)
        #region<생성자>        
        public FrmBooks()
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

            //FK 제약조건으로 지울수 없는 데이터인지 먼저 확인
            using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
            {
                if(conn.State==ConnectionState.Closed)
                {
                    conn.Open();
                }
                //Division을 참조중인지 확인
                string strChkQuery = "SELECT COUNT(*) FROM bookstbl WHERE Division = @Division";
                MySqlCommand chkCmd = new MySqlCommand(strChkQuery, conn);
                MySqlParameter prmDivision = new MySqlParameter("@Division", TxtBookIdx.Text);
                chkCmd.Parameters.Add(prmDivision);

                //ExecuteScalar : 쿼리 실행 후 첫번째 행 첫번째 열의 값을 가져와서 반환해줌
                // --> 해당 Division을 참조하고있는 경우를 모두 세서 result로 넘겨줌
                // B006 클릭 시 result에 9가 넘어옴 Count(*) = 9
                var result = chkCmd.ExecuteScalar();
                if(result.ToString()!="0")
                {
                    MessageBox.Show("FK로 지정되어있는 도서코드입니다.", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
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
                TxtBookIdx.Text = selData.Cells[0].Value.ToString();
                TxtAuthor.Text = selData.Cells[1].Value.ToString();
                TxtBookIdx.ReadOnly = true; // PK 수정 못하도록 막음

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
                    //쿼리 작성 , b.Division으로 뽑아오면 B001처럼 코드만 나오기 때문에
                    // bookstbl과 divtbl을 join 해서 사용자가 알아 볼 수 있는 책 장르로 뽑아와야함
                    var SelQuery = @"SELECT b.bookIdx,
                                            b.Author,
                                            b.Division,
                                            d.Names AS DivNames,
                                            b.Names,
                                            b.ReleaseDate,
                                            b.ISBN,
                                            b.Price
                                         FROM bookstbl As b
                                        INNER JOIN divtbl AS d
                                        on b.Division=d.Division
                                        ORDER BY b.bookIdx ASC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(SelQuery, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "bookstbl");//divtbl으로 DataSet접근가능

                    //39행 / 41행+42행 같은 의미
                    //DgvResult.DataSource = ds.Tables[0];
                    DgvResult.DataSource = ds;
                    DgvResult.DataMember = "bookstbl";

                    //바인딩 된 이후
                    DgvResult.Columns[0].HeaderText = "번호";
                    DgvResult.Columns[1].HeaderText = "저자명";
                    DgvResult.Columns[2].HeaderText = "책장르";
                    DgvResult.Columns[3].HeaderText = "책장르";
                    DgvResult.Columns[4].HeaderText = "책제목";
                    DgvResult.Columns[5].HeaderText = "출판일자";
                    DgvResult.Columns[6].HeaderText = "ISBN";
                    DgvResult.Columns[7].HeaderText = "책가격";

                    DgvResult.Columns[0].Width = 55;
                    DgvResult.Columns[2].Visible = false;//B001과같은 코드영역 안보이게
                    DgvResult.Columns[5].Width = 80;//출판일자
                    DgvResult.Columns[7].Width = 80;//책가격
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearInputs()
        {// 
            TxtBookIdx.Text = TxtAuthor.Text = string.Empty;
            TxtBookIdx.ReadOnly = false;//신규일 땐 입력가능
            TxtBookIdx.Focus();
            isNew = true;//신규
        }
        private bool CheckValidation()
        {//입력검증
            var result = true;
            var errorMsg = string.Empty;

            if (string.IsNullOrEmpty(TxtBookIdx.Text))
            {
                result = false;
                errorMsg += "※ 장르코드을 입력하세요.\r\n";
                //Validation 체크(입력검증)
            }

            if (string.IsNullOrEmpty(TxtAuthor.Text))
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
                    MySqlParameter prmDivision = new MySqlParameter("@Division", TxtBookIdx.Text);
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtAuthor.Text);
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
                    MySqlParameter prmDivision = new MySqlParameter("@Division", TxtBookIdx.Text);
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
