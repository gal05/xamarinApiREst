using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.Model
{
    public class EmpresaModel : INotifyPropertyChanged
    {
        private string _id;
        [JsonProperty("id")]
        public string Id {
            get { return _id; }
            set {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _nombre;
        [JsonProperty("nombre")]
        public string Nombre {
            get { return _nombre; }
            set { _nombre = value;
                OnPropertyChanged();
            }
        }


        private string _direccion;
        [JsonProperty("direccion")]
        public string Direccion { get { return _nombre; }
            set {
                _direccion = value;
                OnPropertyChanged();
            }
        }

        private string _telefono;
        [JsonProperty("telefono")]
        public string Telefono {
            get { return _telefono; }
            set {
                _telefono = value;
                OnPropertyChanged();
            }
        }


        private string _nempleados;
        [JsonProperty("nempleados")]
        public string Nempleados { get {
                return _nempleados;
            }
            set {
                _nempleados = value;
                OnPropertyChanged();
            }
        }
   
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
}
