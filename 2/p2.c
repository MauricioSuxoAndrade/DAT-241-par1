#include <stdio.h>

int suma(int a, int b) {
    return a + b;
}

int resta(int a, int b) {
    return a - b;
}

int multiplicacion(int a, int b) {
    return a * b;
}

float division(int a, int b) {
    if (b != 0) {
        return (float)a / b;
    } else {
        return 0;
    }
}

void main() {
    int a, b;

    printf("Ingrese el primer numero: ");
    scanf("%d", &a);
    printf("Ingrese el segundo numero: ");
    scanf("%d", &b);
    
    printf("Suma: %d + %d = %d \n", a, b, suma(a, b));
    printf("Resta: %d - %d = %d \n", a, b, resta(a, b));
    printf("Multiplicacion: %d * %d = %d \n", a, b, multiplicacion(a, b));

    if (b != 0) {
        printf("Division: %d / %d = %.4f \n", a, b, division(a, b));
    } else {
        printf("Division: Indeterminado \n");
    }
}
