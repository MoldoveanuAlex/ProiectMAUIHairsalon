using Plugin.LocalNotification;
using ProiectMAUIHairsalon.Models;

namespace ProiectMAUIHairsalon;

public partial class ProgramarePage : ContentPage
{
	public ProgramarePage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		var items = await App.Database.GetSaloaneAsync(); SalonPicker.ItemsSource = (System.Collections.IList)items;
		SalonPicker.ItemDisplayBinding = new Binding("DetaliiSalon");
	}

        async void SalveazaButtonClicked(object sender, EventArgs e)
	{
		var slist = (Programare)BindingContext;
		slist.Data = slist.Data + slist.Timp;
		await App.Database.SalveazaProgramareAsync(slist);
		await Navigation.PopAsync();

		if (DateTime.Now.AddDays(1) >= slist.Data)
		{
			var request = new NotificationRequest
			{
				Title = "Ai o programare maine! " + slist.SalonID,
				Schedule = new NotificationRequestSchedule
				{
					NotifyTime = DateTime.Now.AddSeconds(1)
				}
			};
			LocalNotificationCenter.Current.Show(request);
		}

    }
	async void StergeButtonClicked(object sender, EventArgs e) 
	{ 
		var slist = (Programare)BindingContext; 
		await App.Database.StergeProgramareAsync(slist); 
		await Navigation.PopAsync(); 
	}
}