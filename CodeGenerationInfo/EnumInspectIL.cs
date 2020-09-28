public enum Color {
    Red, Green, Blue
}

// Gets converted to

public class Color : System.Enum {
    public const int Red = 0;
    public const int Green = 0;
    public const int Blue = 0;
}

// Second code will not compile
// but this class is what
// our Enum will be converted to in IL
