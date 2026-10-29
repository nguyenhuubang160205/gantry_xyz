// This Example maked for AnalogInput module uses at C#
// The comfile is needed to include  AXL.cs, AXHS.cs, AXA.cs Files
// AXL.dll, el_hard.dll, el_univ.dll, EzBasic.dll Files input folder of exist exe file

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

namespace AnalogInput
{
	/// <summary>
	/// Define FormAI.
	/// </summary>
	public class FormAnalogInput : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
        public System.Windows.Forms.TextBox textDataLength;
		private System.Windows.Forms.ComboBox comboVoltRange;

		/// <summary>
        /// mandatory designer variable.
		/// </summary>
		private System.Windows.Forms.GroupBox groupboxSetting;
		private System.Windows.Forms.Button btnSave;
		public System.Windows.Forms.ListView listviewAIChannel;
        public System.Windows.Forms.ListView listviewAIData;
		private System.Windows.Forms.CheckBox checkStart;
		private System.ComponentModel.Container components = null;
        
		public	int				m_nChannelCnts			= 0;
		public	int[]			m_nChannelNo			= new int[MAXNUM_CHANNEL];
		public readonly static int MAXNUM_CHANNEL		= 64;
        public readonly static int MAXNUM_BUFFER = 32768;
		public static bool		m_bGetDataThreadFlag	= false;

		// thread
		private Thread					m_threadGetData;
		static public FormAnalogInput	frmAnalogInput;

		// Delay time
		public static int		m_nGetDelay = 10 ;

        // Two dimension arrangement declaration : The buffer setting up to use Timer, Immediate mode.
		const int	ROW_CNT = 8;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
		const int	COL_CNT = 32768;
        //		private unsafe double[,]	m_arrdVal		= new double[ROW_CNT,COL_CNT];
        //		private unsafe double*[]	m_parrdVal		= new double*[ROW_CNT];

		public FormAnalogInput()
		{
			//
            // Windows Form necessary for the designer support.
			//
			InitializeComponent();

			//
            // TODO: after InitializeComponent call and add the code.
			//
            InitDeviceInformation();

			groupboxSetting.BackColor		= System.Drawing.Color.FromArgb(0,0,0,0);
			checkStart.BackColor			= System.Drawing.Color.FromArgb(25,0,0,0);
			btnSave.BackColor				= System.Drawing.Color.FromArgb(25,0,0,0);
		}

		~FormAnalogInput()
		{
			if( m_threadGetData != null && m_threadGetData.IsAlive == true )
				m_threadGetData.Abort();
		}

