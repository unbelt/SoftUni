namespace FractionCalculator
{
    using System;
    using System.Globalization;

    public struct Fraction
    {
        private long numerator, denominator;

        #region Constructors

        public Fraction(long num, long den)
            : this()
        {
            CheckDenominatorZero(den);

            CheckMinValue(num);
            CheckMinValue(den);

            var f = new Fraction((decimal)num, den);
            this.Initialize(f.numerator, f.denominator);
        }

        private Fraction(decimal r1, decimal r2)
        {
            decimal gcd = Gcd(Math.Abs(r1), Math.Abs(r2));

            var num = (long)(r1 / gcd);
            var den = (long)(r2 / gcd);

            CheckMinValue(num);
            CheckMinValue(den);

            if (r2 < 0)
            {
                num = -num;
                den = -den;
            }

            this.numerator = num;
            this.denominator = den;
        }

        #endregion

        #region Properties

        public long Numerator
        {
            get { return this.numerator; }
        }

        public long Denominator
        {
            get { return this.denominator; }
        }

        #endregion

        #region Overloaded Operators ( +-*/^ )

        #region Add

        public static Fraction operator +(Fraction a, Fraction b)
        {
            decimal r1 = ((decimal)a.numerator * b.denominator) + ((decimal)b.numerator * a.denominator);
            decimal r2 = (decimal)a.denominator * b.denominator;

            return new Fraction(r1, r2);
        }

        #endregion

        #region Substract

        public static Fraction operator -(Fraction a, Fraction b)
        {
            decimal r1 = ((decimal)a.numerator * b.denominator) - ((decimal)b.numerator * a.denominator);
            decimal r2 = (decimal)a.denominator * b.denominator;

            return new Fraction(r1, r2);
        }

        #endregion

        #region Multiply

        public static Fraction operator *(Fraction a, Fraction b)
        {
            decimal r1 = (decimal)a.numerator * b.numerator;
            decimal r2 = (decimal)a.denominator * b.denominator;

            return new Fraction(r1, r2);
        }

        #endregion

        #region Divide

        public static Fraction operator /(Fraction a, Fraction b)
        {
            decimal r1 = (decimal)a.numerator * b.denominator;
            decimal r2 = (decimal)a.denominator * b.numerator;

            if (r2 == 0)
            {
                throw new DivideByZeroException("The denominator of any fraction cannot have the value zero!");
            }

            return new Fraction(r1, r2);
        }

        #endregion

        #region Power

        public static Fraction operator ^(Fraction a, int n)
        {
            return new Fraction((decimal)Math.Pow(a.numerator, n), (decimal)Math.Pow(a.denominator, n));
        }

        #endregion

        #endregion

        #region Comparison Operators

        public static bool operator ==(Fraction a, Fraction b)
        {
            if (a == null || b == null)
            {
                throw new NullReferenceException();
            }

            return (decimal)a.numerator * b.denominator == (decimal)b.numerator * a.denominator;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return (decimal)a.numerator * b.denominator > (decimal)b.numerator * a.denominator;
        }

        public static bool operator >=(Fraction a, Fraction b)
        {
            return !(a < b);
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return (decimal)a.numerator * b.denominator < (decimal)b.numerator * a.denominator;
        }

        public static bool operator <=(Fraction a, Fraction b)
        {
            return !(a > b);
        }

        public static implicit operator double(Fraction f)
        {
            return (double)f.numerator / f.denominator;
        }

        #endregion

        #region Misc

        public override string ToString()
        {
            if (this.denominator == 1)
            {
                return this.numerator.ToString(CultureInfo.InvariantCulture);
            }

            return this.numerator + "/" + this.denominator;
        }

        public override bool Equals(object o)
        {
            if (o == null || o.GetType() != GetType())
            {
                return false;
            }

            var f = (Fraction)o;

            return this == f;
        }

        public override int GetHashCode()
        {
            return (int)(this.numerator ^ this.denominator);
        }

        // Euclid identities
        private static decimal Gcd(decimal a, decimal b)
        {
            if (b == 0)
            {
                return a;
            }

            return Gcd(b, a % b);
        }

        private static void CheckMinValue(long n)
        {
            if (n == long.MinValue)
            {
                throw new OverflowException("Overflow min value in long type.");
            }
        }

        private static void CheckDenominatorZero(decimal den)
        {
            if (den == 0)
            {
                throw new ArithmeticException("The denominator of any fraction cannot have the value zero!");
            }
        }

        private void Initialize(long num, long den)
        {
            this.numerator = num;
            this.denominator = den;
        }

        #endregion
    }
}