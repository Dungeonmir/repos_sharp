/*
		{ a* b + 1 }	 a > b
	y = { 25 }			 a == b
		{ (a - 5) / b }	 a < b
*/

#include <iostream>

	using namespace std;

int main()

{


	int a;
	int b;
	int y;
	std::cout << "Enterr chislo a\n";
	cin >> a;
	std::cout << "Enterr chislo b\n";
	cin >> b;

	_asm {
		mov eax, a;
		mov ebx, b;

		cmp eax, ebx;
		
		jg bolshe;
		jl menshe;
	
	ravno:
		mov eax, -5;
		jmp endfunc;
	bolshe:
		mov edx, 0;
		imul ebx;
		add eax, 21
		jmp endfunc;
	menshe:
		cmp ebx, 0;
		je ploho;    b != 0
		xor edx, edx;
		mov ecx, 3;
		imul ecx; (a * 3)
		xor edx, edx; очистка edx
		idiv ebx;  (a*3) / b
			
		inc eax; ((a * 3) / b) +1
		
		jmp endfunc;
	ploho:
		mov eax, 0;
		jmp endfunc;
	endfunc:
		mov y, eax; out



	}
	std::cout << "y = " << y;
}

