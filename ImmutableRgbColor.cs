public readonly struct RgbColor : IEquatable<RgbColor>
    {
        public int Red { get; }
        public int Green { get; }
        public int Blue { get; }

        public RgbColor(int blue, int green, int red)
        {
            if (blue > 255 || blue < 0 || 
                green > 255 || green < 0 ||
                red > 255 || red < 0)
                throw new ArgumentException();

            Red = red;
            Green = green;
            Blue = blue;
        }

        public override string ToString()
        {
            return $"Red : {Red}, Green: {Green}, Blue: {Blue}";
        }

        public override bool Equals(object obj)
        {
            var other = obj as RgbColor;

            return this.Red == other.Red &&
                   this.Green == other.Green &&
                   this.Blue == other.Blue;
        }

        public static bool operator ==(RgbColor first, RgbColor second)
        {
            if (object.ReferenceEquals(first, null))
                return object.ReferenceEquals(second, null);

            return first.Equals(second);
        }

        public static bool operator !=(RgbColor first, RgbColor second)
        {
            return !(first == second);
        }

        public bool Equals(RgbColor other)
        {
            return Red == other.Red && 
                   Green == other.Green && 
                   Blue == other.Blue;
        }
        
        // It is a recommended GetHashCode technique
        // to xor every property value that are unique to that object
        // and keep multiplying the result by some prime number
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Red;
                hashCode = (hashCode * 397) ^ Green;
                hashCode = (hashCode * 397) ^ Blue;
                return hashCode;
            }
        }
    }
