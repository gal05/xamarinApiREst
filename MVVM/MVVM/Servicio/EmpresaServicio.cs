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

        public async void OnAdd(EmpresaModel empresa)
        {
            
            
            string content = JsonConvert.SerializeObject(empresa);
            var o = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(content);
            o.Property("IsBusy").Remove();
            content = o.ToString();

            Debug.WriteLine("to guardar!!!!----------->"+content);
            await _client.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));
            empresas.Insert(0, empresa);
        }

        public void GuardarLocal(EmpresaModel modelo)
        {
            empresas.Add(modelo);
        }
        public async void Delete(string id)
        {
            Debug.WriteLine("to borrar!!!!----------->" + id);
            await _client.DeleteAsync(Url + "/" + id);
            Debug.WriteLine("Se borro" + id);
            for (int i = 0; i < empresas.Count; i++)
            {
                if (string.Equals(empresas[i].Id, id))
                {
                    empresas.Remove(empresas[i]);
                }
            }
        }
        public async void Update(EmpresaModel empresa)
        {
            string content = JsonConvert.SerializeObject(empresa);
            var o = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(content);
            o.Property("IsBusy").Remove();
            content = o.ToString();

            Debug.WriteLine("to update!!!!----------->" + content);
            await _client.PutAsync(Url+"/"+empresa.Id, new StringContent(content, Encoding.UTF8, "application/json"));
            for (int i = 0; i < empresas.Count; i++)
            {
                if (empresas[i].Id == empresa.Id)
                {
                    empresas[i] = empresa;
                }

            }

        }
            
    }

}
