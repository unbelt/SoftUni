namespace DistanceCalculator_SOAP
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IDistanceCalculator
    {
        [OperationContract]
        double CalculateDistance(Point pointA, Point pointB);
    }
}