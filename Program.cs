namespace IPSys
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainPage()); //remove when finished coding



            //CHANGE WHEN FINISHED CODING
            /* 

            while (true)
            {
                LoginPage loginPage = new LoginPage();
                Application.Run(loginPage);

                if (loginPage.LoginSuccessful)
                {
                    MainPage mainPage = new MainPage();
                    Application.Run(mainPage);
                }
                else
                {
                    break; // Exit app if login wasn't successful or user closed the form
                }

            }
            */
        }
    }
}