using MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class api2 : ContentPage
	{
        private const string Url = "https://chat-nodejs-gal05.c9users.io/personas";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<Post> _posts;

        public api2 ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
        protected override async void OnAppearing()
        {
            string content = await _client.GetStringAsync(Url);
            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(content);
            _posts = new ObservableCollection<Post>(posts);
            MyListView.ItemsSource = _posts;
            base.OnAppearing();
        }
        private async void  OnAdd(Object sender,EventArgs e)
        {

            Post post = new Post {Id=0, Nombre = "xamarin", Apellido = "form", Edad = 22 };
            string content = JsonConvert.SerializeObject(post);
            Debug.WriteLine(content);
            await _client.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));
            _posts.Insert(0, post);
        }

    }
}