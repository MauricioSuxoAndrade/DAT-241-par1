#include <stdio.h>

void sumap(int a, int b, int *c) {
    *c = a + b;
}

void restarp(int a, int b, int *c) {
    *c = a - b;
}

void multiplicap(int a, int b, int *c) {
    int i;
  	*c = 0;
  	for ( i = 1; i <= b; i ++)
    	sumap(a, *c, &*c);
}

void divisionp(int a, int b, float *c) {
    if (b != 0) {
        *c = (float)a / b;
    } else {
        printf("Division: Indeterminado \n");
    }
}

void main() {
    int a, b, c;
    float d;

    printf("Ingrese el primer numero: ");
    scanf("%d", &a);
    printf("Ingrese el segundo numero: ");
    scanf("%d", &b);

    sumap(a, b, &c);
    printf("Suma: %d + %d = %d\n", a, b, c);

    restarp(a, b, &c);
    printf("Resta: %d - %d = %d\n", a, b, c);

    multiplicap(a, b, &c);
    printf("Multiplicacion: %d * %d = %d\n", a, b, c);

    divisionp(a, b, &d);
    if (b != 0) {
        printf("Division: %d / %d = %.4f\n", a, b, d);
    }
}
