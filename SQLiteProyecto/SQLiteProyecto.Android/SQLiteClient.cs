using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLiteProyecto.Dependencies;
using SQLiteProyecto.Droid;
using SQLite;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(SQLiteClient))]
namespace SQLiteProyecto.Droid
{
    public class SQLiteClient : IDataBase
    {
        public SQLiteConnection GetConnection()
        {
            string bbddfile = "EMPLEADOS.db3";
            string rutadocumentos = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(rutadocumentos, bbddfile);
            SQLite.SQLiteConnection cn = new SQLite.SQLiteConnection(path);
            return cn;
        }
    }
}