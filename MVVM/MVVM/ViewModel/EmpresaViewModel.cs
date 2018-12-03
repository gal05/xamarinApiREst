using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM.ViewModel
{
    public class EmpresaViewModel:EmpresaModel
    {
        public ObservableCollection<EmpresaModel> empresas { get; set; }
        //PersonaServicio servicio = new PersonaServicio();

        EmpresaModel empresa;

        public EmpresaViewModel()
        {
            Personas = servicio.Consultar();
            GuardarCommand = new Command(async () => await Guardar());
            ModificarCommand = new Command(async () => await Modificar());
            EliminarCommand = new Command(async () => await Eliminar());
            LimpiarCommand = new Command(async () => await Limpiar());
        }

        public Command GuardarCommand { get; set; }
        public Command ModificarCommand { get; set; }
        public Command EliminarCommand { get; set; }
        public Command LimpiarCommand { get; set; }

        private async Task Guardar()
        {
            await Task.Delay(1000);
            Guid IdEmpresa = Guid.NewGuid();
            empresa = new EmpresaModel()
            {
                Nombre = Nombre,
                Direccion = Direccion,
                Telefono = Telefono ,
                Nempleados= Nempleados,
                Id = IdEmpresa.ToString()
            };
            Debug.WriteLine("guardar el id ..............."+empresa.Id+" nombre : " + empresa.Nombre);
            
        }
        private async Task Modificar()
        {
            await Task.Delay(1000);
            Debug.WriteLine("Guarda ctM!");
        }
        private async Task Eliminar()
        {
            await Task.Delay(1000);
            Debug.WriteLine("Guarda ctM!");
        }

        private async Task Limpiar()
        {
            await Task.Delay(1000);
            Nombre = "";
            Direccion= "";
            Telefono = 0;
            Nempleados = 0;
        }
    }
}
