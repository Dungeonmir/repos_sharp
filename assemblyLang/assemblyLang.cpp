#include <iostream>
using namespace std;
int main()
{
    setlocale(LC_ALL, "rus");
    //2.	Найти сумму всех положительных и отрицательных чисел. Массив int. 

    //база + (индекс * размер элемента)

    short mass[] = { -10,-20,-30,40,50 };
    short len = 5;
    int sum = 0;


    _asm {

        xor esi, esi
        mov esi,-2//индекс элемента массива
        mov ecx, len     //запись длины массива

        FORR :
        add esi,2
        mov	ebx, mass[esi]
            cmp ebx, 0
            jg loopp;
            inc	sum
            inc	esi
        loopp:
            loop	FORR
        

    }
    cout << "Summa = " << sum << "\n";
}