extern "C" {
	__declspec(dllexport)  double Add(double a, double b) {
		return a + b;
	}
	__declspec(dllexport) double Sub(double a, double b) {
		return a - b;
	}
	__declspec(dllexport) double Mult(double a, double b) {
		return a * b;
	}
	__declspec(dllexport) double Div(double a, double b) {
		return a / b;
	}
}