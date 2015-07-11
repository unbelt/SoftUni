namespace DistanceCalculator_REST.Controllers
{
    using System;
    using System.Web.Http;

    public class DistanceCalculatorController : ApiController
    {
        // TEST: http://localhost:10114/CalculateDistance?aX=1&aY=2&bX=10&bY=20
        // POST api/CalculateDistance
        [HttpPost]
        [Route("CalculateDistance")]
        public double CalculateDistance(int aX, int aY, int bX, int bY)
        {
            double deltaX = aX - bX;
            double deltaY = aY - bY;

            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            return distance;
        }
    }
}