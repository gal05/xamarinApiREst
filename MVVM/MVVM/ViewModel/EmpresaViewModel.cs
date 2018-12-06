﻿using MVVM.Model;
using MVVM.Servicio;
using Newtonsoft.Json;
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
        public ObservableCollection<EmpresaModel> empresasFromApi { get; set; }
        EmpresaServicio servicio = new EmpresaServicio();

        EmpresaModel empresa;

        public  EmpresaViewModel()
        {
            Empresas = servicio.Consultar();
            IsBusy = false;
            ListarCommand = new Command(async () => await listarEmpresasAsync(), () => !IsBusy);
            GuardarCommand = new Command(async () => await Guardar(), () => !IsBusy);
            ModificarCommand = new Command(async () => await Modificar(), () => !IsBusy);
            EliminarCommand = new Command(async () => await Eliminar(), () => !IsBusy);
            LimpiarCommand = new Command(Limpiar, () => !IsBusy);
        }
        public Command ListarCommand { get; set; }
        public Command GuardarCommand { get; set; }
        public Command ModificarCommand { get; set; }
        public Command EliminarCommand { get; set; }
        public Command LimpiarCommand { get; set; }

  


        private async Task Guardar()
        {
            IsBusy = true;
            string ido="";
            Guid IdEmpresa = Guid.NewGuid();
            ido = Id;
            await Task.Delay(1000);
            if (Id ==null || Id == "")
            {
                ido = IdEmpresa.ToString();
            }

            empresa = new EmpresaModel()
            {
                Nombre = Nombre,
                Direccion = Direccion,
                Telefono = Telefono ,
                Nempleados= Nempleados,
                Id = ido
            };
            Debug.WriteLine("guardar el id ..............."+empresa.Id+" nombre : " + empresa.Nombre);
            servicio.OnAdd(empresa);
            IsBusy = false;
        }
        private async Task Modificar()
        {
            IsBusy = true;
            empresa = new EmpresaModel()
            {
                Nombre = Nombre,
                Direccion = Direccion,
                Telefono = Telefono,
                Nempleados = Nempleados,
                Id = Id
            };
            Debug.WriteLine("modificar el id ..............." + empresa.Id + " nombre : " + empresa.Nombre);
            servicio.Update(empresa);
            await Task.Delay(1000);
            IsBusy = false;
        }
        private async Task Eliminar()
        {
            IsBusy = true;
            servicio.Delete(Id);
            await Task.Delay(1000);
            Debug.WriteLine(Empresas[0].Id);
            
            IsBusy = false;
        }

        private void  Limpiar()
        {
            Nombre = "";
            Direccion= "";
            Telefono = 0;
            Nempleados = 0;
            Id = "";
        }


        public  async Task listarEmpresasAsync()
        {
            IsBusy = true;
            Empresas.Clear();
            empresasFromApi = await servicio.getEmpresas();
            string s = JsonConvert.SerializeObject(empresasFromApi);
            Debug.WriteLine("desde view model     :    "+s);
            foreach (EmpresaModel emp in empresasFromApi)
            {
                servicio.GuardarLocal(emp);
                //Debug.WriteLine(emp.Id);
            }
            //string a = JsonConvert.SerializeObject(Empresas);
            //Debug.WriteLine("desde viewmodelContructor     :    " + a);
            await Task.Delay(1000);
            IsBusy = false;
        }
    }
}
