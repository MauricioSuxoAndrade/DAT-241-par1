using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaInfija
{
    public class Infija
    {
        static int Precedencia(char operador)
        {
            switch (operador)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0;
            }
        }
        static bool EsOperador(char c)
        {
            return (c == '+' || c == '-' || c == '*' || c == '/');
        }
        public string Infijo(string expresion)
        {
            Stack<char> pila = new Stack<char>();
            string resultado = "";

            for (int i = 0; i < expresion.Length; i++)
            {
                char c = expresion[i];
                if (char.IsDigit(c))
                {
                    resultado += c;
                }
                else if (EsOperador(c))
                {
                    while (pila.Count > 0 && Precedencia(pila.Peek()) >= Precedencia(c))
                    {
                        resultado += pila.Pop();
                    }
                    pila.Push(c);
                }
            }
            while (pila.Count > 0)
            {
                resultado += pila.Pop();
            }

            return resultado;
        }
        public int Evaluar(string expresionPostfija)
        {
            Stack<int> pila = new Stack<int>();

            for (int i = 0; i < expresionPostfija.Length; i++)
            {
                char c = expresionPostfija[i];
                if (char.IsDigit(c))
                {
                    pila.Push(int.Parse(c.ToString()));
                }
                else if (EsOperador(c))
                {
                    int op2 = pila.Pop();
                    int op1 = pila.Pop();

                    switch (c)
                    {
                        case '+':
                            pila.Push(op1 + op2);
                            break;
                        case '-':
                            pila.Push(op1 - op2);
                            break;
                        case '*':
                            pila.Push(op1 * op2);
                            break;
                        case '/':
                            pila.Push(op1 / op2);
                            break;
                    }
                }
            }
            return pila.Pop();
        }
    }
}
