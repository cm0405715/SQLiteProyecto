using System;
using System.Collections.Generic;
using System.Text;
using SQLiteProyecto.Base;
using SQLiteProyecto.Models;
using SQLiteProyecto.Repositories;
using System.Collections.ObjectModel;

namespace SQLiteProyecto.ViewModels
{
    public class EmpleadosViewModel : ViewModelBase
    {
        public EmpleadosViewModel()
        {
            RepositoryEmpleados repo = new RepositoryEmpleados();
            List<Empleado> lista = repo.GetEmpleados();
            this.Empleados = new ObservableCollection<Empleado>(lista);
        }

        private ObservableCollection<Empleado> _Empleados;

        public ObservableCollection<Empleado> Empleados
        {
            get
            {
                return this._Empleados;
            }
            set
            {
                this._Empleados = value;
                OnPropertyChanged("Empleados");
            }
        }
    }
}
