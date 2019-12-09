public static uint GetPeriod(Timer timer)
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
