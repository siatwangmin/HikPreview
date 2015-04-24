using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

using System.Runtime.InteropServices;


using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Util;
using Emgu.CV.Structure;

namespace PreviewDemo
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Preview : System.Windows.Forms.Form
	{
        private uint iLastErr = 0;
		private Int32 m_lUserID = -1;
		private bool m_bInitSDK = false;
        private bool m_bRecord = false;
		private Int32 m_lRealHandle = -1;
        private string str;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnPreview;
		private System.Windows.Forms.PictureBox RealPlayWnd;
        private TextBox textBoxIP;
        private TextBox textBoxPort;
        private TextBox textBoxUserName;
        private TextBox textBoxPassword;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button btnBMP;
        private Button btnJPEG;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox textBoxChannel;
        private Button btnRecord;
        private Label label14;
        private Button btn_Exit;
        private Button btnPTZ;
        private Label label15;
        private Button button1;
        private TextBox mytb;
        private Button btnStartVoice;
        private Button btnStartSpeek;
        private Button btnAudioPreview;
        private Button btnUdp;
        private Panel panel1;
        private Label label16;
        private Label label17;
        private Panel panel2;
        private Panel panel3;
        private Button btnDraw;
        private Button btnCapture;
        private PictureBox pictureBoxTest;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Preview()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

		    MessageBox.Show(System.Environment.CurrentDirectory);

			m_bInitSDK = CHCNetSDK.NET_DVR_Init();
			if (m_bInitSDK == false)
			{
				MessageBox.Show("NET_DVR_Init error!");
				return;
			}
			else
			{
                //����SDK��־ To save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
			}
			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (m_lRealHandle >= 0)
			{
				CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle);
			}
			if (m_lUserID >= 0)
			{
				CHCNetSDK.NET_DVR_Logout(m_lUserID);
			}
			if (m_bInitSDK == true)
			{
				CHCNetSDK.NET_DVR_Cleanup();
			}
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.RealPlayWnd = new System.Windows.Forms.PictureBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBMP = new System.Windows.Forms.Button();
            this.btnJPEG = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxChannel = new System.Windows.Forms.TextBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btnPTZ = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.mytb = new System.Windows.Forms.TextBox();
            this.btnStartVoice = new System.Windows.Forms.Button();
            this.btnStartSpeek = new System.Windows.Forms.Button();
            this.btnAudioPreview = new System.Windows.Forms.Button();
            this.btnUdp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.pictureBoxTest = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RealPlayWnd)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Device IP";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "User Name";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(234, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(234, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Device Port";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(435, 38);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(78, 50);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(13, 73);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(76, 34);
            this.btnPreview.TabIndex = 7;
            this.btnPreview.Text = "Live View";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // RealPlayWnd
            // 
            this.RealPlayWnd.BackColor = System.Drawing.SystemColors.WindowText;
            this.RealPlayWnd.Location = new System.Drawing.Point(18, 104);
            this.RealPlayWnd.Name = "RealPlayWnd";
            this.RealPlayWnd.Size = new System.Drawing.Size(495, 405);
            this.RealPlayWnd.TabIndex = 4;
            this.RealPlayWnd.TabStop = false;
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(78, 24);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(114, 21);
            this.textBoxIP.TabIndex = 2;
            this.textBoxIP.Text = "192.168.1.64";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(308, 24);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(112, 21);
            this.textBoxPort.TabIndex = 3;
            this.textBoxPort.Text = "8000";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(78, 70);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(114, 21);
            this.textBoxUserName.TabIndex = 4;
            this.textBoxUserName.Text = "admin";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPassword.Location = new System.Drawing.Point(308, 70);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(112, 21);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.Text = "12345";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "�豸IP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "�豸�˿�";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "�û���";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "����";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "Ԥ��";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(442, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "��¼";
            // 
            // btnBMP
            // 
            this.btnBMP.Location = new System.Drawing.Point(106, 74);
            this.btnBMP.Name = "btnBMP";
            this.btnBMP.Size = new System.Drawing.Size(79, 34);
            this.btnBMP.TabIndex = 8;
            this.btnBMP.Text = "Capture BMP ";
            this.btnBMP.UseVisualStyleBackColor = true;
            this.btnBMP.Click += new System.EventHandler(this.btnBMP_Click);
            // 
            // btnJPEG
            // 
            this.btnJPEG.Location = new System.Drawing.Point(204, 73);
            this.btnJPEG.Name = "btnJPEG";
            this.btnJPEG.Size = new System.Drawing.Size(97, 34);
            this.btnJPEG.TabIndex = 9;
            this.btnJPEG.Text = "Capture JPEG";
            this.btnJPEG.UseVisualStyleBackColor = true;
            this.btnJPEG.Click += new System.EventHandler(this.btnJPEG_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(109, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 17;
            this.label11.Text = "BMPץͼ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(210, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "JPEGץͼ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 12);
            this.label13.TabIndex = 19;
            this.label13.Text = "Ԥ��/ץͼͨ��";
            // 
            // textBoxChannel
            // 
            this.textBoxChannel.Location = new System.Drawing.Point(104, 15);
            this.textBoxChannel.Name = "textBoxChannel";
            this.textBoxChannel.Size = new System.Drawing.Size(100, 21);
            this.textBoxChannel.TabIndex = 6;
            this.textBoxChannel.Text = "1";
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(14, 42);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(100, 34);
            this.btnRecord.TabIndex = 10;
            this.btnRecord.Text = "Start Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 22;
            this.label14.Text = "�ͻ���¼��";
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(133, 86);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 32);
            this.btn_Exit.TabIndex = 11;
            this.btn_Exit.Tag = "";
            this.btn_Exit.Text = "�˳� Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btnPTZ
            // 
            this.btnPTZ.Location = new System.Drawing.Point(133, 42);
            this.btnPTZ.Name = "btnPTZ";
            this.btnPTZ.Size = new System.Drawing.Size(75, 34);
            this.btnPTZ.TabIndex = 23;
            this.btnPTZ.Text = "PTZ";
            this.btnPTZ.UseVisualStyleBackColor = true;
            this.btnPTZ.Click += new System.EventHandler(this.btnPTZ_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(144, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 24;
            this.label15.Text = "��̨����";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 34);
            this.button1.TabIndex = 25;
            this.button1.Text = "ץͼ���ڴ�";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mytb
            // 
            this.mytb.Location = new System.Drawing.Point(91, 118);
            this.mytb.Name = "mytb";
            this.mytb.Size = new System.Drawing.Size(97, 21);
            this.mytb.TabIndex = 26;
            this.mytb.Text = "0";
            // 
            // btnStartVoice
            // 
            this.btnStartVoice.Location = new System.Drawing.Point(88, 1);
            this.btnStartVoice.Name = "btnStartVoice";
            this.btnStartVoice.Size = new System.Drawing.Size(90, 30);
            this.btnStartVoice.TabIndex = 27;
            this.btnStartVoice.Text = "��ʼ�Խ�";
            this.btnStartVoice.UseVisualStyleBackColor = true;
            this.btnStartVoice.Click += new System.EventHandler(this.btnStartVoice_Click);
            // 
            // btnStartSpeek
            // 
            this.btnStartSpeek.Location = new System.Drawing.Point(88, 37);
            this.btnStartSpeek.Name = "btnStartSpeek";
            this.btnStartSpeek.Size = new System.Drawing.Size(90, 30);
            this.btnStartSpeek.TabIndex = 28;
            this.btnStartSpeek.Text = "PC�㲥";
            this.btnStartSpeek.UseVisualStyleBackColor = true;
            this.btnStartSpeek.Click += new System.EventHandler(this.btnStartSpeek_Click);
            // 
            // btnAudioPreview
            // 
            this.btnAudioPreview.Location = new System.Drawing.Point(88, 80);
            this.btnAudioPreview.Name = "btnAudioPreview";
            this.btnAudioPreview.Size = new System.Drawing.Size(90, 30);
            this.btnAudioPreview.TabIndex = 29;
            this.btnAudioPreview.Text = "������Ԥ��";
            this.btnAudioPreview.UseVisualStyleBackColor = true;
            this.btnAudioPreview.Click += new System.EventHandler(this.btnAudioPreview_Click);
            // 
            // btnUdp
            // 
            this.btnUdp.Location = new System.Drawing.Point(17, 92);
            this.btnUdp.Name = "btnUdp";
            this.btnUdp.Size = new System.Drawing.Size(110, 23);
            this.btnUdp.TabIndex = 30;
            this.btnUdp.Text = "��ΪUDPЭ�鴫��";
            this.btnUdp.UseVisualStyleBackColor = true;
            this.btnUdp.Click += new System.EventHandler(this.btnUdp_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.btnStartVoice);
            this.panel1.Controls.Add(this.btnStartSpeek);
            this.panel1.Controls.Add(this.btnAudioPreview);
            this.panel1.Location = new System.Drawing.Point(543, 327);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 119);
            this.panel1.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 30;
            this.label16.Text = "�����Խ�";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 127);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 32;
            this.label17.Text = "ץͼ�ֱ���";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnJPEG);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.btnPreview);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnBMP);
            this.panel2.Controls.Add(this.mytb);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.textBoxChannel);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(543, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 165);
            this.panel2.TabIndex = 33;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnPTZ);
            this.panel3.Controls.Add(this.btnRecord);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.btnUdp);
            this.panel3.Controls.Add(this.btn_Exit);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Location = new System.Drawing.Point(543, 183);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 129);
            this.panel3.TabIndex = 34;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(543, 452);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(90, 30);
            this.btnDraw.TabIndex = 35;
            this.btnDraw.Text = "�����ַ�";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(543, 503);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(97, 23);
            this.btnCapture.TabIndex = 36;
            this.btnCapture.Text = "�򿪱�������ͷ";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // pictureBoxTest
            // 
            this.pictureBoxTest.Location = new System.Drawing.Point(90, 516);
            this.pictureBoxTest.Name = "pictureBoxTest";
            this.pictureBoxTest.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxTest.TabIndex = 37;
            this.pictureBoxTest.TabStop = false;
            // 
            // Preview
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(882, 600);
            this.Controls.Add(this.pictureBoxTest);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.RealPlayWnd);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Name = "Preview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview";
            ((System.ComponentModel.ISupportInitialize)(this.RealPlayWnd)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Preview());
		}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnLogin_Click(object sender, System.EventArgs e)
		{
			if (textBoxIP.Text == "" || textBoxPort.Text == "" ||
				textBoxUserName.Text == "" || textBoxPassword.Text == "")
			{
				MessageBox.Show("Please input IP, Port, User name and Password!");
				return;
			}
            if (m_lUserID < 0)
            {
                string DVRIPAddress = textBoxIP.Text; //�豸IP��ַ��������
                Int16 DVRPortNumber = Int16.Parse(textBoxPort.Text);//�豸����˿ں�
                string DVRUserName = textBoxUserName.Text;//�豸��¼�û���
                string DVRPassword = textBoxPassword.Text;//�豸��¼����

                CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                //��¼�豸 Login the device
                m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                if (m_lUserID < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //��¼ʧ�ܣ���������
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    //��¼�ɹ�
                    MessageBox.Show("Login Success!");
                    btnLogin.Text = "Logout";
                }

            }
            else
            {
                //ע����¼ Logout the device
                if (m_lRealHandle >= 0)
                {
                    MessageBox.Show("Please stop live view firstly");
                    return;
                }

                if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_Logout failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;           
                }
                m_lUserID = -1;
                btnLogin.Text = "Login";
            }
            return;
		}

		private void btnPreview_Click(object sender, System.EventArgs e)
		{
            if(m_lUserID < 0)
            {
                MessageBox.Show("Please login the device firstly");
                return;
            }

            if (m_lRealHandle < 0)
            {
                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                lpPreviewInfo.hPlayWnd = RealPlayWnd.Handle;//Ԥ������
                lpPreviewInfo.lChannel = Int16.Parse(textBoxChannel.Text);//Ԥte�����豸ͨ��
                lpPreviewInfo.dwStreamType = 0;//�������ͣ�0-��������1-��������2-����3��3-����4���Դ�����
                lpPreviewInfo.dwLinkMode = 1;//���ӷ�ʽ��0- TCP��ʽ��1- UDP��ʽ��2- �ಥ��ʽ��3- RTP��ʽ��4-RTP/RTSP��5-RSTP/HTTP 
                lpPreviewInfo.bBlocked = true; //0- ������ȡ����1- ����ȡ��

                CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//Ԥ��ʵʱ���ص�����
                IntPtr pUser = new IntPtr();//�û�����

                //��Ԥ�� Start live view 
                m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                if (m_lRealHandle < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //Ԥ��ʧ�ܣ���������
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    //Ԥ���ɹ�
                    btnPreview.Text = "Stop Live View";
                }
            }
            else
            {
                //ֹͣԤ�� Stop live view 
                if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopRealPlay failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                m_lRealHandle = -1;
                btnPreview.Text = "Live View";

            }
            return;
		}

		public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
		{
		}

        private void btnBMP_Click(object sender, EventArgs e)
        {
            string sBmpPicFileName;
            //ͼƬ����·�����ļ��� the path and file name to save
            sBmpPicFileName = "BMP_test.bmp"; 

            //BMPץͼ Capture a BMP picture
            if (!CHCNetSDK.NET_DVR_CapturePicture(m_lRealHandle, sBmpPicFileName))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_CapturePicture failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }
            else
            {
                str = "Successful to capture the BMP file and the saved file is " + sBmpPicFileName;
                MessageBox.Show(str); 
            }
            return;
        }

        private void btnJPEG_Click(object sender, EventArgs e)
        {
            string sJpegPicFileName;
            //ͼƬ����·�����ļ��� the path and file name to save
            sJpegPicFileName = "JPEG_test.jpg";

            int lChannel = Int16.Parse(textBoxChannel.Text); //ͨ���� Channel number

            CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA();
            lpJpegPara.wPicQuality = 0;//0; //ͼ������ Image quality
            lpJpegPara.wPicSize = ushort.Parse(mytb.Text);///0xff; //ץͼ�ֱ��� Picture size: 2- 4CIF��0xff- Auto(ʹ�õ�ǰ�����ֱ���)��ץͼ�ֱ�����Ҫ�豸֧�֣�����ȡֵ��ο�SDK�ĵ�

            //JPEGץͼ Capture a JPEG picture
            if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture(m_lUserID, lChannel, ref lpJpegPara, sJpegPicFileName))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_CaptureJPEGPicture failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }
            else
            {
                str = "Successful to capture the JPEG file and the saved file is " + sJpegPicFileName;
                MessageBox.Show(str);
            }
            return;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            //¼�񱣴�·�����ļ��� the path and file name to save
            string sVideoFileName;
            sVideoFileName = "Record_test.mp4";

            if (m_bRecord == false)
            {
                //ǿ��I֡ Make a I frame
                int lChannel = Int16.Parse(textBoxChannel.Text); //ͨ���� Channel number
                CHCNetSDK.NET_DVR_MakeKeyFrame(m_lUserID, lChannel);

                //��ʼ¼�� Start recording
                if (!CHCNetSDK.NET_DVR_SaveRealData(m_lRealHandle, sVideoFileName))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_SaveRealData failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                else
                {                  
                    btnRecord.Text = "Stop Record";
                    m_bRecord = true;
                }
            }
            else
            {
                //ֹͣ¼�� Stop recording
                if (!CHCNetSDK.NET_DVR_StopSaveRealData(m_lRealHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopSaveRealData failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    str = "Successful to stop recording and the saved file is " + sVideoFileName;
                    MessageBox.Show(str);
                    btnRecord.Text = "Start Record";
                    m_bRecord = false;
                }            
            }

            return;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //ֹͣԤ�� Stop live view 
            if (m_lRealHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle);
                m_lRealHandle = -1;
            }

            //ע����¼ Logout the device
            if (m_lUserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
                m_lUserID = -1;
            }

            CHCNetSDK.NET_DVR_Cleanup();

            Application.Exit();
        }

        private void btnPTZ_Click(object sender, EventArgs e)
        {
            PTZControl dlg = new PTZControl();
            dlg.m_lUserID = m_lUserID;
            dlg.m_lChannel = 1;
            dlg.m_lRealHandle = m_lRealHandle;
            dlg.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sJpegPicFileName;
            //ͼƬ����·�����ļ��� the path and file name to save
            sJpegPicFileName = "JPEG_test.jpg";

            int lChannel = Int16.Parse(textBoxChannel.Text); //ͨ���� Channel number

            CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA();
            lpJpegPara.wPicQuality = 0; //ͼ������ Image quality
            lpJpegPara.wPicSize = ushort.Parse(mytb.Text); //ץͼ�ֱ��� Picture size: 2- 4CIF��0xff- Auto(ʹ�õ�ǰ�����ֱ���)��ץͼ�ֱ�����Ҫ�豸֧�֣�����ȡֵ��ο�SDK�ĵ�

            byte[] buffer = new byte[102400];
            uint lpSizeReturned = new uint();
            //JPEGץͼ Capture a JPEG picture
            if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture_NEW(m_lUserID, lChannel, ref lpJpegPara, buffer, 102400, ref lpSizeReturned))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_CaptureJPEGPicture failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }
            else
            {
                str = "Successful to capture the JPEG file and the saved file is " + sJpegPicFileName;
                MessageBox.Show(str);
            }
            return;
        
        }

        
        uint dwVoiceChan = new uint();

	    private string pRecvDataBuffer = "hello this is pRecvDataBuffert";

	    private uint dwBufSize = 2048;
	    private byte byAudioFlag = 1;

	    private static CHCNetSDK.VOICEDATACALLBACKV30 fVoiceDataCallBack;
	    private bool bNeedCBNoEncData;
        IntPtr pUser = new IntPtr();

	    private int m_lVoiceComHandle;

  

        private void btnStartVoice_Click(object sender, EventArgs e)
        {
            
            dwVoiceChan = 1;
            bNeedCBNoEncData = true;
            Button bt = sender as Button;
            if (bt != null)
            {
                if (bt.Text == "��ʼ�Խ�")
                {
                    m_lVoiceComHandle = CHCNetSDK.NET_DVR_StartVoiceCom_V30(m_lUserID, dwVoiceChan, bNeedCBNoEncData, fVoiceDataCallBack, pUser);


                    if (m_lVoiceComHandle < 0)
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        str = "Start Voice failed, error code= " + iLastErr; //��¼ʧ�ܣ���������
                        MessageBox.Show(str);
                        return;
                    }
                    else
                    {
                        //��¼�ɹ�
                        MessageBox.Show("Start Voice OK");
                    }

                    if (CHCNetSDK.NET_DVR_SetVoiceComClientVolume(m_lVoiceComHandle, 0xffff))
                    {
                        MessageBox.Show("Set Voice Loudest!");
                    }
                    bt.Text = "ֹͣ�Խ�";
                }
                else if (bt.Text == "ֹͣ�Խ�")
                {
                    if (!CHCNetSDK.NET_DVR_StopVoiceCom(m_lVoiceComHandle))
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        str = "Start Voice failed, error code= " + iLastErr; //��¼ʧ�ܣ���������
                        MessageBox.Show(str);
                        return;
                    }
                    else
                    {
                        bt.Text = "��ʼ�Խ�";
                    }
                }
            }

        }


	    private CHCNetSDK.VOICEAUDIOSTART fVoiceaudiostartCallBack;

	    private void btnStartSpeek_Click(object sender, EventArgs e)
	    {
            if (CHCNetSDK.NET_DVR_ClientAudioStart_V30(fVoiceaudiostartCallBack, pUser))
	        {
	            MessageBox.Show("Audio Speaker OK");
	        }

	        var temp = CHCNetSDK.NET_DVR_AddDVR_V30(m_lUserID, 1);
	        if ( temp < 0 )
	        {

                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "Add Failed!!, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
                
	        }
	        else
	        {
                MessageBox.Show(temp + "    ADD Audio Speaker OK");
	        }
	    }

        private void btnAudioPreview_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;

            if (bt != null)
            {
                if (bt.Text.Equals("�ر�����Ԥ��"))
                {
                    if (!CHCNetSDK.NET_DVR_CloseSound())
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        str = "�ر�����Ԥ��ʧ��!!, error code= " + iLastErr;
                        MessageBox.Show(str);
                        return;
                    }
                    bt.Text = "������Ԥ��";
                }
                else if(bt.Text.Equals(("������Ԥ��")))
                {
                    if (!CHCNetSDK.NET_DVR_OpenSound(m_lRealHandle))
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        str = "������Ԥ��ʧ��!!, error code= " + iLastErr;
                        MessageBox.Show(str);
                        return;
                    }
                    bt.Text = "�ر�����Ԥ��";
                }
            }

            
        }

        private void btnUdp_Click(object sender, EventArgs e)
        {
            
            // CHCNetSDK.NET_DVR_CUSTOM_PROTOCAL struCustomProtocal = new CHCNetSDK.NET_DVR_CUSTOM_PROTOCAL();

            #region ����Ƶ��ʱ�����
           // uint lpBytesReturned = 0;
           // CHCNetSDK.NET_DVR_TIME time = new CHCNetSDK.NET_DVR_TIME();
           // int size = System.Runtime.InteropServices.Marshal.SizeOf(time);
           // IntPtr myPtr = Marshal.AllocHGlobal(size);
           // Marshal.StructureToPtr(time, myPtr, true);
           // if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, 118, 1, myPtr, (uint)size
           //     , ref lpBytesReturned))
           // {
           //     iLastErr = CHCNetSDK.NET_DVR_GetLastError();
           //     str = "��ȡIPͨ������ʧ��, error code= " + iLastErr;
           //     MessageBox.Show(str);
           //     return;
           // }
           // time = Marshal.PtrToStructure(myPtr, typeof(CHCNetSDK.NET_DVR_TIME)) is CHCNetSDK.NET_DVR_TIME ? (CHCNetSDK.NET_DVR_TIME)Marshal.PtrToStructure(myPtr, typeof(CHCNetSDK.NET_DVR_TIME)) : new CHCNetSDK.NET_DVR_TIME();

           //Marshal.PtrToStructure(myPtr, time);
           //MessageBox.Show("day:" + time.dwDay.ToString() + "Hour" +time.dwHour);

            #endregion

            #region Զ������Э��
            uint lpBytesReturned = 0;
            CHCNetSDK.NET_DVR_CUSTOM_PROTOCAL struCustomProtocal = new CHCNetSDK.NET_DVR_CUSTOM_PROTOCAL();
            int size = System.Runtime.InteropServices.Marshal.SizeOf(struCustomProtocal);
            IntPtr protocalIntPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(struCustomProtocal, protocalIntPtr , true);

            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, 6116, 1, protocalIntPtr, (uint) size
                , ref lpBytesReturned))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "��ȡIPͨ������ʧ��, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }

            struCustomProtocal = Marshal.PtrToStructure(protocalIntPtr, typeof (CHCNetSDK.NET_DVR_CUSTOM_PROTOCAL)) is CHCNetSDK.NET_DVR_CUSTOM_PROTOCAL ? (CHCNetSDK.NET_DVR_CUSTOM_PROTOCAL)Marshal.PtrToStructure(protocalIntPtr, typeof (CHCNetSDK.NET_DVR_CUSTOM_PROTOCAL)) : new CHCNetSDK.NET_DVR_CUSTOM_PROTOCAL();

            MessageBox.Show(struCustomProtocal.sProtocalName);

            #endregion

            // MessageBox.Show(myPtr.ToString());
            //int size = System.Runtime.InteropServices.Marshal.SizeOf(struCustomProtocal);

            //IntPtr myPtr = Marshal.AllocHGlobal(size);

            //struCustomProtocal.dwEnabled = 1;
            //struCustomProtocal.dwEnableSubStream = 1;
            //struCustomProtocal.sProtocalName = "hello";
            //struCustomProtocal.byMainProType = 1;
            //struCustomProtocal.byMainTransType = 2;
            //struCustomProtocal.wMainPort = 554;
            //struCustomProtocal.sMainPath = "rtsp://192.168.1.64/h264/ch1/main/av_stream";

            //struCustomProtocal.bySubProType = 1;
            //struCustomProtocal.bySubTransType = 2;
            //struCustomProtocal.wSubPort = 554;
            //struCustomProtocal.sSubPath = "rtsp://192.168.1.64/h264/ch1/sub/av_stream";

            //Marshal.StructureToPtr(struCustomProtocal, myPtr, true);


            //if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, 118, 1, myPtr, (uint)size
            //    , ref lpBytesReturned))
            //{
            //    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
            //    str = "��ȡIPͨ������ʧ��, error code= " + iLastErr;
            //    MessageBox.Show(str);
            //    return;
            //}


            //if (!CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID, 6116, 1,myPtr , (uint)size))
            //{
            //    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
            //    str = "��ȡIPͨ������ʧ��, error code= " + iLastErr;
            //    MessageBox.Show(str);
            //    return;
            //}

        }

        //private CHCNetSDK.DRAWFUN fDrawFun = delegate(int handle, IntPtr dc, uint user)
        //{
        //    Graphics g = Graphics.FromHdc(dc);
        //    Pen m_pen = new Pen(Color.Blue, 1);
        //    //�������߸�ʽ 
        //    m_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        //    g.DrawRectangle(m_pen, 0, 0, 100, 100);
        //};

        private CHCNetSDK.DRAWFUN fDrawFun;

        private void btnDraw_Click(object sender, EventArgs e)
        {
            fDrawFun = new CHCNetSDK.DRAWFUN(DrawFunCallBack);

            if (! CHCNetSDK.NET_DVR_RigisterDrawFun(m_lRealHandle,fDrawFun,1))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "�����ַ�ʧ��, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }
           // CHCNetSDK.NET_DVR_RigisterPlayBackDrawFun()
        }

	    private static int count = 0;
        private void DrawFunCallBack(int lRealHandle, IntPtr hDc, uint dwUser)
        {
            
            Graphics g = Graphics.FromHdc(hDc);
            Pen m_pen = new Pen(Color.Red, 2);
            //�������߸�ʽ 
            //m_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            


            g.DrawRectangle(m_pen, 0, 0, 100 * (count++),100*(count++));
          //  g.Clear(Color.Transparent);
	    }



	    private Capture _capture;
	    private Image<Bgr, byte> _frame; 

        private void btnCapture_Click(object sender, EventArgs e)
        {
            //_capture = new Capture(0);

            //if (_capture != null)
            //{
            //    _frame = _capture.QueryFrame();
            //    pictureBoxTest.Image = _frame.ToBitmap();
            //}

            _frame = new Image<Bgr, byte>(@"..\..\..\Picture\Lena.png");
            pictureBoxTest.Image = _frame.ToBitmap();
        }


	}
}
