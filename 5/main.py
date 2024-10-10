import multiprocessing as mp
import decimal

decimal.getcontext().prec = 128


def nilakantha(ini, fin):
    suma = decimal.Decimal(0)
    signo = 1
    for i in range(ini, fin):
        n = 2 + 2 * i
        termino = decimal.Decimal(4) / (n * (n + 1) * (n + 2))
        suma += signo * termino
        signo *= -1
    return suma


def aproximacion(iteraciones, procesadores):
    tamano = iteraciones // procesadores

    rangos = [(i * tamano, (i + 1) * tamano) for i in range(procesadores)]

    if iteraciones % procesadores != 0:
        rangos[-1] = (rangos[-1][0], iteraciones)

    with mp.Pool(processes=procesadores) as pool:
        resultados = pool.starmap(nilakantha, rangos)

    suma = sum(resultados)
    pi = decimal.Decimal(3) + suma

    return pi


if __name__ == "__main__":
    procesadores = mp.cpu_count()
    limite = 1000000
    pi = aproximacion(limite, procesadores)
    print(f"Aproximación de Pi: {pi}")
    print(f"Se hicieron: {limite} iteraciones")

