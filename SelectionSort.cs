class Sort
  {
      public static void Selection(int[] a)
      {
          int min, minIndex;

          for (int i = 0; i < a.Length - 1; ++i)
          {
              min = a[i];
              minIndex = i;

              for (int k = i + 1; k < a.Length; ++k)
                  if (a[k] < min)
                  {
                      min = a[k];
                      minIndex = k;
                  }

              a[minIndex] = a[i];
              a[i] = min;
          }
      }

      public static void Disp(int[] a)
      {
          for (int i = 0; i < a.Length; ++i)
              Console.Write("{0} ", a[i]);
          Console.WriteLine();
      }
  }
