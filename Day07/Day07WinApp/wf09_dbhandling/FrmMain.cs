using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf09_dbhandling
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 1.연결 문자열 생성
            string connectionString = "Data Source=localhost;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=12345";
            // 2.DB 연결을 위해 Connection 객체 생성
            SqlConnection conn = new SqlConnection(connectionString);
            // 3.DB연결
            conn.Open();

            // 4.DB처리를 위한 쿼리 작성
            string selQuery = @"SELECT CustomerID 
                              ,CompanyName
                              ,ContactName
                              ,ContactTitle
                              ,Address
                              ,City
                              ,Region
                              ,PostalCode
                              ,Country
                              ,Phone
                              ,Fax
                          FROM Customers";
            // SqlDataAdapter 생성
            SqlDataAdapter adapter = new SqlDataAdapter(selQuery,conn);
            //SqlCommand selCmd = new SqlCommand(selQuery, conn);
            //selCmd.Connection = conn;

            // 5.리더 객체 생성, 값 넘겨줌
            //SqlDataReader reader = selCmd.ExecuteReader();

            // 6. 데이터셋으로 전달
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            // 7. 데이터그리드뷰에 바인딩하기위한 BindingSource 생성
            BindingSource source = new BindingSource();

            // 8. 데이터그리드뷰의 데이터 소스에 데이터 셋 할당
            source.DataSource = ds.Tables[0];
            DgvNorthwind.DataSource = source;

            // 9. DB Close
            conn.Close();
        }
    }
}
