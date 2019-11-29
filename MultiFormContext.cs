
class MultiFormContext : ApplicationContext
  {
      public MultiFormContext(params Form [] forms)
      {
          int count = forms.Length;

          foreach (Form form in forms)
          {
              form.Closed += (sender, args) =>
              {
                  if (Interlocked.Decrement(ref count) == 0)
                      ExitThread();
              };

              form.Show();
          }
      }
  }
