using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLiteProyecto.Repositories;
using SQLiteProyecto.Views;
using SQLiteProyecto.ViewModels;
using SQLiteProyecto.Models;

namespace SQLiteProyecto
{
    public partial class MainPage : ContentPage
    {
        RepositoryEmpleados repo;
        public string dbstatus { get; set; }
        public MainPage()
        {

            InitializeComponent();

            this.repo = new RepositoryEmpleados();
            this.dbstatus = this.repo.CrearBBDD();
            lblStatus.Text = this.dbstatus;
            this.btnEliminar.Clicked += BtnEliminar_Clicked;
            this.btnModificar.Clicked += BtnModificar_Clicked;
            this.btnMostrar.Clicked += BtnMostrar_Clicked;
            this.btnNuevo.Clicked += BtnNuevo_Clicked;
        }

        private async void BtnNuevo_Clicked(object sender, EventArgs e)
        {
            InsertarEmpleado view = new InsertarEmpleado();
            await Navigation.PushModalAsync(view);
        }

        private async void BtnMostrar_Clicked(object sender, EventArgs e)
        {
            EmpleadosView view = new EmpleadosView();
            //((NavigationPage)this.Parent).PushAsync(view);
            await Navigation.PushModalAsync(view);
        }

        private async void BtnModificar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cajaid.Text))
            {
                ModificarEmpleado view = new ModificarEmpleado();
                EmpleadoModel viewmodel = new EmpleadoModel();

                //buscar empleado
                int id = int.Parse(this.cajaid.Text);

                //asociar id con viewmodel
                Empleado empleado = this.repo.BuscarEmpleado(id);
                viewmodel.Empleado = empleado;
                view.BindingContext = viewmodel;
                await Navigation.PushModalAsync(view);
                //((NavigationPage)this.Parent).PushAsync(view);
            }
            else
            {
                Console.WriteLine("No hay id para buscar empleado!.");
            }
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cajaid.Text))
            {
                EliminaEmpleado view = new EliminaEmpleado();
                EmpleadoModel viewmodel = new EmpleadoModel();

                int id = int.Parse(this.cajaid.Text);

                Empleado empleado = this.repo.BuscarEmpleado(id);
                viewmodel.Empleado = empleado;
                view.BindingContext = viewmodel;
                await Navigation.PushModalAsync(view);
                //((NavigationPage)this.Parent).PushAsync(view);

            }
            else
            {
                Console.WriteLine("No hay id para buscar empleado!.");
            }

        }
    }
}
