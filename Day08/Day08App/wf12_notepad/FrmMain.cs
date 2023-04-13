using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf12_notepad
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//여러파일 선택 안되도록
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName=dialog.FileName;
                TxtPath.Text = fileName;
                FileStream stream = null;
                StreamReader reader = null;
                try
                {
                    stream = new FileStream(fileName, FileMode.Open,FileAccess.Read);
                    reader = new StreamReader(stream,Encoding.UTF8);
                    
                    RtbEditor.Text = reader.ReadToEnd();//끝까지 다 읽어옴
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"오류! {ex.Message}", "Simple NotePad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    reader.Close();
                    stream.Close();
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string fileName = TxtPath.Text;
            FileStream stream = null;
            StreamWriter writer = null;
            try
            {
                stream=new FileStream(fileName, FileMode.Truncate,FileAccess.Write);
                writer = new StreamWriter(stream,Encoding.UTF8);

                writer.WriteLine(RtbEditor.Text);//RichTextbox에 있는 내용을 작성
                writer.Flush(); // Buffer의 데이터를 해당 스트림에 전송

                MessageBox.Show("Save Success!", "Simple NotePad",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류! {ex.Message}", "Simple NotePad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                writer.Close();
                stream.Close();
            }
        }
    }
}
