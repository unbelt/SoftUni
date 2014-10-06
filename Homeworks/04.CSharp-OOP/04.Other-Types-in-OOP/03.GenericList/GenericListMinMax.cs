namespace GenericList
{
    using System;

    public static class GenericListMinMax
    {
        // Get min element
        public static T Min<T>(this GenericList<T> genericList) where T : IComparable<T>
        {
            if (genericList.Count == 0)
            {
                throw new NullReferenceException("The list is empty!");
            }

            dynamic min = genericList[0];

            for (int i = 1; i < genericList.Count; i++)
            {
                if (genericList[i] < min)
                {
                    min = genericList[i];
                }
            }

            return (T)min;
        }

        // Get max element
        public static T Max<T>(this GenericList<T> genericList) where T : IComparable<T>
        {
            if (genericList.Count == 0)
            {
                throw new NullReferenceException("The list is empty!");
            }

            dynamic max = genericList[0];

            for (int i = 1; i < genericList.Count; i++)
            {
                if (genericList[i] > max)
                {
                    max = genericList[i];
                }
            }

            return (T)max;
        }
    }
}
