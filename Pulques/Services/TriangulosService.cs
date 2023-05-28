using Pulques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Pulques.Services
{
    public class TriangulosService
    {
        public double DistanceToPoints(Punto punto1, Punto punto2)
        {
            double resultado = Math.Sqrt(Math.Pow(punto2.X - punto1.X, 2) + Math.Pow(punto2.Y - punto1.Y, 2));

            return resultado;
        }

        public double GetTriangleArea(Punto punto1, Punto punto2, Punto punto3) { 
            double DeltaX1 = punto2.X - punto1.X;
            double DeltaY1 = punto2.Y - punto1.Y;
            double DeltaX2 = punto3.X - punto1.X;
            double DeltaY2 = punto3.Y - punto1.Y;

            double ProductoCruzado = (DeltaX1 * DeltaY2) - (DeltaX2 * DeltaY1);

            return (ProductoCruzado / 2);
        }
    }
}