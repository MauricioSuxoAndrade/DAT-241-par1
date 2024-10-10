import math

def fibo(n):
    if n <= 0:
        return []
    elif n == 1:
        return [0]
    elif n == 2:
        return [0, 1]

    lista = [0, 1]
    phi = (1 + math.sqrt(5)) / 2

    for i in range(2, n):
        fib_n = round((phi**i - (1 - phi)**i) / math.sqrt(5))
        lista.append(fib_n)

    return lista

if __name__ == "__main__":
    n = 100
    resultado = fibo(n)
    print(resultado)
