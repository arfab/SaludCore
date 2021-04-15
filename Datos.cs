using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using SaludCore.Models;
using System;

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

        public static string InsertarRegistro(Registro registro)
        {

            string ret = "";


            try
            {


                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

               

                    DynamicParameters parameters = new DynamicParameters();
       
                    parameters.Add("@paciente_id", 7);
                    parameters.Add("@fecha", "2017-01-27");
                    parameters.Add("@hora", "14:30");
                    parameters.Add("@comida_id", registro.comida_id);
                    parameters.Add("@descripcion", registro.descripcion);
                    int rowAffected = con.Execute("RegistroInsertar", parameters, commandType: CommandType.StoredProcedure);      

                }

            }
            catch (Exception ex)
            {
                registro.errorDesc = ex.Message;
                ret = ex.Message;
            }

            return ret;
        }


        public static List<Models.Registro> ObtenerComidas()
        {
            List<Models.Registro> lComida = new List<Models.Registro>();
                
            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                lComida = con.Query<Models.Registro>("ComidaObtenerTodos").ToList();
            }

            return lComida;
        }

    }
}
