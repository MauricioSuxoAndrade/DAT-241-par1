#include <stdio.h>
#include <omp.h>

#define n 30

void main() {
    int fib1 = 0, fib2 = 1;
    int next_fib;

    printf("Serie de Fibonacci:\n");
    printf("%d ", fib1);
    printf("%d ", fib2);

    #pragma omp parallel shared(fib1, fib2) private(next_fib)
    {
        #pragma omp for
        for (int i = 2; i < n; i++) {
            #pragma omp critical
            {
                next_fib = fib1 + fib2;
                printf("%d ", next_fib); 
                
                fib1 = fib2;
                fib2 = next_fib;
            }
        }
    }

    printf("\n");
}
