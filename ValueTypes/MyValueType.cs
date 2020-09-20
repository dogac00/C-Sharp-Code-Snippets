using System;
using System.Reflection;

namespace ConsoleAppCs
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var item1 = new Item("123");
            var item2 = new Item("123");

            Console.WriteLine(item1.GetHashCode());
            Console.WriteLine(item2.GetHashCode());
        }
    }

    class Item : MyValueType
    {
        private readonly string _val;
        
        public Item(string val)
        {
            _val = val;
        }
    }

    public class MyValueType : IEquatable<MyValueType>
    {
        public bool Equals(MyValueType other)
        {
            var fields = this.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var fieldInfo in fields)
            {
                var val1 = fieldInfo.GetValue(this);
                var val2 = fieldInfo.GetValue(other);

                if (val1 == null)
                {
                    if (val2 != null)
                    {
                        return false;
                    }
                }
                else if (!val1.Equals(val2))
                {
                    return false;
                }
            }
            
            return true;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            
            var type1 = GetType();
            var type2 = obj.GetType();

            if (type1 != type2)
            {
                return false;
            }

            return Equals(this, obj as MyValueType);
        }

        public override int GetHashCode()
        {
            var hash = 31;

            var fields = this.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                var hashCode = (field.GetValue(this) ?? 0).GetHashCode();

                hash ^= hashCode * 37;
            }
            
            return hash;
        }
    }
}
