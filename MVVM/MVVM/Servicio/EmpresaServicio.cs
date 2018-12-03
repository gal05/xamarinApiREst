using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;

namespace MVVM.Servicio
{
    public class EmpresaServicio
    {
        public ObservableCollection<EmpresaModel> empresas { get; set; }
        private ObservableCollection<EmpresaModel> _empresa;
        private const string Url = "https://chat-nodejs-gal05.c9users.io/personas";
        private readonly HttpClient _client = new HttpClient();

        private async void getEmpresas()
        {
            var empresasGet = await _client.GetAsync(Url);
            var json = empresasGet.Content.ReadAsStringAsync().Result;
            EmpresaModel empresam = EmpresaModel.FromJson(json.[0]);
        }
    }

}
