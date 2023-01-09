using Plugin.LocalNotification;
using ProiectMAUIHairsalon.Models;

namespace ProiectMAUIHairsalon;

public partial class SalonPage : ContentPage
{
	public SalonPage()
	{
		InitializeComponent();
	}
    async void SalveazaClicked(object sender, EventArgs e) 
	{ 
		var salon = (Salon)BindingContext; 
		await App.Database.SalveazaSalonAsync(salon); 
		await Navigation.PopAsync(); 
	}
    async void ArataPeHartaClicked(object sender, EventArgs e)
    {
        var salon = (Salon)BindingContext; 
        var adresa = salon.Adresa; 
        var locations = await Geocoding.GetLocationsAsync(adresa);
        var options = new MapLaunchOptions { Name = salon.NumeSalon };
        var location = locations?.FirstOrDefault();
        var myLocation = await Geolocation.GetLocationAsync();
        //var myLocation = new Location(46.7731796289, 23.6213886738);
        await Map.OpenAsync(location, options);

        
    }
}