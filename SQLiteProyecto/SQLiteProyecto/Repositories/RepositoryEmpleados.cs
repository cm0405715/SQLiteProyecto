using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using SQLiteProyecto.Dependencies;
using SQLiteProyecto.Models;
using Xamarin.Forms;

namespace SQLiteProyecto.Repositories
{
    public class RepositoryEmpleados
    {
        private SQLiteConnection cn;

        public RepositoryEmpleados()
        {
            this.cn = DependencyService.Get<IDataBase>().GetConnection();
        }

        public string CrearBBDD()
        {
            try
            {
                //this.cn.DropTable<Empleado>();
                this.cn.CreateTable<Empleado>();
                return "Base de datos creada!";
            }
            catch (SQLiteException)
            {
                return "No se ha creado base de datos!";
            }
        }

        public List<Empleado> GetEmpleados()
        {
            var consulta = from datos in cn.Table<Empleado>()
                           select datos;
            return consulta.ToList();
        }

        public Empleado BuscarEmpleado(int id)
        {
            var consulta = from datos in cn.Table<Empleado>()
                           where datos.IdEmpleado == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void InsertarEmpleado(string nombre, string apellidos, int edad, string sexo, string direccion, string telefono)
        {
            Empleado empleado = new Empleado();
            empleado.Nombre = nombre;
            empleado.Apellidos = apellidos;
            empleado.Edad = edad;
            empleado.Sexo = sexo;
            empleado.Direccion = direccion;
            empleado.Telefono = telefono;
            try
            {
                this.cn.Insert(empleado);
                Console.WriteLine("Registro insertado!");
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void ModificarEmpleado(int idempleado, string nombre, string apellidos, int edad, string sexo, string direccion, string telefono)
        {
            Empleado empleado = this.BuscarEmpleado(idempleado);
            empleado.Nombre = nombre;
            empleado.Apellidos = apellidos;
            empleado.Edad = edad;
            empleado.Sexo = sexo;
            empleado.Direccion = direccion;
            empleado.Telefono = telefono;
            try
            {
                this.cn.Update(empleado);
                Console.WriteLine("Registro modificado!");
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void EliminarEmpleado(int idempleado)
        {
            Empleado empleado = this.BuscarEmpleado(idempleado);
            try
            {
                this.cn.Delete<Empleado>(idempleado);
                Console.WriteLine("Registro eliminado!");
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
