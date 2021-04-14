using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;


namespace SaludCore
{
    public class Datos
    {

        static readonly string strConnectionString = Tools.GetConnectionString();

        public static Models.Usuario Login(string usuario, string clave)
        {
            Models.Usuario usu = new Models.Usuario();

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@usuario", usuario);
                parameter.Add("@clave", clave);
                usu = con.Query<Models.Usuario>("Login", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }

            return usu;
        }

        public static List<Models.Registro> ObtenerRegistro(int paciente_id, string fecha)
        {
            List<Models.Registro> lRegistro = new List<Models.Registro>();

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();


                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@paciente_id", paciente_id);
                parameter.Add("@fecha", fecha);
            
                lRegistro = con.Query<Models.Registro>("RegistroObtenerPorPacienteYFecha", parameter, commandType: CommandType.StoredProcedure).ToList();
            }

            return lRegistro;
        }


    }
}
