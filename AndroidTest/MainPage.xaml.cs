namespace AndroidTest;

using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class MainPage : ContentPage
{
	string city = "Saint Petersburg";
	readonly string key = "8c765466d34a1448fa1e7bac879dbd48";
	string url;
	HttpClient httpClient;
	public MainPage()
	{
		url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + key + "&units=metric&lang=ru";
		httpClient = new HttpClient();
        InitializeComponent();
	}

	private async void BtnClickCity(object sender, EventArgs e)
	{
		HttpResponseMessage response = await httpClient.GetAsync(url);
		var json = JObject.Parse(await response.Content.ReadAsStringAsync());
		var jsonWeather = JObject.Parse(json.GetValue("main").ToString());
		LabelForWeather.Text = $"Температура: {jsonWeather.GetValue("temp")}\n" +
			$"Ощущается как: {jsonWeather.GetValue("feels_like")}\n" +
			$"Давление: {jsonWeather.GetValue("pressure")}";
	}

	private void BtnClickSpb(object sender, EventArgs e)
	{

	}
}

