#include <mpi.h>
#include <stdio.h>
#include <stdlib.h>

#define VECTOR_SIZE 10

void main(int argc, char* argv[]) {
    int rank, size;
    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    int vector_x[VECTOR_SIZE], vector_y[VECTOR_SIZE], vector_result[VECTOR_SIZE];
    int num_elements = VECTOR_SIZE;

    if (rank == 0) {
        printf("Inicializando vectores en el proceso %d...\n", rank);
        for (int i = 0; i < VECTOR_SIZE; i++) {
            vector_x[i] = i + 1;
            vector_y[i] = (i + 1) * 2;
        }
        
        printf("Vector X:\n");
        for (int i = 0; i < VECTOR_SIZE; i++) {
            printf("%d ", vector_x[i]);
        }
        printf("\n");
        
        printf("Vector Y:\n");
        for (int i = 0; i < VECTOR_SIZE; i++) {
            printf("%d ", vector_y[i]);
        }
        printf("\n");

        MPI_Send(&vector_x, VECTOR_SIZE, MPI_INT, 1, 0, MPI_COMM_WORLD);
        MPI_Send(&vector_y, VECTOR_SIZE, MPI_INT, 1, 0, MPI_COMM_WORLD);

        MPI_Send(&vector_x, VECTOR_SIZE, MPI_INT, 2, 0, MPI_COMM_WORLD);
        MPI_Send(&vector_y, VECTOR_SIZE, MPI_INT, 2, 0, MPI_COMM_WORLD);

        int result_impares[VECTOR_SIZE];
        int result_pares[VECTOR_SIZE];

        MPI_Recv(&result_impares, VECTOR_SIZE, MPI_INT, 1, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        MPI_Recv(&result_pares, VECTOR_SIZE, MPI_INT, 2, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

        for (int i = 0; i < VECTOR_SIZE; i++) {
            if (i % 2 == 0) {
                vector_result[i] = result_pares[i];
            } else {
                vector_result[i] = result_impares[i];
            }
        }

        printf("Resultado (suma de vector X y vector Y):\n");
        for (int i = 0; i < VECTOR_SIZE; i++) {
            printf("%d ", vector_result[i]);
        }
        printf("\n");

    } else if (rank == 1) {
        MPI_Recv(&vector_x, VECTOR_SIZE, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        MPI_Recv(&vector_y, VECTOR_SIZE, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

        int result_impares[VECTOR_SIZE] = {0};
        for (int i = 1; i < VECTOR_SIZE; i += 2) {
            result_impares[i] = vector_x[i] + vector_y[i];
        }

        MPI_Send(&result_impares, VECTOR_SIZE, MPI_INT, 0, 0, MPI_COMM_WORLD);

    } else if (rank == 2) {
        MPI_Recv(&vector_x, VECTOR_SIZE, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        MPI_Recv(&vector_y, VECTOR_SIZE, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

        int result_pares[VECTOR_SIZE] = {0};  
        for (int i = 0; i < VECTOR_SIZE; i += 2) {
            result_pares[i] = vector_x[i] + vector_y[i];
        }

        MPI_Send(&result_pares, VECTOR_SIZE, MPI_INT, 0, 0, MPI_COMM_WORLD);
    }

    MPI_Finalize();
}
