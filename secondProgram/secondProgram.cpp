#include <iostream>
using namespace std;
int main()
{
    int n = 11;
    char s[] = "qwertyuiop";

    _asm {
        lea esi, s
        mov ecx, 4
    jmp1: xor ax,ax
        mov ah, [esi]
        inc esi
        mov al, [esi]
        push ax
        inc esi
        loop jmp1
        lea esi, s
        mov ecx, 4
    jmp2:
        pop ax
        mov [esi], al
        inc esi
        mov [esi], ah
        inc esi
        loop jmp2
            
    }

    
    for (char i = 0; i < n; i++)
    {
        cout << s[i];
    }
    
   
    return 0;
}

