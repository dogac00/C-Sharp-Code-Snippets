
public class Sample {
    public string StringInterpolation(int val) {
        return $"Val = { val }";
    }
    
    // Above code gets converted to this
    public string GetsConvertedTo(int val) {
        return string.Format("Val = {0}", val);
    }
}
