using MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace MVVM.Servicio
{
    public class EmpresaServicio
    {
        public ObservableCollection<EmpresaModel> empresas { get; set; }
        private ObservableCollection<EmpresaModel> _empresas;
        private const string Url = "https://chat-nodejs-gal05.c9users.io/personas";
        private readonly HttpClient _client = new HttpClient();

        public EmpresaServicio()
        {
            if (_empresas == null)
            {
                getEmpresas();
            }

        }
        public ObservableCollection<EmpresaModel> Consultar()
        {
            return _empresas;
        }

        private async void getEmpresas()
        {
            string content = await _client.GetStringAsync(Url);
            List<EmpresaModel> posts = JsonConvert.DeserializeObject<List<EmpresaModel>>(content);
            _empresas = new ObservableCollection<EmpresaModel>(posts);
            Debug.WriteLine("Consulta ..............." + _empresas[0].Id + " nombre : " + _empresas[0].Nombre);
        }
    }

}
