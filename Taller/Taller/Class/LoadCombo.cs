using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Taller
{
    class LoadCombo
    {
        Crud paso = new Crud();
        public DataTable CargarCombo()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_CARGARCOMBOBOX2", paso.conexion);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return (dt);


        }

        public DataTable CargarComboFecha()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_CARGARFECHA", paso.conexion);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return (dt);


        }


    }
}
