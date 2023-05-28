using Pulques.Models;
using Pulques.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pulques.Controllers
{
    public class TriangulosController : Controller
    {
        // GET: Triangulos
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Triangulo triangulo)
        {
            String resultado;
            TriangulosService triangulosService = new TriangulosService();

            Punto punto1 = new Punto(triangulo.triangulo_1_x, triangulo.triangulo_1_y);
            Punto punto2 = new Punto(triangulo.triangulo_2_x, triangulo.triangulo_2_y);
            Punto punto3 = new Punto(triangulo.triangulo_3_x, triangulo.triangulo_3_y);

            //--------------------------------------------------------------------------

            double distancia1_2 = triangulosService.DistanceToPoints(punto1, punto2);
            double distancia2_3 = triangulosService.DistanceToPoints(punto2, punto3);
            double distancia3_1 = triangulosService.DistanceToPoints(punto3, punto1);
            const double TOLERANCIA = 0.01;

            if (Math.Abs(distancia1_2 - distancia2_3) < TOLERANCIA &&
                Math.Abs(distancia2_3 - distancia3_1) < TOLERANCIA &&
                Math.Abs(distancia3_1 - distancia1_2) < TOLERANCIA) {
                resultado = "El triangulo es equilatero";
            } else if(distancia1_2 == distancia2_3 || distancia2_3 == distancia3_1 || distancia3_1 == distancia1_2)
            {
                resultado = "El triangulo es Isoceles";
            }
            else
            {
                resultado = "El triangulo es escaleno";
            }

            //--------------------------------------------------------------------------
            var routeValues = new RouteValueDictionary
            {
                { "resultado", resultado },
                { "area" , triangulosService.GetTriangleArea(punto1, punto2, punto3) }
            };
            return RedirectToAction("Resultado", "Triangulos", routeValues);
        }

        public ActionResult Resultado(String resultado, double area)
        {
            ViewBag.Resultado = resultado;
            ViewBag.Area = area;
            return View();
        }
    }
}