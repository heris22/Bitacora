using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace Bitacora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnLogin_Clicked(System.Object sender, System.EventArgs e)
        {
            Login log = new Login
            {
                email = txtUsuario.Text,
                password = txtPassword.Text
            };
            Uri RequestUri = new Uri("http://imageapi.mayseecruz.com/public/api/login");

            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await Navigation.PushAsync(new HomeView());
            }
            else
            {
                await DisplayAlert("Mensaje", "Datos invalidos", "OK");
            }
        }
    }
}

