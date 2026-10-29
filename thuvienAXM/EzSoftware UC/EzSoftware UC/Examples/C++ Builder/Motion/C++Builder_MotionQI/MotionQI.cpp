//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
//---------------------------------------------------------------------------
USEFORM("frmStatus.cpp", frmReadStatus);
USEFORM("frm3DGraph.cpp", frm3DGraph);
USEFORM("frmManualSet.cpp", frmManualSet);
USEFORM("frmCamcQI.cpp", frmCamcQI);
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
    try
    {
        Application->Initialize();
        Application->CreateForm(__classid(TfrmCamcQI), &frmCamcQI);
         Application->CreateForm(__classid(Tfrm3DGraph), &frm3DGraph);
         Application->CreateForm(__classid(TfrmReadStatus), &frmReadStatus);
         Application->CreateForm(__classid(TfrmManualSet), &frmManualSet);
         Application->Run();
        }
        catch (Exception &exception)
        {
                 Application->ShowException(&exception);
        }
        //catch (...)
        //{
        //         try
        //         {
        //                 throw Exception("");
        //         }
        //         catch (Exception &exception)
        //         {
        //                 Application->ShowException(&exception);
        //         }
        //}
        return 0;
}
//---------------------------------------------------------------------------

