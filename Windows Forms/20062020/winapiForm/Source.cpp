#include<Windows.h>
#include<tchar.h>
int k = 0;

class WinClass{
	WNDCLASSEX wcl;
public:
    LPCWCH GetName() {
        return wcl.lpszClassName;
    }
	WinClass(HINSTANCE hInst, WNDPROC wProc, LPCWCH ClNmae);
    void Register() {
        if (!RegisterClassEx(&wcl)) {
            MessageBox(0, TEXT("Error register class"), TEXT("Info"),
                MB_OK | MB_ICONSTOP);
            exit(1);        
        }
    }
};	
WinClass::WinClass(HINSTANCE hInst, WNDPROC wProc, LPCWCH ClName)
{
   wcl = { 0 };
   wcl.cbSize=sizeof(wcl);
   //wcl.style;
   wcl.lpfnWndProc= wProc;
  // wcl.cbClsExtra;
   //wcl.cbWndExtra;
   wcl.hInstance= hInst;
   wcl.hIcon = LoadIcon(NULL,IDI_ASTERISK);
   wcl.hIconSm = LoadIcon(NULL, IDI_ASTERISK);
  /// wcl.hCursor = LoadIcon(NULL, IDC_ARROW);
   wcl.hbrBackground =(HBRUSH) COLOR_APPWORKSPACE;
  // wcl.lpszMenuName;
   wcl.lpszClassName= ClName;

   Register();
}
LRESULT CALLBACK  WinProc(HWND hWnd, UINT uMessage,
    WPARAM wParam,LPARAM lParam ) {
    switch (uMessage)
    {
    case WM_MOUSEMOVE: {
        k++;
        wchar_t buf[50]{ 0 };
        int x = LOWORD(lParam);
        int y = HIWORD(lParam);
        swprintf_s(buf, L"k=%10d  (%d;%d)\n", k,x,y);
        SetWindowText(hWnd, buf);
    }break;
    case WM_LBUTTONDOWN:{
        MessageBox(hWnd, L"LBUTTONDOWN", TEXT("Info"),
            MB_OK | MB_ICONINFORMATION);    
    }break;
    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd,uMessage,wParam,lParam);
    }
    return 0;
}

INT WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow) {
    WinClass CW(hInst,WinProc,TEXT("Моя перша прога WinAPI"));
    HWND hWnd = CreateWindowEx(0, CW.GetName(),
        TEXT("прога WinAPI"), WS_OVERLAPPEDWINDOW | WS_VISIBLE,
        100, 200, 640, 480, 0, 0, hInst, 0);

    if (!hWnd) {
        MessageBox(0, TEXT("Error Create Window"), TEXT("Info"),
            MB_OK | MB_ICONSTOP);
        exit(2);    
    }
    MSG msg{ 0 };
    while (GetMessage(&msg,0,0,0))
    {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }
    return   msg.wParam;
}