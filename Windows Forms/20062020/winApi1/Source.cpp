#include <Windows.h>
#include <stdio.h>

INT WINAPI WinMain(HINSTANCE hInstance,	HINSTANCE hPrevInstance,
	LPSTR lpCmdLine,INT nState) {

	int k = 20;
	double m = 7.99;

	wchar_t buf[50]{ 0 };
	
	//wsprintf(buf, L"k=%10d", k);
	//error wsprintf(buf, L"k=%10d\nm=%10.2f", k,m);
	swprintf_s(buf, L"k=%10d\nm=%10.2f", k,m);

	MessageBox(0, buf, TEXT("Info"),
		MB_OK | MB_ICONINFORMATION);

	/*if (IDYES ==MessageBox(0, TEXT("Hello It Step"), TEXT("Caption"),
		MB_YESNO | MB_ICONQUESTION | MB_DEFBUTTON2))
	{
		MessageBox(0, TEXT("връ"), TEXT("Info"),
			MB_OK | MB_ICONINFORMATION);
	}
	else {
		MessageBox(0, TEXT("ЭГ"), TEXT("Info"),
			MB_OK | MB_ICONINFORMATION);
	}*/
	return 0;
}