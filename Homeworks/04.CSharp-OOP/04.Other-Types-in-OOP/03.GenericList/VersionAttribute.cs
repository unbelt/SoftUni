namespace GenericList
{
    /* Create a [Version] attribute that can be applied to
     * structures, classes, interfaces, enumerations and methods
     * and holds a version in the format major.minor (e.g. 2.11).
     * Apply the version attribute to GenericList<T> class and display its version at runtime.
     */
    [System.AttributeUsage(System.AttributeTargets.Struct |
                           System.AttributeTargets.Class |
                           System.AttributeTargets.Interface |
                           System.AttributeTargets.Enum |
                           System.AttributeTargets.Method)
    ]
    public class VersionAttribute : System.Attribute
    {
        public VersionAttribute(double version)
        {
            this.Version = version;
        }

        public double Version { get; private set; }
    }
}