		/// <summary>
		/// Arrange all utility resource to be.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
        }

        #region The code to produce in Windows Form designer.

        /// <summary>
        /// necessary for the designer support method.
        /// Do not modify the content of this method to a code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnalogInput));
            this.groupboxSetting = new System.Windows.Forms.GroupBox();
            this.checkStart = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.listviewAIChannel = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.textDataLength = new System.Windows.Forms.TextBox();
            this.comboVoltRange = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listviewAIData = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.groupboxSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupboxSetting
            // 
            this.groupboxSetting.Controls.Add(this.checkStart);
            this.groupboxSetting.Controls.Add(this.btnSave);
            this.groupboxSetting.Controls.Add(this.listviewAIChannel);
            this.groupboxSetting.Controls.Add(this.textDataLength);
            this.groupboxSetting.Controls.Add(this.comboVoltRange);
            this.groupboxSetting.Controls.Add(this.label4);
            this.groupboxSetting.Controls.Add(this.label2);
            this.groupboxSetting.Controls.Add(this.label1);
            this.groupboxSetting.Location = new System.Drawing.Point(8, 8);
            this.groupboxSetting.Name = "groupboxSetting";
            this.groupboxSetting.Size = new System.Drawing.Size(527, 197);
            this.groupboxSetting.TabIndex = 0;
            this.groupboxSetting.TabStop = false;
            this.groupboxSetting.Text = "Setting";
            // 
            // checkStart
            // 
            this.checkStart.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkStart.Font = new System.Drawing.Font("±¼¸²", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkStart.Location = new System.Drawing.Point(401, 136);
            this.checkStart.Name = "checkStart";
            this.checkStart.Size = new System.Drawing.Size(120, 40);
            this.checkStart.TabIndex = 10;
            this.checkStart.Text = "START";
            this.checkStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkStart.CheckedChanged += new System.EventHandler(this.checkStart_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("±¼¸²", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(265, 136);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // listviewAIChannel
            // 
            this.listviewAIChannel.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listviewAIChannel.CheckBoxes = true;
            this.listviewAIChannel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listviewAIChannel.FullRowSelect = true;
            this.listviewAIChannel.GridLines = true;
            this.listviewAIChannel.Location = new System.Drawing.Point(84, 16);
            this.listviewAIChannel.MultiSelect = false;
            this.listviewAIChannel.Name = "listviewAIChannel";
            this.listviewAIChannel.Size = new System.Drawing.Size(437, 104);
            this.listviewAIChannel.TabIndex = 7;
            this.listviewAIChannel.UseCompatibleStateImageBehavior = false;
            this.listviewAIChannel.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "BoardNo";
            this.columnHeader1.Width = 75;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ModuleNo";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ModuleID";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ChannelNo";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 75;
            // 
            // textDataLength
            // 
            this.textDataLength.Location = new System.Drawing.Point(96, 162);
            this.textDataLength.MaxLength = 5;
            this.textDataLength.Name = "textDataLength";
            this.textDataLength.Size = new System.Drawing.Size(120, 21);
            this.textDataLength.TabIndex = 6;
            this.textDataLength.Text = "1000";
            this.textDataLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textDataLength.Leave += new System.EventHandler(this.textDataLength_Leave);
            this.textDataLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDataLength_KeyPress);
            // 
            // comboVoltRange
            // 
            this.comboVoltRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVoltRange.Items.AddRange(new object[] {
            "-10~10"});
            this.comboVoltRange.Location = new System.Drawing.Point(96, 136);
            this.comboVoltRange.Name = "comboVoltRange";
            this.comboVoltRange.Size = new System.Drawing.Size(120, 20);
            this.comboVoltRange.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data length";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Voltage range";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Channel";
            // 
            // listviewAIData
            // 
            this.listviewAIData.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listviewAIData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.listviewAIData.FullRowSelect = true;
            this.listviewAIData.GridLines = true;
            this.listviewAIData.Location = new System.Drawing.Point(8, 203);
            this.listviewAIData.MultiSelect = false;
            this.listviewAIData.Name = "listviewAIData";
            this.listviewAIData.Size = new System.Drawing.Size(527, 280);
            this.listviewAIData.TabIndex = 8;
            this.listviewAIData.UseCompatibleStateImageBehavior = false;
            this.listviewAIData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "No";
            this.columnHeader5.Width = 40;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ch #00";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Ch #01";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Ch #02";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Ch #03";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Ch #04";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Ch #05";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Ch #06";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Ch #07";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormAnalogInput
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(547, 494);
            this.Controls.Add(this.listviewAIData);
            this.Controls.Add(this.groupboxSetting);
            this.Name = "FormAnalogInput";
            this.Text = "C# : Analog Input Example";
            this.Load += new System.EventHandler(this.FormAI_Load);
            this.groupboxSetting.ResumeLayout(false);
            this.groupboxSetting.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
        /// main entry point of that application program.
        /// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run( new FormAnalogInput() );
		}
        
		protected override void WndProc(ref Message m)
		{
			base.WndProc (ref m);
		}

		private void FormAI_Load(object sender, System.EventArgs e)
		{
			frmAnalogInput	= this;
            // The code for a thread collision protect.
            CheckForIllegalCrossThreadCalls = false;
		}

		private void GetVoltageData()
		{
			int	i =0;

			// bring SampleRate, DataLength price.
			int nDataLength	=0;
			nDataLength = Convert.ToInt32(frmAnalogInput.textDataLength.Text);

            // Data store mode.
			int		nChNum = 0, nRow = 0, nLine = 0, nCount = 0;
			int[]	pnCHList	= new int[FormAnalogInput.MAXNUM_CHANNEL];
			int[]	pnSize		= new int[FormAnalogInput.MAXNUM_CHANNEL];

			for( i=0, nChNum=0; i<m_nChannelCnts; ++i )
			{
				if( frmAnalogInput.listviewAIChannel.Items[i].Checked == true )
				{
                    pnCHList[nChNum] = i;						// A total channel number.
					pnSize[nChNum]			= nDataLength;
					nChNum++;
				}
			}

			while( FormAnalogInput.m_bGetDataThreadFlag )
			{
	
				double	dVolt = 0.0;

				if (nLine == nDataLength)
				{
                      FormAnalogInput.m_bGetDataThreadFlag = false;
                       nLine = 0;
				}

                   // New row registration.
				if( nCount < nDataLength )
				{
					ListViewItem item1 = new ListViewItem(nLine.ToString(), 0 );
                    
                    // As Channel length as... SubItem append
					// Place a check mark next to the item.
					String	strSubItem;
					for( int j=0; j<m_nChannelCnts; ++j )
					{
						strSubItem	= String.Format( "" );
						item1.SubItems.Add( strSubItem );
					}

					//Add the items to the ListView.
					frmAnalogInput.listviewAIData.Items.Add(item1);
				}					

				nRow = 0;
				for( i=0; i < m_nChannelCnts; ++i )
				{
					if( frmAnalogInput.listviewAIChannel.Items[i].Checked == true )
					{
				    	CAXA.AxaiSwReadVoltage(i, ref dVolt);

						String	strValue;
						strValue = String.Format("{0:0.0000}", dVolt);

						if (nLine < nDataLength)
						{
							String strSubItem;
							strSubItem	= String.Format( "{0:0.0000}", strValue );
							frmAnalogInput.listviewAIData.Items[nLine].SubItems[nRow+1].Text = strSubItem;
						}
						++nRow;
					}
				}
				++nLine;
				++nCount;
			}

		}

        // Device initialization.
		private void InitDeviceInformation()
		{
            // Library initialization.
            if (CAXL.AxlOpen(7) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
			{
				uint uStatus = 1;

                // The inspection to have AIO module.
				if (CAXA.AxaInfoIsAIOModule(ref uStatus) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
				{
					if ((AXT_EXISTENCE)uStatus == AXT_EXISTENCE.STATUS_EXIST)
					{
						int	nModuleCounts = 0;

                        // Get the cardinality of the module.
						if (CAXA.AxaInfoGetModuleCount(ref nModuleCounts) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
						{
							// Interrupt Event Setting
							int		nChannelCount = 0;
							CAXA.AxaiInfoGetChannelCount( ref nChannelCount );
							uint	ret = 0;
							for( int i=0; i<nChannelCount; ++i )
                                CAXA.AxaiEventSetChannel(i, this.Handle, (uint)AXT_EVENT.WM_AXL_INTERRUPT, null, ref ret);

							InitControl();

						}
						else
						{
							MessageBox.Show("Failed in geting the cardinality of the module.");
						}
					}
					else
					{
                        MessageBox.Show("SIO-RAI8RB module does not exist.");
						return	;
					}
				}
				else
				{
					MessageBox.Show("AxaIsAIModule Error!!");
					return	;
				}
			}
			else
			{
				MessageBox.Show("Could not do the open the driver.");
				return	;
			}
		}

		private void InitControl()
		{
            // Get the information of channels.
			CAXA.AxaiInfoGetChannelCount(ref m_nChannelCnts);

            // New row registration.
			for( int i=0; i<m_nChannelCnts; i++ )
			{
				AddDataToListviewAIChannel(i);
			}

			comboVoltRange.SelectedIndex = 0;
		}

		private void AddDataToListviewAIChannel( int nIndex )
		{
			int		nModuleNo	= 0;
			int		nBoardNo	= 0;
			int		nModulePos	= 0;
			uint	uModuleID	= 0; 

			// Module No. Get the value
			CAXA.AxaiInfoGetModuleNoOfChannelNo( nIndex, ref nModuleNo );
			CAXA.AxaInfoGetModule( nModuleNo, ref nBoardNo, ref nModulePos, ref uModuleID );

			String strSubItem;
            // New row registration (nBoardNo, nModuleNo, uModuleID, i )
			strSubItem	= String.Format( "  {0:00}", nBoardNo );	// nBoardNo
			ListViewItem item1 = new ListViewItem(strSubItem,0);	
			// Place a check mark next to the item.
			strSubItem	= String.Format( "{0:00}", nModuleNo );		// ModuleNo
			item1.SubItems.Add( strSubItem );
			strSubItem	= String.Format( "{0:X2}", uModuleID );		// ModuleID
			item1.SubItems.Add( strSubItem );
			strSubItem	= String.Format( "#{0:00}", nIndex );		// ChannelNo
			item1.SubItems.Add( strSubItem );

			//Add the items to the ListView.
			listviewAIChannel.Items.AddRange(new ListViewItem[]{item1});
		}

		private void textDataLength_Leave(object sender, System.EventArgs e)
		{
            // The adjustment for Volt value to be set to be valid.
			String	strTextDataLength;
			strTextDataLength = textDataLength.Text;
			strTextDataLength.Replace(" ", "");

            // return in wrong case which is the value.
			if( strTextDataLength.Length == 0 )
			{
				textDataLength.Text = "10";
				return;
			}
			else
			{
                // conversion to the numeric character.
				int num = Convert.ToInt32(strTextDataLength);
				strTextDataLength = String.Format("{0:0}", num);
                // return in the case to be a numeric character value which escapes from the range.
				if( num < 10 )
				{
					textDataLength.Text = "10";
				}
				else if( num >50000 )
				{
					textDataLength.Text = "50000";
				}
			}
		}

		private void textDataLength_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(!(Char.IsDigit(e.KeyChar)) && e.KeyChar != (char)(Keys.Back) )
			{
				e.Handled = true;
			}
		}

			private void checkStart_CheckedChanged(object sender, System.EventArgs e)
		{
			int		i = 0, nChNum=0;

			int[]	pnCHList	= new int[MAXNUM_CHANNEL];
			int[]	pwSize		= new int[MAXNUM_CHANNEL];
            long[]  m_arrdVal = new long[MAXNUM_CHANNEL];

			if( checkStart.Checked == true )
			{
				checkStart.Text = "Reading...";
				checkStart.Update();

				// delete the item of a listcontrol(listviewAIData) all.
				listviewAIData.Items.Clear();
				// delete ColumnHeader of a listcontrol(listviewAIData)
				for( i=listviewAIData.Columns.Count; i>1; --i )
				{
					listviewAIData.Columns.RemoveAt(i-1);
				}

                // bring SampleRate, DataLength price.
				int nDataLength	=0;
	
				nDataLength = Convert.ToInt32(textDataLength.Text);
		
                //  append ColumnHeader of a listcontrol(listviewAIData)
				int		nSelectedChannelCnt=0;
				String	strChannel;
				CAXA.AxaiInfoGetChannelCount( ref m_nChannelCnts );

				for(i = 0; i < m_nChannelCnts; ++i )
				{
					if( listviewAIChannel.Items[i].Checked == true )
					{
						strChannel = String.Format("Ch #{0:00}", i);
						ColumnHeader columnHeaderCh = new System.Windows.Forms.ColumnHeader();
						columnHeaderCh.Text = strChannel;
						columnHeaderCh.Width = 60;
						listviewAIData.Columns.Add( columnHeaderCh );

						pnCHList[nSelectedChannelCnt]	= i;
						pwSize[nSelectedChannelCnt]		= nDataLength;

						++nSelectedChannelCnt;
						m_nChannelNo[nChNum]	= i;

						nChNum++;
					}
				}

				if( nSelectedChannelCnt<1 )
					return;

				FormAnalogInput.m_bGetDataThreadFlag		= true;

				m_threadGetData					= new Thread(new ThreadStart(this.GetVoltageData));
				m_threadGetData.IsBackground	= true;
				m_threadGetData.Start();		
			
			}
			else
			{
				CAXA.AxaiHwStopMultiChannel(-1);
		
				// Tread End
				m_bGetDataThreadFlag	= false;

				if( m_threadGetData != null && m_threadGetData.IsAlive == true )
				{
					m_threadGetData.Abort();
					m_threadGetData = null;
				}

				Thread.Sleep(1);

				checkStart.Text = "START";
			}
		}

		private void FormAI_Closed(object sender, System.EventArgs e)
		{
			CAXL.AxlClose();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			string currentFileName = "";
			string str;
			short i, j, nChNum;
			int[]	pnCHList	= new int[FormAnalogInput.MAXNUM_CHANNEL];

			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
 
			saveFileDialog1.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt"  ;
			saveFileDialog1.FilterIndex = 2 ;
			saveFileDialog1.RestoreDirectory = true ;
 
			if(saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				currentFileName = saveFileDialog1.FileName;

				StreamWriter streamWriter = new StreamWriter(currentFileName, false, Encoding.Default);

				// Code to write the stream goes here.
				
				str = String.Format("### AI Data ###\r\n\r\n");

				str = String.Format("Voltage range : -10 ~ 10 V");
			
       			streamWriter.Write(str);

				str = String.Format("\r\nData length   : {0}", textDataLength.Text);
				streamWriter.Write(str);

				for( i=0, nChNum=0; i < m_nChannelCnts; ++i )
				{
					if( listviewAIChannel.Items[i].Checked == true )
					{
                        pnCHList[nChNum] = i;						// A total channel number
						nChNum++;
					}
				}

				streamWriter.Write("\r\n=");
				str = String.Format("================");
				for (i = 0; i < nChNum; i++)
					streamWriter.Write(str);

				streamWriter.Write("\r\nChNo");
				for (i = 0; i < nChNum; i++)
				{
					str = String.Format("\t{0,9}", "Ch. #" + pnCHList[i].ToString() );
					streamWriter.Write(str);
				}

				streamWriter.Write("\r\n=");
				str = String.Format("================");
				for (i = 0; i < nChNum; i++)
					streamWriter.Write(str);

				streamWriter.Write("\r\n");

				for (i = 0; i < listviewAIData.Items.Count; i++)
				{
					str = String.Format("{0,4}", listviewAIData.Items[i].Text);
					streamWriter.Write(str);
					
					for (j = 0; j < nChNum; j++)
					{
						str = String.Format("\t{0,9}", listviewAIData.Items[i].SubItems[j+1].Text);
						streamWriter.Write(str);
					}
					streamWriter.Write("\r\n");
				}
				streamWriter.Close();
			}
		}

        /*
        int[] iChnnel = new int[4] { 0, 1, 2, 3 };
        int[] iSize = new int[4] { 1024, 1024, 1024, 1024 };
        double[,] dpCBuffer = new double[4, 1024];

        unsafe
        {                
            double*[] dpBuffer = new double*[4];

            CAXA.AxaiHwSetMultiAccess(4, iChnnel, iSize);
            CAXA.AxaiSetTriggerMode(0, 2);                

        for (int i = 0; i<iChnnel.Length; i++)
        {
            fixed(double *p = &dpCBuffer[i, 0])
            dpBuffer[i] = p;
        }
            CAXA.AxaiHwStartMultiAccess(dpBuffer);
        }
         */

	}
}
