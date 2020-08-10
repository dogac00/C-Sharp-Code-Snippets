using System.IO;
using System.Text;

namespace ConsoleAppCs
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("instructions.txt");
            var sb = new StringBuilder("const instructions = {\n");

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                var split = line.Split('\t');
                var code = split[0];
                var summary = split[1];

                var comp = $"'{code.ToLower()}': '{summary}',\n";

                sb.Append(comp);
            }

            sb.Append("} as { [key: string]: string | undefined };");

            File.WriteAllText("tsinstr.txt", sb.ToString());
        }
    }
}
