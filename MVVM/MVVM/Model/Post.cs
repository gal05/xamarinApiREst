using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MVVM.Model
{
    public class Post:INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _nombre;

        [JsonProperty("nombre")]
        public string Nombre {
            get { return _nombre; }
            set { _nombre = value;
                OnPropertyChanged();
            }
        }


        private string _apellido;
        [JsonProperty("apellido")]
        public string Apellido{
            get { return _apellido; }
            set { _apellido = value;
                OnPropertyChanged();
            }
        }

        private int _edad;
        [JsonProperty("edad")]
        public int Edad
        {
            get { return _edad; }
            set
            {
                _edad = value;
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
