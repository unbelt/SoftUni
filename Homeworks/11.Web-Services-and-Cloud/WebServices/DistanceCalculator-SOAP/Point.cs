namespace DistanceCalculator_SOAP
{
    using System.Runtime.Serialization;

    [DataContract]
    public struct Point
    {
        [DataMember]
        public int X { get; set; }

        [DataMember]
        public int Y { get; set; }
    }
}