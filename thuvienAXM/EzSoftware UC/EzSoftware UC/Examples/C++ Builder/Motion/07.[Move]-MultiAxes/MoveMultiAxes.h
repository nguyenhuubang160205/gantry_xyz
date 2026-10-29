//---------------------------------------------------------------------------

#ifndef MoveMultiAxesH
#define MoveMultiAxesH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Dialogs.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------

#define MAX_MULTI_MOVE_AXIS		4

class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TGroupBox *GroupBox1;
        TLabel *Label1;
        TComboBox *cboSelAxis;
        TButton *btnLoadFile;
        TGroupBox *GroupBox2;
        TLabel *Label8;
        TLabel *Label9;
        TLabel *Label10;
        TEdit *stcCmdPos00;
        TEdit *stcActPos00;
        TEdit *stcCmdVel00;
        TButton *btnPosClear;
        TCheckBox *chkServoOn;
        TEdit *stcCmdPos01;
        TEdit *stcCmdPos02;
        TEdit *stcCmdPos03;
        TCheckBox *chkAxis00;
        TCheckBox *chkAxis01;
        TCheckBox *chkAxis02;
        TCheckBox *chkAxis03;
        TEdit *stcActPos01;
        TEdit *stcActPos02;
        TEdit *stcActPos03;
        TEdit *stcCmdVel01;
        TEdit *stcCmdVel02;
        TEdit *stcCmdVel03;
        TGroupBox *GroupBox3;
        TLabel *Label2;
        TLabel *Label3;
        TLabel *Label4;
        TLabel *Label5;
        TEdit *edtMoveVel00;
        TEdit *edtMoveAcc00;
        TEdit *edtMoveDec00;
        TButton *btnPosMove;
        TCheckBox *chkMoveBlock;
        TEdit *edtMoveVel01;
        TEdit *edtMoveVel02;
        TEdit *edtMoveVel03;
        TEdit *edtMoveAcc01;
        TEdit *edtMoveAcc02;
        TEdit *edtMoveAcc03;
        TEdit *edtMoveDec01;
        TEdit *edtMoveDec02;
        TEdit *edtMoveDec03;
        TEdit *edtMovePos00;
        TEdit *edtMovePos01;
        TEdit *edtMovePos02;
        TEdit *edtMovePos03;
        TButton *btnPosStop;
        TGroupBox *GroupBox4;
        TLabel *Label6;
        TLabel *Label7;
        TLabel *Label11;
        TEdit *edtJogVel00;
        TEdit *edtJogAcc00;
        TEdit *edtJogDec00;
        TButton *btnJogP;
        TEdit *edtJogVel01;
        TEdit *edtJogVel02;
        TEdit *edtJogVel03;
        TEdit *edtJogAcc01;
        TEdit *edtJogAcc02;
        TEdit *edtJogAcc03;
        TEdit *edtJogDec01;
        TEdit *edtJogDec02;
        TEdit *edtJogDec03;
        TButton *btnJogN;
        TGroupBox *GroupBox5;
        TLabel *Label12;
        TLabel *Label13;
        TLabel *Label14;
        TEdit *edtLinePos00;
        TEdit *edtLineVel;
        TEdit *edtLineAcc;
        TButton *btnLineP;
        TEdit *edtLinePos01;
        TEdit *edtLinePos02;
        TEdit *edtLinePos03;
        TEdit *edtLineDec;
        TButton *btnLineN;
        TOpenDialog *OpenDialog1;
        TTimer *m_timer;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall FormDestroy(TObject *Sender);
        void __fastcall cboSelAxisChange(TObject *Sender);
        void __fastcall btnLoadFileClick(TObject *Sender);
        void __fastcall chkAxis00Click(TObject *Sender);
        void __fastcall chkAxis01Click(TObject *Sender);
        void __fastcall chkAxis03Click(TObject *Sender);
        void __fastcall chkAxis02Click(TObject *Sender);
        void __fastcall btnPosClearClick(TObject *Sender);
        void __fastcall chkServoOnClick(TObject *Sender);
        void __fastcall btnPosMoveClick(TObject *Sender);
        void __fastcall btnPosStopClick(TObject *Sender);
        void __fastcall btnJogPMouseDown(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall btnJogNMouseDown(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall btnLinePMouseDown(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall btnLineNMouseDown(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall btnJogPMouseUp(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall btnJogNMouseUp(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall btnLinePMouseUp(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall btnLineNMouseUp(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall m_timerTimer(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TForm1(TComponent* Owner);

        BOOL InitLibrary();		        // 라이브러리 초기화 및 Mot파일을 불러오는 함수.
	BOOL InitControl();                     // Control 변수들을 등록하고, 초기 설정값들을 설정하는 함수.
	BOOL AddAxisInfo();			// 검색된 축 정보를 ComboBox에 등록/Control들을 초기화하는 함수.
	BOOL UpdateState();			// 모션보드의 상태와 Control들의 상태를 일치시키는 함수.
        DWORD ConvertComboToAxm(TComboBox *pCboItem);			// ComboBox콘트롤에 현재 선택된 Item Index를 모션보드에 설정할 값으로 변경하는 함수.
	long ConvertAxmToCombo(TComboBox *pCboItem, DWORD dwCurData);	// 설정값과 ComboBox콘트롤의 Item과 일치하는 Item을 찾아 선택하는 함수.

        long		m_lAxisNo;	  	// 제어할 축 번호
	long		m_lAxisCount;	        // 유효한 전체 모션축수
	DWORD		m_dwModuleID;		// 선택한 축의 모델ID
        long            m_lMoveMultiAxesCount;
        double		m_dOldCmdPos[MAX_MULTI_MOVE_AXIS];   // OnTimer에서 사용할 이전 Command Position
	double		m_dOldActPos[MAX_MULTI_MOVE_AXIS];   // OnTimer에서 사용할 이전 Actual Position
	double		m_dOldCmdVel[MAX_MULTI_MOVE_AXIS];   // OnTimer에서 사용할 이전 Command Velocity
        long             m_lMoveMultiAxes[MAX_MULTI_MOVE_AXIS];

        TEdit *         m_stcCmdPos[MAX_MULTI_MOVE_AXIS];
        TEdit *         m_stcActPos[MAX_MULTI_MOVE_AXIS];
        TEdit *         m_stcCmdVel[MAX_MULTI_MOVE_AXIS];
        TCheckBox *     m_chkMoveMultiAxes[MAX_MULTI_MOVE_AXIS];
        TEdit *         m_edtMovePos[MAX_MULTI_MOVE_AXIS];
        TEdit *         m_edtMoveVel[MAX_MULTI_MOVE_AXIS];
        TEdit *         m_edtMoveAcc[MAX_MULTI_MOVE_AXIS];
        TEdit *         m_edtMoveDec[MAX_MULTI_MOVE_AXIS];
        TEdit *         m_edtJogVel[MAX_MULTI_MOVE_AXIS];
        TEdit *         m_edtJogAcc[MAX_MULTI_MOVE_AXIS];
        TEdit *         m_edtJogDec[MAX_MULTI_MOVE_AXIS];
        TEdit *         m_edtLinePos[MAX_MULTI_MOVE_AXIS];
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
