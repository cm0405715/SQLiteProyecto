using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteProyecto.Dependencies
{
    public interface IDataBase
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
