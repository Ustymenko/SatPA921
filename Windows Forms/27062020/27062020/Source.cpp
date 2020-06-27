#include<Windows.h>
#include<tchar.h>
int k = 0;
#define static1 10001
#define static2 10002
#define button1 20001
#define button2 20002
#define edit1 30001
#define edit2 30002

void CreateStatic(HWND hWnd) {

	CreateWindow(L"static",
		TEXT("прога WinAPI"), WS_VISIBLE | WS_CHILD | SS_SIMPLE,
		10, 10, 100, 20, hWnd, (HMENU)static1, 0, 0);


	HWND hPic = CreateWindow(L"static", 0, WS_VISIBLE | WS_CHILD | SS_BITMAP,
		10, 30, 0, 0, hWnd, (HMENU)static2, 0, 0);

	HANDLE hImg = LoadImage(0, L"butt1.bmp", IMAGE_BITMAP, 0, 0,
		LR_LOADFROMFILE | LR_DEFAULTCOLOR | LR_DEFAULTSIZE);

	SendMessage(hPic, STM_SETIMAGE, IMAGE_BITMAP, (LPARAM)hImg);

}
void CreateButtons(HWND hWnd) {

	CreateWindow(L"button",
		TEXT("Yes"), WS_VISIBLE | WS_CHILD | BS_PUSHBUTTON,
		120, 10, 100, 30, hWnd, (HMENU)button1, 0, 0);
	CreateWindow(L"button",
		TEXT("No"), WS_VISIBLE | WS_CHILD | BS_PUSHBUTTON,
		230, 10, 100, 30, hWnd, (HMENU)button2, 0, 0);
}
void CreateEdit(HWND hWnd) {

	CreateWindow(L"edit",
		TEXT("10"), WS_VISIBLE | WS_CHILD | WS_BORDER|ES_LEFT,
		120, 50, 100, 20, hWnd, (HMENU)edit1, 0, 0);

	CreateWindow(L"edit",
		TEXT("20"), WS_VISIBLE | WS_CHILD | WS_BORDER | ES_RIGHT|ES_MULTILINE,
		230, 50, 100, 100, hWnd, (HMENU)edit2, 0, 0);
}

class WinClass {
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
	wcl.cbSize = sizeof(wcl);
	//wcl.style;
	wcl.lpfnWndProc = wProc;
	// wcl.cbClsExtra;
	 //wcl.cbWndExtra;
	wcl.hInstance = hInst;
	wcl.hIcon = LoadIcon(NULL, IDI_ASTERISK);
	wcl.hIconSm = LoadIcon(NULL, IDI_ASTERISK);
	/// wcl.hCursor = LoadIcon(NULL, IDC_ARROW);
	wcl.hbrBackground = (HBRUSH)COLOR_APPWORKSPACE;
	// wcl.lpszMenuName;
	wcl.lpszClassName = ClName;

	Register();
}
LRESULT CALLBACK  WinProc(HWND hWnd, UINT uMessage,
	WPARAM wParam, LPARAM lParam) {
	switch (uMessage)
	{
	case WM_CREATE: {
		CreateStatic(hWnd);
		CreateButtons(hWnd);	
		CreateEdit(hWnd);

	}break;
	case WM_COMMAND: {
		switch (LOWORD(wParam))
		{
		case button1: {
			wchar_t buf[100]{ 0 };
			GetDlgItemText(hWnd, edit1, buf, 100);
			MessageBox(hWnd, buf, TEXT("Info"), MB_OK | MB_ICONINFORMATION);
		}
			break;
		case button2:
			wchar_t buf[100]{ 0 };
			GetDlgItemText(hWnd, edit1, buf, 100);

			SetDlgItemText(hWnd, edit2, buf);
			break;
		}

	}  break;

	case WM_MOUSEMOVE: {
		k++;
		wchar_t buf[50]{ 0 };
		int x = LOWORD(lParam);
		int y = HIWORD(lParam);
		swprintf_s(buf, L"k=%10d  (%d;%d)\n", k, x, y);
		SetWindowText(hWnd, buf);
		//SetWindowText((HWND)0x001A08CE, buf);
	}break;
	case WM_LBUTTONDOWN: {

		CreateWindow(L"button",
			TEXT("No"), WS_VISIBLE | WS_CHILD | BS_PUSHBUTTON,
			230, 10, 100, 30, FindWindow(L"CalcFrame", 0), (HMENU)button2, 0, 0);

		//SetWindowText(GetDlgItem(hWnd, static1), TEXT("Info"));


		/* MessageBox(hWnd, L"LBUTTONDOWN", TEXT("Info"),
			 MB_OK | MB_ICONINFORMATION);*/
			 // HWND hCalc= (HWND)0x000609D2;
			 // HWND hCalc = FindWindow(0, L"Калькулятор");
			//  HWND hCalc = FindWindow(L"CalcFrame", 0);
			//  SetWindowText(hCalc,L"60");
			//  InvalidateRect(FindWindow(L"CalcFrame", 0),0,0);
			//  UpdateWindow(FindWindow(L"CalcFrame", 0));

		  /*    RECT rec{ 0 };
			  GetWindowRect(FindWindow(L"CalcFrame", 0),&rec );
			  int w = rec.right - rec.left;
			  int h = rec.bottom - rec.top;
			  MoveWindow(FindWindow(L"CalcFrame", 0), 50, 150, w, h, 1);*/

	}break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, uMessage, wParam, lParam);
	}
	return 0;
}

INT WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow) {
	WinClass CW(hInst, WinProc, TEXT("Моя перша прога WinAPI"));
	HWND hWnd = CreateWindowEx(0, CW.GetName(),
		TEXT("прога WinAPI"), WS_OVERLAPPEDWINDOW | WS_VISIBLE,
		100, 200, 640, 480, 0, 0, hInst, 0);

	if (!hWnd) {
		MessageBox(0, TEXT("Error Create Window"), TEXT("Info"),
			MB_OK | MB_ICONSTOP);
		exit(2);
	}
	MSG msg{ 0 };
	while (GetMessage(&msg, 0, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return   msg.wParam;
}