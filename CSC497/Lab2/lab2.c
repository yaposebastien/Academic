#include <stdio.h>

int add3(int a, int b, int c)
{
    return a+b+c;
}

int main(int argc, char** argv) {
    int a=5, b=6, c=10;
    int d = add3(a,b,c);
    return 0;
}
