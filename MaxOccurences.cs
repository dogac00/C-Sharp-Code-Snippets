using System.Collections.Generic;

public class Test {
    public static int MaxOccurence(Dictionary<string, int> occurences) {
        var max = new KeyValuePair<string, int>("", int.MinValue);
        
        foreach (var i in occurences)
            if (max.Value > i.Value)
                max = i;
        
        return 0;
    }
}
