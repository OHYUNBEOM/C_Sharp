using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf07_myexplorer
{
    public partial class FrmExplorer : Form
    {
        public FrmExplorer()
        {
            InitializeComponent();
        }

        private void FrmExplorer_Load(object sender, EventArgs e)
        {
            //현재 사용자
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            LblPath.Text = identity.Name;

            //현재 컴퓨터에 존재하는 드라이브 정보검색,트리뷰에 추가
            DriveInfo[] drives = DriveInfo.GetDrives();
            //트리뷰에 전부 추가
            foreach (DriveInfo drive in drives)
            {
                //실제 존재하는 하드드라이브만
                if(drive.DriveType==DriveType.Fixed)
                {
                    TreeNode rootNode = new TreeNode(drive.Name);
                    rootNode.ImageIndex = 0;
                    rootNode.SelectedImageIndex = 0;
                    TrvDrive.Nodes.Add(rootNode);
                    FillNodes(rootNode);
                }
            }

            TrvDrive.Nodes[0].Expand();

            // 리스트뷰 설정
            LsvFolder.View = View.Details;
            LsvFolder.Columns.Add("이름", LsvFolder.Width / 2, HorizontalAlignment.Left);
            LsvFolder.Columns.Add("날짜", LsvFolder.Width / 4, HorizontalAlignment.Left);
            LsvFolder.Columns.Add("유형", LsvFolder.Width / 5, HorizontalAlignment.Left);
            LsvFolder.Columns.Add("크기", LsvFolder.Width / 5, HorizontalAlignment.Right);

            LsvFolder.FullRowSelect = true;//행 하나를 전부 선택

            CboView.SelectedIndex = 0; // View.Details로 초기화
        }

        private void FillNodes(TreeNode curNode)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(curNode.FullPath);    
                //드라이브 하위폴더
                foreach(DirectoryInfo item in dir.GetDirectories())
                {
                    TreeNode newNode=new TreeNode(item.Name);   
                    newNode.ImageIndex = 1;
                    newNode.SelectedImageIndex = 2;
                    curNode.Nodes.Add(newNode);
                    newNode.Nodes.Add("*");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("트리뷰 오류발생", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //sender : 자기자신 객체 내용, e : 이벤트와 관련된 속성들
        private void TrvDrive_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text=="*")
            {
                e.Node.Nodes.Clear();
                e.Node.ImageIndex = 1; //folder-normal
                e.Node.SelectedImageIndex = 2; //folder-open
                FillNodes(e.Node);//하위폴더 만들기
            }
        }

        private void TrvDrive_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
        }

        private void TrvDrive_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SetLsvFolder(e.Node.FullPath);
        }

        private void SetLsvFolder(string fullPath)
        {
            try
            {
                TxtPath.Text = fullPath; // 현재 경로 입력
                LsvFolder.Items.Clear();//기존리스트 삭제
                DirectoryInfo dir = new DirectoryInfo(fullPath);
                int dirCount = 0;
                foreach(DirectoryInfo item in dir.GetDirectories())
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageIndex = 1;
                    lvi.Text = item.Name;//0번 인덱스 이름 

                    LsvFolder.Items.Add(lvi);
                    LsvFolder.Items[dirCount].SubItems.Add(item.CreationTime.ToString());
                    LsvFolder.Items[dirCount].SubItems.Add("폴더");
                    LsvFolder.Items[dirCount].SubItems.Add(string.Format("{0} files",item.GetFiles().Length.ToString()));

                    dirCount++;
                }//폴더 내 디렉토리 리스트뷰에 리스트업

                //파일목록 리스트업
                FileInfo[] files = dir.GetFiles();
                int fileCount = dirCount; // 이전 카운트가 승계 되어야함
                foreach( FileInfo file in files)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text=file.Name;
                    lvi.ImageIndex = 4;//기본적인 아이콘

                    lvi.ImageIndex = SetExtImg(file.Name);
                    LsvFolder.Items.Add(lvi);

                    if (file.LastWriteTime != null)
                    {
                        LsvFolder.Items[fileCount].SubItems.Add(file.LastWriteTime.ToString());
                    }
                    else
                    {
                        LsvFolder.Items[fileCount].SubItems.Add(file.CreationTime.ToString());
                    }
                    LsvFolder.Items[fileCount].SubItems.Add(file.Attributes.ToString());
                    LsvFolder.Items[fileCount].SubItems.Add(file.Length.ToString());

                    fileCount++;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("리스트뷰 오류발생", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //파일 확장자에 따라 아이콘 변경
        private int SetExtImg(string name)
        {
            FileInfo fInfo = new FileInfo(name);
            string ext = fInfo.Extension; // 확장자를 가져옴
            var exVal = 0;
            switch(ext)
            {
                case ".exe"://실행파일
                    exVal = 3;
                    break;
                case ".png"://이미지파일
                case ".jpg":
                case ".gif":
                    exVal = 5;
                    break;
                default:
                    exVal = 4;
                    break;
            }
            return exVal;
        }

        private void CboView_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(CboView.SelectedIndex)
            {
                case 0://Details
                    LsvFolder.View = View.Details;break;
                case 1:
                    LsvFolder.View = View.SmallIcon;break;
                case 2:
                    LsvFolder.View= View.LargeIcon;break;
                case 3:
                    LsvFolder.View=View.List;break;
                case 4:
                    LsvFolder.View = View.Tile;break;
            }
        }

        //디렉토리 경로 바꿨을 때 처리
        private void TxtPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)//엔터키 누르면
            {
                try
                {
                    SetLsvFolder(e.ToString());
                }
                catch(Exception)
                {
                    MessageBox.Show("경로를 찾을 수 없습니다. 맞춤법을 확인하고 다시 시도하십시오.", "나의 탐색기", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LsvFolder_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(LsvFolder.SelectedItems.Count==1)
            {
                string processPath = TxtPath.Text + "\\" + LsvFolder.SelectedItems[0].Text;
                Process.Start(processPath);
            }
        }
    }
}