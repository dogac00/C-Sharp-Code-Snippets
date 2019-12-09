using System;
using System.Reflection;
using System.Threading;

class Program
{
  static void Main(string[] args)
  {
      void Action(object o) => Console.WriteLine("Hello");

      Timer timer = new Timer(new TimerCallback((Action<object>) Action), null, 15000, 12000);

      long val = GetPeriod(timer);

      Console.WriteLine(val);

      Console.Read();
  }
}

static class TimerExtensions
{
  public static uint GetPeriod(this Timer timer)
  {
      object mTimer = timer.GetType().GetField("m_timer",
              BindingFlags.NonPublic | BindingFlags.Instance)
          .GetValue(timer);

      object mTimerTimer = mTimer.GetType().GetField("m_timer",
              BindingFlags.NonPublic | BindingFlags.Instance)
          .GetValue(mTimer);

      object period = mTimerTimer.GetType().GetField("m_period",
              BindingFlags.NonPublic | BindingFlags.Instance)
          .GetValue(mTimerTimer);

      return (uint) period;
  }
}
  
