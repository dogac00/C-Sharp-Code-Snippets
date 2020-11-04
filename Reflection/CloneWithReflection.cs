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

            // Note that this is a shallow copy,
            // value types in the object are bitwise copied
            // and reference types are copied but
            // the values that references point to are not copied
            // because of this, original object may affect the cloned object and vice versa
            StringBuilder cloned = cloneMethod.Invoke(sb, null) as StringBuilder;
        }
    }
}
