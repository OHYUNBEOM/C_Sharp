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

namespace wf04_filecopy
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnFindSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();   // 모달창
            if (result == DialogResult.OK)
            {
                txtSource.Text = dialog.FileName;
            }
        }

        private void btnFindTarget_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtTarget.Text = dialog.FileName;
            }
        }

        // 일반적인 동기식 파일복사
        private void btnSyncCopy_Click(object sender, EventArgs e)
        {
            long totalCopied = CopySync(txtSource.Text, txtTarget.Text);
        }

        private long CopySync(string fromFile, string toFile)
        {
            btnAsyncCopy.Enabled = false;   // 비동기버튼 일시 비활성화
            long totalCopied = 0;

            using (FileStream fromStream = new FileStream(fromFile, FileMode.Open))   // 원본파일 열고
            {
                using (FileStream toStream = new FileStream(toFile, FileMode.Create))   // 타겟파일 생성
                {
                    byte[] buffer = new byte[1024 * 1024];  // 1MByte 버퍼
                    int nRead = 0;
                    while ((nRead = fromStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        toStream.Write(buffer, 0, nRead);
                        totalCopied += nRead;

                        // 프로그레스바에 표시
                        pgbCopy.Value = (int)((double)totalCopied / (double)fromStream.Length) * pgbCopy.Maximum;
                    }
                }
            }
            btnAsyncCopy.Enabled = true;
            return totalCopied;
        }

        // 비동기는 호출할때는 await사용, 구현할때는 async 사용
        private async Task<long> CopyASync(string fromFile, string toFile)
        {
            btnSyncCopy.Enabled = false;
            long totalCopied = 0;

            using (FileStream fromStream = new FileStream(fromFile, FileMode.Open))   // 원본파일 열고
            {
                using (FileStream toStream = new FileStream(toFile, FileMode.Create))   // 타겟파일 생성
                {
                    byte[] buffer = new byte[1024 * 1024];  // 1MByte 버퍼
                    int nRead = 0;
                    while ((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        await toStream.WriteAsync(buffer, 0, nRead);
                        totalCopied += nRead;

                        // 프로그레스바에 표시
                        pgbCopy.Value = (int)((double)totalCopied / (double)fromStream.Length) * pgbCopy.Maximum;
                    }
                }
            }
            btnAsyncCopy.Enabled = true;
            return totalCopied;
        }
        private async void btnAsyncCopy_Click(object sender, EventArgs e)
        {
            long totalCopied = await CopyASync(txtSource.Text, txtTarget.Text);
        }
    }
}