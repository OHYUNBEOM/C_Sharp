using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using BookRentalShop.Helpers;
using System.Collections.Generic;

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
        private void FrmBooks_Load(object sender, EventArgs e)
        {//DB divtbl 데이터 조회 DgvResult에 뿌림
            isNew = true;//신규부터 시작
            RefreshData();
            LoadCboData();//콤보박스에 들어갈 데이터 로드
            DtpReleaseDate.Format = DateTimePickerFormat.Custom;
            DtpReleaseDate.CustomFormat = "yyyy-MM-dd";//년 월 일
        }
        private void DgvResult_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DgvResult.ClearSelection();//시작될 때 아무것도 선택 안되도록
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
                //rentaltbl을 참조중인지 확인
                string strChkQuery = "SELECT COUNT(*) FROM rentaltbl WHERE bookIdx = @bookIdx";
                MySqlCommand chkCmd = new MySqlCommand(strChkQuery, conn);
                MySqlParameter prmBookIdx = new MySqlParameter("@bookIdx", TxtBookIdx.Text);
                chkCmd.Parameters.Add(prmBookIdx);

                //ExecuteScalar : 쿼리 실행 후 첫번째 행 첫번째 열의 값을 가져와서 반환해줌
                // --> 해당 Division을 참조하고있는 경우를 모두 세서 result로 넘겨줌
                // B006 클릭 시 result에 9가 넘어옴 Count(*) = 9
                var result = chkCmd.ExecuteScalar();
                if(result.ToString()!="0")
                {
                    MessageBox.Show("이미 대여중인 책입니다.", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                CboDivision.SelectedValue = selData.Cells[2].Value;//B001 == B001
                //selData.Cells[3] 사용 안함
                TxtNames.Text = selData.Cells[4].Value.ToString();
                DtpReleaseDate.Value = (DateTime)selData.Cells[5].Value;
                TxtISBN.Text= selData.Cells[6].Value.ToString();
                NudPrice.Value = (Decimal)selData.Cells[7].Value;

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
                    //데이터그리드뷰 컬럼 헤더 제목
                    DgvResult.Columns[0].HeaderText = "번호";
                    DgvResult.Columns[1].HeaderText = "저자명";
                    DgvResult.Columns[2].HeaderText = "책장르";
                    DgvResult.Columns[3].HeaderText = "책장르";
                    DgvResult.Columns [4].HeaderText = "책제목";
                    DgvResult.Columns[5].HeaderText = "출판일자";
                    DgvResult.Columns[6].HeaderText = "ISBN";
                    DgvResult.Columns[7].HeaderText = "책가격";
                    //컬럼 넓이 또는 보이기
                    DgvResult.Columns[0].Width = 55;
                    DgvResult.Columns[2].Visible = false;//B001과같은 코드영역 안보이게
                    DgvResult.Columns[5].Width = 80;//출판일자
                    DgvResult.Columns[7].Width = 80;//책가격
                    //컬럼 정렬
                    DgvResult.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    DgvResult.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DgvResult.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"RefreshData() 비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearInputs()
        {// 
            TxtBookIdx.Text = TxtAuthor.Text = string.Empty;
            TxtNames.Text = TxtISBN.Text = string.Empty;
            CboDivision.SelectedIndex = -1;//아무것도 선택 안된상태
            DtpReleaseDate.Value = DateTime.Now;
            NudPrice.Value = 0;
            TxtAuthor.Focus();//번호는 ReadOnly라서 저자로 focus줌
            isNew = true;//신규
        }
        private bool CheckValidation()
        {//입력검증
            var result = true;
            var errorMsg = string.Empty;
            if (string.IsNullOrEmpty(TxtAuthor.Text))
            {
                result = false;
                errorMsg += "※ 저자명을 입력하세요\r\n";
                //Validation 체크(입력검증)
            }
            if (CboDivision.SelectedIndex<0)
            {
                result = false;
                errorMsg += "※ 장르를 선택하세요\r\n";
                //Validation 체크(입력검증)
            }
            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                result = false;
                errorMsg += "※ 책제목을 입력하세요\r\n";
                //Validation 체크(입력검증)
            }
            if (DtpReleaseDate.Value==null)
            {
                result = false;
                errorMsg += "※ 출판일자를 선택하세요\r\n";
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
            // pk인 bookidx 는 auto increment상태라서 하나 저장하고 삭제했으면 
            // 삭제된 bookidx로 동일하게 삽입이 안됨 즉 새로 저장해서 번호60으로 책을 넣었다가
            // 삭제버튼을 통해서 60번을 삭제하면 새로운 책 저장할 때 61번으로 들어감
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
                        query = @"INSERT INTO bookstbl
                                            (Author,
                                            Division,
                                            Names,
                                            ReleaseDate,
                                            ISBN,
                                            Price)
                                            VALUES
                                            (@Author,
                                            @Division,
                                            @Names,
                                            @ReleaseDate,
                                            @ISBN,
                                            @Price)";
                    }
                    else//신규가 아니면 Update
                    {
                        query = @"UPDATE bookstbl
                                    SET
	                                    Author = @Author,
	                                    Division = @Division,
	                                    Names = @Names,
	                                    ReleaseDate = @ReleaseDate,
	                                    ISBN = @ISBN,
	                                    Price = @Price
                                    WHERE bookIdx = @bookIdx";
                    }
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmAuthor = new MySqlParameter("@Author", TxtAuthor.Text);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", CboDivision.SelectedValue.ToString());
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtNames.Text);
                    MySqlParameter prmReleaseDate = new MySqlParameter("@ReleaseDate", DtpReleaseDate.Value);
                    MySqlParameter prmISBN = new MySqlParameter("@ISBN", TxtISBN.Text);
                    MySqlParameter prmPrice = new MySqlParameter("@Price", NudPrice.Value);
                    cmd.Parameters.Add(prmAuthor);
                    cmd.Parameters.Add(prmDivision);
                    cmd.Parameters.Add(prmNames);
                    cmd.Parameters.Add(prmReleaseDate);
                    cmd.Parameters.Add(prmISBN);
                    cmd.Parameters.Add(prmPrice);

                    if (isNew == false)//update할 때는 bookidx 파라미터를 추가해줘야함
                    {
                        MySqlParameter prmBookIdx = new MySqlParameter("@bookIdx", TxtBookIdx.Text);
                        cmd.Parameters.Add(prmBookIdx);
                    }

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
                MessageBox.Show($"SaveData() 비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var query = @"DELETE FROM bookstbl
	                              WHERE bookIdx = @bookidx";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmBookIdx = new MySqlParameter("@bookIdx", TxtBookIdx.Text);
                    cmd.Parameters.Add(prmBookIdx);

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
                MessageBox.Show($"DeleteData() 비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //콤보박스에 뿌려주는 함수 
        private void LoadCboData()
        {
            try
            {
                using(MySqlConnection conn = new MySqlConnection(Commons.ConnString))
                {
                    if(conn.State== ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    var query = "SELECT Division, Names From divtbl";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>();
                    while (reader.Read())
                    {
                        //(Key)B001, (Value)공포/스릴러
                        temp.Add(reader[0].ToString(), reader[1].ToString());
                    }
                    //콤보박스에 할당
                    CboDivision.DataSource = new BindingSource(temp, null);
                    CboDivision.DisplayMember = "Value";
                    CboDivision.ValueMember = "Key";
                    CboDivision.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LoadCboData() 비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
