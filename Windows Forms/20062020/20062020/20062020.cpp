#include <iostream>
#include <tchar.h>
#include <Windows.h>
#include <string>
#include <fcntl.h>
#include <io.h>

using namespace std;

void TestUni()
{
	char ch = 'A';
	const char* text = "Petro";
	char tex[50] = "Petro";

	wchar_t wch = 'І';
	wchar_t wtext[50] = L"Іван";
	wchar_t wtext2[50] = L"\x0990\x0430\x02DA";

	TCHAR sm = 'Z';
	TCHAR str[] = TEXT("Hello ЯІіїЇєйЙ 事奉聖禮釋義s");

	string st = "Hello s";
	wstring stww = L"Hello 事奉聖禮釋義";

	cout << strlen(text) << endl;
	//  cout << strlen((char*)wtext)<<endl;
	cout << wcslen(wtext) << endl;
	cout << _tcslen(str) << endl;

	_setmode(_fileno(stdout), _O_WTEXT);
	_setmode(_fileno(stdin), _O_WTEXT);
	wcout << str << endl;
	wcin >> str;
	wcout << L"--------------------------------------------" << endl;
	wcout << str << endl;
	_setmode(_fileno(stdout), _O_TEXT);
	_setmode(_fileno(stdin), _O_TEXT);
	std::cout << "\nHello World!\n";
}
void Test_wcstombs()
{
	wchar_t str[] = L"Hello ЯІіїЇєйЙ 事奉聖禮釋義s";
	char res[50]{ 0 };
	_setmode(_fileno(stdout), _O_TEXT);
	_setmode(_fileno(stdin), _O_TEXT);
	int k = wcstombs(res, str, 10);
	if (k != -1) {
		std::cout << "res=" << res;
	}
	else
		std::cout << "Error\n";
}
void Test_WideCharToMultiByte()
{
	//	WideCharToMultiByte
	wchar_t str[] = L"Hello ЯІіїЇєйЙ 事奉聖禮釋義s";
	_setmode(_fileno(stdout), _O_TEXT);
	_setmode(_fileno(stdin), _O_TEXT);
	int count = WideCharToMultiByte(CP_ACP, 0, str, -1, 0, 0, 0, 0);
	char* res  = new char[count+1]{ 0 };
	WideCharToMultiByte(CP_ACP, 0, str, -1, res, count, 0, 0);
	if (count>0) {
		std::cout << "res=" << res<<endl;
	}
	else
		std::cout << "Error\n";
	delete[] res;
}
void Test_mbstowcs()
{
	//	mbstowcs
	char str[] = "Hello ЯІіїЇєйЙ";
	wchar_t res[50]{ 0 };
	_setmode(_fileno(stdout), _O_WTEXT);
	_setmode(_fileno(stdin), _O_WTEXT);
	int k = mbstowcs(res, str, strlen(str));
	if (k != -1) 
		std::wcout << L"res=" << res<<endl;
	else
		std::wcout << L"Error\n";
	
}
void Test_MultiByteToWideChar()
{//MultiByteToWideChar
	char str[] = "Hello ЯІіїЇєйЙ";
	int count = MultiByteToWideChar(CP_ACP, 0, str, -1, 0, 0);
	wchar_t* res = new wchar_t[count]{ 0 };
	MultiByteToWideChar(CP_ACP, 0, str, -1, res, count);

	_setmode(_fileno(stdout), _O_WTEXT);
	_setmode(_fileno(stdin), _O_WTEXT);
	
	if (count>0)
		std::wcout << L"res=" << res << endl;
	else
		std::wcout << L"Error\n";
	delete[] res;
}

int main()
{
	// TestUni();
	Test_wcstombs();
	Test_WideCharToMultiByte();
	Test_mbstowcs();
	Test_MultiByteToWideChar();
}