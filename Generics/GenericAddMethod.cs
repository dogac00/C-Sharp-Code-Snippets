public static class Helper
    {
        public static T Add<T>(T t1, T t2) where T : unmanaged
        {
            var dynamicMethod = new DynamicMethod("Add",
                    typeof(T),
                    new[] {typeof(T), typeof(T)});

            var ilGenerator = dynamicMethod.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Add);
            ilGenerator.Emit(OpCodes.Ret);
            
            return (T) dynamicMethod.Invoke(null, new object[] {t1, t2});
        }
    }
