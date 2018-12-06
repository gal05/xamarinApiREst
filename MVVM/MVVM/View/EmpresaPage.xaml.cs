using MVVM.Model;
using MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmpresaPage : ContentPage
	{
        public ObservableCollection<EmpresaModel> Empresas { get; set; }
        EmpresaViewModel contexto = new EmpresaViewModel();
        public EmpresaPage ()
		{
			InitializeComponent ();
            BindingContext = contexto;
            //Empresas.ItemSource = contexto.ListarCommand;
            LvEmpresas.ItemSelected += LvEmpresas_ItemSelected;
            
        }
        private void LvEmpresas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                EmpresaModel empresa= (EmpresaModel)e.SelectedItem;
                contexto.Nombre = empresa.Nombre;
                contexto.Direccion = empresa.Direccion;
                contexto.Telefono = empresa.Telefono;
                contexto.Nempleados = empresa.Nempleados;
                contexto.Id= empresa.Id;
            }
        }
    }
}