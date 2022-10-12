

#include <iostream>
using namespace std;
int main()
{
    setlocale(LC_ALL, "rus");
    //2.	1) произведение отрицательных элементов массива;
    


    int mass[3][4] = {{1,21,31,41},{12,1,17,42}, {1,16,16,43}};
    int n = 3;
    int m = 4;
    int edinits = 0;

    int asm_eax = 0;
    int asm_esi = 0;
    int asm_ebx = 0;
    int asm_ecx = 0;
    int asm_edx = 0;
    int asm_esi_before = 0;
    _asm {
            
            mov eax, n;
            mul m;
            mov ecx, eax; кол - во элементов мас
            xor esi, esi
            mov edx, 1
            mov eax, 0
            xor ebx, ebx;
            jmp beg;
        mass_is_ed: 
            inc ebx
            inc esi
                loop beg
        beg: 
            
            cmp edx, mass[esi*4]
            je mass_is_ed
                inc esi
                loop beg
        
        mov edinits, ebx
        
        mov asm_esi, esi;
        mov asm_ebx, ebx;
        mov asm_ecx, ecx;
        mov asm_eax, eax;
        mov asm_edx, edx;
        
    }
    cout <<"Edinits = " << edinits << "\n";
    
    //cout<<"\n"<<len;
    
    cout << "eax=" << asm_eax << "\n";
    cout << "ebx=" << asm_ebx << "\n";
    cout << "ecx=" << asm_ecx << "\n";
    cout << "edx=" << asm_edx << "\n";
    cout << "esi=" << asm_esi << "\n";
    cout << "esi before=" << asm_esi_before << "\n";
    /*
    for (int i = 0; i < len; i++)
    {
        cout << "mas[" << i << "] = " << mass[i]<<" ";
    }
    */
}
