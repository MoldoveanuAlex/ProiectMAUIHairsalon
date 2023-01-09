using System;
using ProiectMAUIHairsalon.Data;
using System.IO;

namespace ProiectMAUIHairsalon;

public partial class App : Application
{
    static ProgramareDatabase database;
    public static ProgramareDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
                ProgramareDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                LocalApplicationData), "Programare.db3"));
            }
            return database;
        }
    }


    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
