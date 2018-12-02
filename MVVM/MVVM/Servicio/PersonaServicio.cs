using MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace MVVM.Servicio
{
    public class PersonaServicio
    {
        public ObservableCollection<PersonaModel> personas { get; set; }
        private const string URL = "http://localhost:3000/personas";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<PersonaModel> _post;


        public PersonaServicio()
        {
            if (personas == null)
            {
                personas = new ObservableCollection<PersonaModel>();
            }
        }


        public ObservableCollection<PersonaModel> Consultar()
        {
 
            return personas;
        }
        public void Guardar(PersonaModel modelo)
        {
            personas.Add(modelo);
        }
        public void Modificar(PersonaModel modelo)
        {
            for (int i = 0; i < personas.Count; i++)
            {
                if (personas[i].Id==modelo.Id)
                {
                    personas[i] = modelo;
                }

            }
        }
        public void eliminar(string idPersona)
        {
            PersonaModel modelo = personas.FirstOrDefault(p => p.Id == idPersona);
            personas.Remove(modelo);
        }
    }
}






