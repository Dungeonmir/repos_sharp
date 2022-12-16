
#include <iostream>
using namespace std;
int main()
{
    setlocale(LC_ALL, "rus");
    //2.	Найти сумму всех положительных и отрицательных чисел. Массив int. 

    //база + (индекс * размер элемента)

    int mass[] = { -10,-20,-30,40,50 };
    int len = 5;
    int sum = 0;

  
    _asm {

        xor esi, esi	    //индекс элемента массива
        mov ecx, len     //запись длины массива

        FORR :
            mov	ebx, mass[esi * 4]
            add	sum, ebx
            inc	esi

            loop	FORR
    }
    cout << "Summa = " << sum << "\n";
}
