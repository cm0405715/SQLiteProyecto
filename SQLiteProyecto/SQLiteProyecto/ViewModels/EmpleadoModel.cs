using System;
using System.Collections.Generic;
using System.Text;
using SQLiteProyecto.Models;
using SQLiteProyecto.Base;
using SQLiteProyecto.Repositories;
using Xamarin.Forms;

namespace SQLiteProyecto.ViewModels
{
    public class EmpleadoModel : ViewModelBase
    {
        private Empleado _Empleado; 
        RepositoryEmpleados repo;

        public EmpleadoModel()
        {
            this.repo = new RepositoryEmpleados();
            this.Empleado = new Empleado();
        }

        public Empleado Empleado
        {
            get { return this._Empleado; }
            set
            {
                this._Empleado = value;
                OnPropertyChanged("Empleado");
            }
        }

        public Command InsertarEmpleado
        {
            get
            {
                return new Command(() => {
                    this.repo.InsertarEmpleado(this.Empleado.Nombre,
                        Empleado.Apellidos,
                        Empleado.Edad,
                        Empleado.Sexo,
                        Empleado.Direccion,
                        Empleado.Telefono);
                });
            }
        }

        public Command ModificarEmpleado
        {
            get
            {
                return new Command(() => {
                    this.repo.ModificarEmpleado(this.Empleado.IdEmpleado,
                        Empleado.Nombre,
                        Empleado.Apellidos,
                        Empleado.Edad,
                        Empleado.Sexo,
                        Empleado.Direccion,
                        Empleado.Telefono);
                });
            }
        }

        public Command EliminarEmpleado
        {
            get
            {
                return new Command(() => {
                    this.repo.EliminarEmpleado(this.Empleado.IdEmpleado);
                });
            }
        }

    }
}
