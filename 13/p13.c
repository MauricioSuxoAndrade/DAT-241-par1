#include <mpi.h>
#include <stdio.h>
#include <string.h>

#define VECTOR_SIZE 6
#define MAX_STRING_LENGTH 100

void main(int argc, char* argv[]) { 
    int rank, size;
    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank); 
    MPI_Comm_size(MPI_COMM_WORLD, &size); 

    char vector[VECTOR_SIZE][MAX_STRING_LENGTH]; 
    int num_elements = VECTOR_SIZE;

    if (rank == 0) {
        strcpy(vector[0], "cadena_0");
        strcpy(vector[1], "cadena_1");
        strcpy(vector[2], "cadena_2");
        strcpy(vector[3], "cadena_3");
        strcpy(vector[4], "cadena_4");
        strcpy(vector[5], "cadena_5");

        printf("Vector : ");
        for (int i = 0; i < num_elements; i++) {
            printf("%s ", vector[i]);
        }
        printf("\n");

        MPI_Send(&vector, VECTOR_SIZE * MAX_STRING_LENGTH, MPI_CHAR, 1, 0, MPI_COMM_WORLD);
        MPI_Send(&vector, VECTOR_SIZE * MAX_STRING_LENGTH, MPI_CHAR, 2, 0, MPI_COMM_WORLD);
    } else if (rank == 1) {
        MPI_Recv(&vector, VECTOR_SIZE * MAX_STRING_LENGTH, MPI_CHAR, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

        printf("Proceso 1 - Pares:\n");
        for (int i = 0; i < num_elements; i += 2) {
            printf("Posicion %d: %s\n", i, vector[i]);
        }
    } else if (rank == 2) {
        MPI_Recv(&vector, VECTOR_SIZE * MAX_STRING_LENGTH, MPI_CHAR, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

        printf("Proceso 2 - Impares:\n");
        for (int i = 1; i < num_elements; i += 2) {
            printf("Posicion %d: %s\n", i, vector[i]);
        }
    }

    MPI_Finalize();
}
