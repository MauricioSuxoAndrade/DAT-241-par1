#include <stdio.h>

void calc_pi_iterativo(int iter, double *pi) {
    int term = 1.0;
    int signo = 1;


    for (int i = 0; i < iter; i++) {
        *pi += signo * (4.0 / term); 
        term += 2.0;                 
        signo *= -1;                    
    }
}

void calc_pi_recursivo(int iter, int i, double term, int signo, double *pi) {
    if (i >= iter) {
        return; 
    }

    *pi += signo * (4.0 / term); 

    calc_pi_recursivo(iter, i + 1, term + 2.0, signo * -1, pi);
}

void main() {
    int iter1,iter2;
    double pi1 = 0.0;
    double pi2 = 0.0;

    printf("Ingrese numero de iteraciones: ");
    scanf("%d", &iter1);
    iter2 = iter1;

    calc_pi_iterativo(iter1, &pi1);
    calc_pi_recursivo(iter2, 0, 1.0, 1, &pi2);

    printf("Resultado pi con funcion iterativa: %.20f\n", pi1);
    printf("Resultado pi con funcion recursiva: %.20f\n", pi2);
}
