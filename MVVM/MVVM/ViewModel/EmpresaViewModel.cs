using MVVM.Model;
using MVVM.Servicio;
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
        public ObservableCollection<EmpresaModel> Empresas { get; set; }
        EmpresaServicio servicio = new EmpresaServicio();

        EmpresaModel empresa;
        private ObservableCollection<EmpresaModel> away;

        public EmpresaViewModel()
        {
            ListarCommand = new Command(async () => await listarEmpresasAsync());
            GuardarCommand = new Command(async () => await Guardar());
            ModificarCommand = new Command(async () => await Modificar());
            EliminarCommand = new Command(async () => await Eliminar());
            LimpiarCommand = new Command(async () => await Limpiar());
        }
        public Command ListarCommand { get; set; }
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
            Debug.WriteLine(Empresas);
        }

        private async Task Limpiar()
        {
            await Task.Delay(1000);
            Nombre = "";
            Direccion= "";
            Telefono = 0;
            Nempleados = 0;
        }
        
        public  async Task listarEmpresasAsync()
        {
            Empresas = await servicio.getEmpresas();
            Debug.WriteLine("Consulta ..............." + Empresas[0].Id + " nombre : " + Empresas[0].Nombre);
        }
    }
}
