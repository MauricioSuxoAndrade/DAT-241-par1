﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServicioCalculadora
{
    /// <summary>
    /// Descripción breve de CalculaPrefija
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class CalculaPrefija : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        private NotacionPrefija calculadora;

        public CalculaPrefija()
        {
            calculadora = new NotacionPrefija();
        }

        [WebMethod]
        public double Evaluar(string expresion)
        {
            return calculadora.Evaluar(expresion);
        }
    }

    public class Operaciones
    {
        public double Sumar(double a, double b)
        {
            return a + b;
        }

        public double Restar(double a, double b)
        {
            return a - b;
        }

        public double Multiplicar(double a, double b)
        {
            return a * b;
        }

        public double Dividir(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("División entre cero.");
            return a / b;
        }
    }

    public class NotacionPrefija
    {
        private Operaciones operaciones;

        public NotacionPrefija()
        {
            operaciones = new Operaciones();
        }

        public double Evaluar(string expresion)
        {
            if (expresion.EndsWith(" "))
            {
                expresion = expresion.Substring(0, expresion.Length - 1);
            }

            Stack<double> stack = new Stack<double>();
            string[] tokens = expresion.Split(' ');

            for (int i = tokens.Length - 1; i >= 0; i--)
            {
                string token = tokens[i];

                if (EsOperador(token))
                {
                    double op1 = stack.Pop();
                    double op2 = stack.Pop();
                    double resultado = AplicarOperacion(token, op1, op2);
                    stack.Push(resultado);
                }
                else
                {
                    stack.Push(Convert.ToDouble(token));
                }
            }

            return stack.Pop();
        }

        private bool EsOperador(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }

        private double AplicarOperacion(string operador, double op1, double op2)
        {
            switch (operador)
            {
                case "+":
                    return operaciones.Sumar(op1, op2);
                case "-":
                    return operaciones.Restar(op1, op2);
                case "*":
                    return operaciones.Multiplicar(op1, op2);
                case "/":
                    return operaciones.Dividir(op1, op2);
                default:
                    throw new ArgumentException("Operador desconocido: " + operador);
            }
        }
    }
}
