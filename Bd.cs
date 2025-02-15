

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;



namespace CRUD.WindowsForms

{
    internal class Bd

    {
        public static SqlConnection Conexion()

             {
            SqlConnection connection = new SqlConnection("SERVER=DESKTOP-RQBMPFL;DATABASE=Registro; Integrated Security=TRUE;TrustServerCertificate=True");
           connection.Open();
            return connection;
        }

    }
}
