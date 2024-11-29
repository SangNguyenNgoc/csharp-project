using BookingTour.App.Gui;
using BookingTour.App.Tests;

namespace BookingTour.App;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        bool isLoggedIn = false;

        do
        {
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    isLoggedIn = true;
                }
                else
                {
                    isLoggedIn = false;
                }
            }

            if (isLoggedIn)
            {
                using var mainForm = new MainForm();
                if (mainForm.ShowDialog() == DialogResult.Cancel)
                {
                    isLoggedIn = false;
                }
            }

        } while (isLoggedIn);
        /*
        //Application.Run(new MainForm());
        Test test = new Test();
        test.Run();*/
    }
}