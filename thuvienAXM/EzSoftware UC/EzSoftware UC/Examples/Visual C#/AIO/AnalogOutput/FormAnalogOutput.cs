// This Example maked for AnalogInput module uses at C#
// The comfile is needed to include  AXL.cs, AXHS.cs, AXA.cs Files
// AXL.dll, el_hard.dll, el_univ.dll, EzBasic.dll Files input folder of exist exe file

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace AnalogOutput
{
	/// <summary>
	/// Define Form1.
	/// </summary>
	public class FormAnalogOutput : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox comboWave;
		private System.Windows.Forms.ComboBox comboVoltRange;
		private System.Windows.Forms.ComboBox comboInterval;
		private System.Windows.Forms.TextBox textVoltage;
		private System.Windows.Forms.ListView listviewAOChannel;
		private System.Windows.Forms.TextBox textPeriod;
		private System.Windows.Forms.CheckBox chkbtnStart;
		private System.Windows.Forms.GroupBox groupboxSetting;
		private System.ComponentModel.IContainer components;

		private struct SAOChannel
		{
			public bool		m_bUse;
			public short	m_nWave;
			public short	m_nPeriod;
			public short	m_nVRange;
			public double	m_dVoltage;
			public short	m_nIndex;
		}					

		SAOChannel[]	m_arrCAOChannel;
		public int		m_nChannelCnts	= 0;
		private System.Windows.Forms.Timer timerOutput;
		private int		m_nOldSelIndex	= 0;
		private int		m_nInterval		= 0;

		public FormAnalogOutput()
		{
			//
            // Windows Form necessary for the designer support.
			//
			InitializeComponent();

			//
            // TODO: after InitializeComponent call and add the code.
			//

			InitDeviceInformation();

			groupboxSetting.BackColor = System.Drawing.Color.FromArgb(0,0,0,0);
			chkbtnStart.BackColor = System.Drawing.Color.FromArgb(25,0,0,0);
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

		#region Windows Form µðÀÚÀÌ³Ê¿¡¼­ »ý¼ºÇÑ ÄÚµå
		/// <summary>
        /// necessary for the designer support method.
        /// Do not modify the content of this method to a code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnalogOutput));
            this.listviewAOChannel = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.groupboxSetting = new System.Windows.Forms.GroupBox();
            this.chkbtnStart = new System.Windows.Forms.CheckBox();
            this.textVoltage = new System.Windows.Forms.TextBox();
            this.textPeriod = new System.Windows.Forms.TextBox();
            this.comboInterval = new System.Windows.Forms.ComboBox();
            this.comboVoltRange = new System.Windows.Forms.ComboBox();
            this.comboWave = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerOutput = new System.Windows.Forms.Timer(this.components);
            this.groupboxSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // listviewAOChannel
            // 
            this.listviewAOChannel.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listviewAOChannel.CheckBoxes = true;
            this.listviewAOChannel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listviewAOChannel.FullRowSelect = true;
            this.listviewAOChannel.GridLines = true;
            this.listviewAOChannel.Location = new System.Drawing.Point(8, 8);
            this.listviewAOChannel.MultiSelect = false;
            this.listviewAOChannel.Name = "listviewAOChannel";
            this.listviewAOChannel.Size = new System.Drawing.Size(504, 208);
            this.listviewAOChannel.TabIndex = 0;
            this.listviewAOChannel.UseCompatibleStateImageBehavior = false;
            this.listviewAOChannel.View = System.Windows.Forms.View.Details;
            this.listviewAOChannel.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged_listviewAOChannel);
            this.listviewAOChannel.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnItemCheck_listviewAOChannel);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Channel";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ModuleNo";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ModuleID";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 65;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ChannelNo";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 75;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Wave";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Period";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 55;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "VoltRange";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 70;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Voltage";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 55;
            // 
            // groupboxSetting
            // 
            this.groupboxSetting.Controls.Add(this.chkbtnStart);
            this.groupboxSetting.Controls.Add(this.textVoltage);
            this.groupboxSetting.Controls.Add(this.textPeriod);
            this.groupboxSetting.Controls.Add(this.comboInterval);
            this.groupboxSetting.Controls.Add(this.comboVoltRange);
            this.groupboxSetting.Controls.Add(this.comboWave);
            this.groupboxSetting.Controls.Add(this.label5);
            this.groupboxSetting.Controls.Add(this.label4);
            this.groupboxSetting.Controls.Add(this.label3);
            this.groupboxSetting.Controls.Add(this.label2);
            this.groupboxSetting.Controls.Add(this.label1);
            this.groupboxSetting.Location = new System.Drawing.Point(520, 8);
            this.groupboxSetting.Name = "groupboxSetting";
            this.groupboxSetting.Size = new System.Drawing.Size(168, 208);
            this.groupboxSetting.TabIndex = 1;
            this.groupboxSetting.TabStop = false;
            this.groupboxSetting.Text = "Setting";
            // 
            // chkbtnStart
            // 
            this.chkbtnStart.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkbtnStart.BackColor = System.Drawing.SystemColors.Control;
            this.chkbtnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkbtnStart.Font = new System.Drawing.Font("±¼¸²", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkbtnStart.Location = new System.Drawing.Point(8, 152);
            this.chkbtnStart.Name = "chkbtnStart";
            this.chkbtnStart.Size = new System.Drawing.Size(152, 48);
            this.chkbtnStart.TabIndex = 10;
            this.chkbtnStart.Text = "START";
            this.chkbtnStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkbtnStart.UseVisualStyleBackColor = false;
            this.chkbtnStart.CheckedChanged += new System.EventHandler(this.OnCheckedChanged_chkbtnStart);
            // 
            // textVoltage
            // 
            this.textVoltage.BackColor = System.Drawing.SystemColors.Control;
            this.textVoltage.Cursor = System.Windows.Forms.Cursors.Default;
            this.textVoltage.Enabled = false;
            this.textVoltage.Location = new System.Drawing.Point(96, 120);
            this.textVoltage.MaxLength = 6;
            this.textVoltage.Name = "textVoltage";
            this.textVoltage.Size = new System.Drawing.Size(64, 21);
            this.textVoltage.TabIndex = 9;
            this.textVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textVoltage.TextChanged += new System.EventHandler(this.OnTextChanged_textVoltage);
            // 
            // textPeriod
            // 
            this.textPeriod.Cursor = System.Windows.Forms.Cursors.Default;
            this.textPeriod.Enabled = false;
            this.textPeriod.HideSelection = false;
            this.textPeriod.Location = new System.Drawing.Point(96, 48);
            this.textPeriod.MaxLength = 9;
            this.textPeriod.Name = "textPeriod";
            this.textPeriod.Size = new System.Drawing.Size(64, 21);
            this.textPeriod.TabIndex = 8;
            this.textPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textPeriod.TextChanged += new System.EventHandler(this.OnTextChanged_textPeriod);
            // 
            // comboInterval
            // 
            this.comboInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInterval.Enabled = false;
            this.comboInterval.Items.AddRange(new object[] {
            "1ms",
            "5ms",
            "10ms"});
            this.comboInterval.Location = new System.Drawing.Point(96, 96);
            this.comboInterval.Name = "comboInterval";
            this.comboInterval.Size = new System.Drawing.Size(64, 20);
            this.comboInterval.TabIndex = 7;
            // 
            // comboVoltRange
            // 
            this.comboVoltRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVoltRange.Enabled = false;
            this.comboVoltRange.Items.AddRange(new object[] {
            "-10~10"});
            this.comboVoltRange.Location = new System.Drawing.Point(96, 72);
            this.comboVoltRange.Name = "comboVoltRange";
            this.comboVoltRange.Size = new System.Drawing.Size(64, 20);
            this.comboVoltRange.TabIndex = 6;
            this.comboVoltRange.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged_comboVoltRange);
            // 
            // comboWave
            // 
            this.comboWave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWave.Enabled = false;
            this.comboWave.Items.AddRange(new object[] {
            "Sine",
            "Triangle",
            "Rectangle",
            "Voltage"});
            this.comboWave.Location = new System.Drawing.Point(96, 24);
            this.comboWave.Name = "comboWave";
            this.comboWave.Size = new System.Drawing.Size(64, 20);
            this.comboWave.TabIndex = 5;
            this.comboWave.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged_comboWave);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("±¼¸²", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(8, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "INTERVAL";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("±¼¸²", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(8, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "VOLTAGE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("±¼¸²", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "VOLT RANGE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("±¼¸²", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "PERIOD";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("±¼¸²", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "WAVE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerOutput
            // 
            this.timerOutput.Tick += new System.EventHandler(this.timerOutput_Tick);
            // 
            // FormAnalogOutput
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(696, 222);
            this.Controls.Add(this.groupboxSetting);
            this.Controls.Add(this.listviewAOChannel);
            this.Name = "FormAnalogOutput";
            this.Text = "C# : Analog Output Example";
            this.Closed += new System.EventHandler(this.OnClosed);
            this.groupboxSetting.ResumeLayout(false);
            this.groupboxSetting.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        // Device initialization.
		private void InitDeviceInformation()
		{
            // Library initialization.
            if (CAXL.AxlOpenNoReset(7) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
			{
				uint uStatus = 0;

                // The inspection to have AIO module.
				if (CAXA.AxaInfoIsAIOModule(ref uStatus) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
				{
					if ((AXT_EXISTENCE)uStatus == AXT_EXISTENCE.STATUS_EXIST)
					{
						int	nModuleCounts = 0;

                        // Get the cardinality of the module.
						if (CAXA.AxaInfoGetModuleCount(ref nModuleCounts) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
						{
							InitControl();
						}
						else
						{
                            MessageBox.Show("Failed in geting the cardinality of the module.");
						}
					}
					else
					{
                        MessageBox.Show("The module does not exist.");
						return	;
					}
				}
				else
				{
					MessageBox.Show("AxaIsAOModule() Error!!");
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
			CAXA.AxaoInfoGetChannelCount(ref m_nChannelCnts);

			if( m_nChannelCnts>0 )
			{
				m_arrCAOChannel = new SAOChannel[m_nChannelCnts];

				for( int i=0; i<m_arrCAOChannel.Length; ++i )
				{
                  	m_arrCAOChannel[i].m_nPeriod = 100;
					m_arrCAOChannel[i].m_nVRange = 0;
				}
			}

			for (int i = 0; i < m_nChannelCnts; ++i )
			{
				CAXA.AxaoWriteVoltage(i, 0);
				AddDataToListView( i );
			}

			comboWave.SelectedIndex = 0;
			comboVoltRange.SelectedIndex = 0;
			comboInterval.SelectedIndex = 0;
		}

		private bool AddDataToListView( int nIndex )
		{
			int		nModuleNo	= 0;
			int		nBoardNo	= 0;
			int		nModulePos	= 0;
			uint	uModuleID	= 0;

            // Module No. Get the value
			CAXA.AxaoInfoGetModuleNoOfChannelNo( nIndex, ref nModuleNo );
			CAXA.AxaInfoGetModule( nModuleNo, ref nBoardNo, ref nModulePos, ref uModuleID );

			String strSubItem;
            // New row registration
			strSubItem	= String.Format( "Ch {0:0}", nIndex+1 );	// Channel index
			ListViewItem item1 = new ListViewItem(strSubItem,0);	
			// Place a check mark next to the item.
			strSubItem	= String.Format( "{0:0}", nModuleNo );		// ModuleNo
			item1.SubItems.Add( strSubItem );
			strSubItem	= String.Format( "{0:0}", uModuleID );		// ModuleID
			item1.SubItems.Add( strSubItem );
			strSubItem	= String.Format( "{0:0}", nIndex );			// ChannelNo
			item1.SubItems.Add( strSubItem );
			strSubItem	= String.Format( "Sine Wave" );				// Wave
			item1.SubItems.Add( strSubItem );
			strSubItem	= String.Format( "100" );					// Period
			item1.SubItems.Add( strSubItem );
			strSubItem	= String.Format( " -10~10" );				// Voltage Range
			item1.SubItems.Add( strSubItem );
			strSubItem	= String.Format( "{0:0.0000}", nModuleNo );	// Voltage
			item1.SubItems.Add( strSubItem );
			//Add the items to the ListView.
			listviewAOChannel.Items.AddRange(new ListViewItem[]{item1});
			listviewAOChannel.Items[nIndex].Checked = false;
			m_arrCAOChannel[nIndex].m_bUse = false;

            return false;
		}

		private void ReleaseDeviceInformation()
		{
			if( CAXL.AxlIsOpened() == (int)AXT_BOOLEAN.TRUE )
			{
				for (int i = 0; i < m_nChannelCnts; i++)
				{
					CAXA.AxaoWriteVoltage(i, 0);		
				}

				CAXL.AxlClose();
			}
		}

		/// <summary>
        /// main entry point of that application program.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormAnalogOutput());
		}

		private void OnClosed(object sender, System.EventArgs e)
		{
			ReleaseDeviceInformation();
		}

		private void OnSelectedIndexChanged_listviewAOChannel(object sender, System.EventArgs e)
		{
            // A case which the item did not become the selection comparison
			if (this.listviewAOChannel.SelectedIndices.Count == 1) 
			{
				// Control Enable/Disable
				comboWave.Enabled		= true;
				comboVoltRange.Enabled	= true;
				comboInterval.Enabled	= true;

				if( comboWave.SelectedIndex == 3 )	// " Àü ¾Ð "
				{
					textPeriod.Enabled	= false;
					textVoltage.Enabled = true;
				}
				else
				{
					textPeriod.Enabled	= true;
					textVoltage.Enabled = false;
				}

                // The index currently of the item of listview to be selected.
				int	nSelIndex = this.listviewAOChannel.SelectedIndices[0];
				
				// Get WaveType, Period, Volt Range, Volt value in listview
				String strWave, strPeriod, strVoltRange, strVoltage;
				strWave			= listviewAOChannel.Items[nSelIndex].SubItems[4].Text;	// WaveType
				strPeriod		= listviewAOChannel.Items[nSelIndex].SubItems[5].Text;	// Period
				strVoltRange	= listviewAOChannel.Items[nSelIndex].SubItems[6].Text;	// Volt Range
				strVoltage		= listviewAOChannel.Items[nSelIndex].SubItems[7].Text;	// Voltage

				listviewAOChannel.Items[m_nOldSelIndex].BackColor	= System.Drawing.Color.FromName("InactiveCaptionText");
				listviewAOChannel.Items[nSelIndex].BackColor		= System.Drawing.Color.FromName("LemonChiffon");
				m_nOldSelIndex = nSelIndex;

				// setting up at Control(WaveType, Period, Volt Range, Volt value)
				textPeriod.Text					= strPeriod;
                comboWave.SelectedIndex         = 0;
                comboVoltRange.SelectedIndex    = 0;
				textVoltage.Text				= strVoltage;
			}
			else
			{
				// Control Enable/Disable
				comboWave.Enabled		= false;
				textPeriod.Enabled		= false;
				comboVoltRange.Enabled	= false;
				comboInterval.Enabled	= false;
				textVoltage.Enabled		= false;
			}
		}

		private void OnItemCheck_listviewAOChannel(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
            // On/Off does a channel utility collation at a channel information which is saved at the arrangement.
			if( e.Index < m_arrCAOChannel.Length )
			{
				if(e.NewValue==CheckState.Checked)
				{
					m_arrCAOChannel[e.Index].m_bUse = true;
				}
				else if( e.NewValue==CheckState.Unchecked )
				{
					m_arrCAOChannel[e.Index].m_bUse = false;
				}
			}
		}

        // channel information(WaveType) change : 0=Sin wave, 1=Triangle wave, 2=Rectangle wave, 3=Valtage
		private void OnSelectedIndexChanged_comboWave(object sender, System.EventArgs e)
		{
            // A case which the item did not become the selection comparison
			if (this.listviewAOChannel.SelectedIndices.Count == 1) 
			{
                // The index currently of the item of listview to be selected
				int	nSelIndex = this.listviewAOChannel.SelectedIndices[0];

                // An item text change of listview
				listviewAOChannel.Items[nSelIndex].SubItems[4].Text	= comboWave.Text;		// WaveType
				m_arrCAOChannel[nSelIndex].m_nWave = (short)comboWave.SelectedIndex;

				if( comboWave.SelectedIndex == 3 )	// " Valtage "
				{
					textPeriod.Enabled	= false;
					textVoltage.Enabled = true;
					textVoltage.BackColor = System.Drawing.Color.FromName("Window");
					OnTextChanged_textVoltage(sender, e);
				}
				else
				{
					textPeriod.Enabled	= true;
					textVoltage.Enabled = false;
					textVoltage.BackColor = System.Drawing.Color.FromName("Control");
				}
			}
		}

        // channel information(Volt range) change : 0="0~10", 1="0~5", 2="-10~10", 3="-5~5"
		private void OnSelectedIndexChanged_comboVoltRange(object sender, System.EventArgs e)
		{
            // A case which the item did not become the selection comparison
			if (this.listviewAOChannel.SelectedIndices.Count == 1) 
			{
                // The index currently of the item of listview to be selected
				int	nSelIndex = this.listviewAOChannel.SelectedIndices[0];

                // An item text change of listview
				listviewAOChannel.Items[nSelIndex].SubItems[6].Text	= comboVoltRange.Text;	// Volt range

				// Set Volt range
				int	nChannelNo = nSelIndex;
		
				CAXA.AxaoSetRange(nChannelNo, -10, 10);
					
				// Voltage output
				if ( listviewAOChannel.Items[nSelIndex].Checked )
				{
					textVoltage.Text = "0.0000";
					CAXA.AxaoWriteVoltage(nChannelNo, 0);
				}

				m_arrCAOChannel[nSelIndex].m_nVRange = (short)comboVoltRange.SelectedIndex;
			}
		}

        // channel information(Voltage) change
		private void OnTextChanged_textVoltage(object sender, System.EventArgs e)
		{
			int		i = 0;

            // The adjustment for Volt value to be set to be valid.
			String	strTextVolt;
			strTextVolt = textVoltage.Text;
			strTextVolt.Replace(" ", "");

            // Wrong case which is the value, return( - exclusion )
			if( strTextVolt.Length == 0 )
				return;
			for( i=0; i<strTextVolt.Length; ++i )
			{
				if( Char.IsNumber(strTextVolt, i) == false && strTextVolt[i] != '-' && strTextVolt[i] != '.')
					return;
			}
			if( strTextVolt[0] == '-' && strTextVolt.Length == 1 )
				return;

            // The case which escapes from the range to be a numeric character value, return
            // conversion to the numeric character
			Double dNum = Convert.ToDouble(strTextVolt);
			strTextVolt = String.Format("{0:0.0000}", dNum);
			if( dNum < -10.0 || dNum > 10.0 )
				return;

            // A case which the item did not become the selection comparison
			if (this.listviewAOChannel.SelectedIndices.Count == 1) 
			{
                // The index currently of the item of listview to be selected
				int	nSelIndex = this.listviewAOChannel.SelectedIndices[0];

                // An item text change of listview
				listviewAOChannel.Items[nSelIndex].SubItems[7].Text	=strTextVolt;		// Voltage

				uint	nStatus = 0;
				CAXA.AxaInfoIsAIOModule(ref nStatus);
				if( chkbtnStart.Checked && ((CAXL.AxlIsOpened()&1) != 0) &&
					((AXT_EXISTENCE)nStatus == AXT_EXISTENCE.STATUS_EXIST) )
				{
					int		nChannelNo = -1;
					nChannelNo	= nSelIndex;

                    String strVoltage = listviewAOChannel.Items[nSelIndex].SubItems[7].Text;	// Voltage
					Double	dVolt = 0.0f;
					dVolt	= Convert.ToDouble( strVoltage );

					// Set Volt range
		
					CAXA.AxaoSetRange(nChannelNo, -10, 10);


					// Output Voltage
					if( listviewAOChannel.Items[nSelIndex].Checked )
					{
						CAXA.AxaoWriteVoltage(nChannelNo, dVolt);
					}

					m_arrCAOChannel[nSelIndex].m_dVoltage	= (Double)dVolt;
				}
			}
		}

        // channel information(Period) change
		private void OnTextChanged_textPeriod(object sender, System.EventArgs e)
		{
			int		i = 0;

            // The adjustment for Volt value to be set to be valid.
			String	strTextPeriod;
			strTextPeriod = textPeriod.Text;
			strTextPeriod.Replace(" ", "");

            // Wrong case which is the value, return( - exclusion )
			if( strTextPeriod.Length == 0 )
				return;
			for( i=0; i<strTextPeriod.Length; ++i )
			{
				if( Char.IsNumber(strTextPeriod, i) == false )
					return;
			}
			if( strTextPeriod.Length == 1 )
				return;

            // conversion to the numeric character
			int num = Convert.ToInt32(strTextPeriod);
			strTextPeriod = String.Format("{0:0}", num);
            // The case which escapes from the range to be a numeric character value, return
			if( num < 50 )
				return;

            // A case which the item did not become the selection comparison
			if (this.listviewAOChannel.SelectedIndices.Count == 1) 
			{
                // The index currently of the item of listview to be selected
				int	nSelIndex = this.listviewAOChannel.SelectedIndices[0];

                // An item text change of listview
				listviewAOChannel.Items[nSelIndex].SubItems[5].Text	= strTextPeriod;		// Period

				m_arrCAOChannel[nSelIndex].m_nPeriod	= (short)num;
			}
		}

		private void OnCheckedChanged_chkbtnStart(object sender, System.EventArgs e)
		{
			// Change button text
			if( chkbtnStart.Checked == true )
				chkbtnStart.Text = "WRITING...";
			else
				chkbtnStart.Text = "START";

			//
			if( chkbtnStart.Checked == false )
			{
				timerOutput.Enabled		= false;
				comboInterval.Enabled	= true;
			}
			else
			{
				bool	bDone	= false;
				int		i		= 0;
			
				for( i=0; i<m_arrCAOChannel.Length; ++i )
				{
					if( m_arrCAOChannel[i].m_bUse == true )
					{
						bDone	= true;
					}
				}

				if( bDone )
				{
					// notification continuously to an interval interval, Timer Start
					timerOutput.Enabled = false;

					switch( comboInterval.SelectedIndex )
					{
						case 0:		m_nInterval	= 1;		break;
						case 1:		m_nInterval	= 5;		break;
						case 2:		m_nInterval	= 10;		break;
					}

					timerOutput.Enabled		= true;
					timerOutput.Interval	= m_nInterval;

					comboInterval.Enabled	= false;
				}
				else
					return;
			}			
		}

		private void timerOutput_Tick(object sender, System.EventArgs e)
		{
			Double	dValue	= 0.0f;
			Double	dVRange = 0.0f;
			Double	dPeriod	= 0.0f;
			
			int		i		= 0;
			int		nIndex	= 0;

			for( i=0; i < m_arrCAOChannel.Length; ++i )
			{
				switch( m_arrCAOChannel[i].m_nVRange )
				{
					case 0:		dVRange	= 10.0;		break;
					case 1:		dVRange	= 5.0;		break;			
					case 2:		dVRange	= 10.0;		break;
					case 3:		dVRange	= 5.0;		break;
				}

				nIndex		= m_arrCAOChannel[i].m_nIndex;
				
				if( m_arrCAOChannel[i].m_nIndex >= m_arrCAOChannel[i].m_nPeriod )
					m_arrCAOChannel[i].m_nIndex	= 0;
				else
					m_arrCAOChannel[i].m_nIndex += (short)m_nInterval;

				if( m_arrCAOChannel[i].m_bUse == true )
				{
					switch( m_arrCAOChannel[i].m_nWave )
					{
                        case 0:		// Sin wave
							dPeriod	= (m_arrCAOChannel[i].m_nPeriod) / 2.0;
							dValue	= Math.Sin( ((Double)nIndex) * 3.141592 / dPeriod) * dVRange;

							CAXA.AxaoWriteVoltage(i, dValue);
							break;

                        case 1:		// Triangle wave

                            // under the rise which the interval is big than 0 (case which the interval is 100 0 ~ 24)
							if( nIndex < m_arrCAOChannel[i].m_nPeriod / 4 )
								dValue	= dVRange / (m_arrCAOChannel[i].m_nPeriod / 4) * (Double)nIndex;

                            // under the falling which the interval (case which the interval is 100 25 ~ 74)
							else if( nIndex < (m_arrCAOChannel[i].m_nPeriod / 4.0) * 3.0 )
							{
								dValue	= (double)((-dVRange / (((Double)(m_arrCAOChannel[i].m_nPeriod)) / 4.0))
									* (Double)nIndex) + dVRange * 2.0;
							}
                            // under the rise which the interval is small than 0 (case which the interval is 100 75 ~ 99)
							else
								dValue	= (double)((dVRange / (((Double)(m_arrCAOChannel[i].m_nPeriod)) / 4.0))
									* (Double)nIndex) - dVRange * 4.0;

							CAXA.AxaoWriteVoltage(i, dValue);
							break;

                        case 2:		// Rectangle wave
                            // under the rise which the interval (case which the interval is 100 0 ~ 49)
							if (nIndex < ((Double)(m_arrCAOChannel[i].m_nPeriod)) / 2.0)
								dValue	= dVRange;

                            // under the falling which the interval (case which the interval is 100 50 ~ 99)
							else
								dValue	= -dVRange;

							CAXA.AxaoWriteVoltage(i, dValue);
							break;

					}
				}
			}
		}	//end of timerOutput_Tick(object sender, System.EventArgs e)

	}
}
