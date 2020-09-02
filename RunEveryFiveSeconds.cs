private void RunEveryFiveSeconds()
{
    var startTimeSpan = TimeSpan.Zero;
    var periodTimeSpan = TimeSpan.FromSeconds(5);

    var timer = new System.Threading.Timer((e) =>
    {
        MessageBox.Show("Run");
    }, null, startTimeSpan, periodTimeSpan);
}
