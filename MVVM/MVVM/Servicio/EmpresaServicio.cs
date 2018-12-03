using MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Servicio
{
    public class EmpresaServicio
    {
        public ObservableCollection<EmpresaModel> empresas { get; set; }
        private ObservableCollection<EmpresaModel> _empresas;
        private const string Url = "https://chat-nodejs-gal05.c9users.io/empresas";
        private readonly HttpClient _client = new HttpClient();

        public EmpresaServicio()
        {
            if (empresas == null)
            {
                empresas = new ObservableCollection<EmpresaModel>();
            }
        }

        public ObservableCollection<EmpresaModel> Consultar()
        {
            return empresas;
        }

        public async Task<ObservableCollection<EmpresaModel>> getEmpresas()
        {
            string content = await _client.GetStringAsync(Url);
            List<EmpresaModel> posts = JsonConvert.DeserializeObject<List<EmpresaModel>>(content);
            _empresas = new ObservableCollection<EmpresaModel>(posts);
            //Debug.WriteLine("Consulta ...............desde servicio" + _empresas[0].Id + " nombre : " + _empresas[0].Nombre);
            string s = JsonConvert.SerializeObject(_empresas);
            Debug.WriteLine(s);
            return _empresas;   
        }

        public void GuardarLocal(EmpresaModel modelo)
        {
            empresas.Add(modelo);
        }
    }

}
