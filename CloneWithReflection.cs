using System.Reflection;
using System.Text;

namespace CloneWithReflection
{
    internal class Program
    {

        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("clone me!");

            MethodInfo cloneMethod = sb
                                    .GetType()
                                    .GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder cloned = cloneMethod.Invoke(sb, null) as StringBuilder;
        }
    }
}
