using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace ConfiguradorDAQPemex
{
    class AccesoUsuarios
    {
        private string usuario, contraseña;
        private int acceso;
        private string cadSeguridad;
        private SqlConnection cnSeguridad;


        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }

        public string Contraseña
        {
            get
            {
                return contraseña;
            }
            set
            {
                contraseña = value;
            }
        }

        public int Acceso()
        {
            return acceso;
        }


        //Constructores
        public AccesoUsuarios()
        {
           cadSeguridad = "Data Source=BARBAROJA\\sqlexpress;Initial Catalog=Config_Usrs;Integrated Security=True";
           cnSeguridad = new SqlConnection(cadSeguridad);
        }
        public AccesoUsuarios(string _usuario, string _contraseña):this()
        {
            nuevoUsuario(_usuario, _contraseña);
        }
        
        
        
        
        // Metodos
        
        /// <summary>
        /// Prepara a la clase para trabajar con un nuevo usuario
        /// </summary>
        /// <param name="_usuario">El Nombre del usario</param>
        /// <param name="_contraseña">su contraseña</param>
        public void nuevoUsuario(string _usuario, string _contraseña)
        {
            usuario = _usuario;
            contraseña = Hash(_contraseña);
        }
        
        /// <summary>
        /// Obtiene el nivel de acceso del usuario
        /// </summary>
        /// <returns>Regresa 1 si el usuario tiene acceso normal, 2 si es admin, y 0 si no tiene acceso</returns>
        public int nivelAcceso()
        {
            int temporal = 0;
            try
            {
                cnSeguridad.Open();
                string cadBusqueda = "SELECT TOP 1 Acceso FROM Usuarios WHERE Usuario='" + usuario + "'";
                using (SqlCommand busqueda = new SqlCommand(cadBusqueda, cnSeguridad))
                {
                    SqlDataReader lector = busqueda.ExecuteReader();
                    while (lector.Read())
                    {
                        temporal = lector.GetInt32(0);
                    }
                }
                return temporal;
            }
            catch (Exception e)
            {
                return temporal;
            }
            finally
            {
                cnSeguridad.Close();
            }
            
        }

        /// <summary>
        /// Revisa si el usuario se encuentra en la contraseña, comparando el nombre de usuario y el hash de la contraseña 
        /// ingresada. 
        /// </summary>
        /// <returns>regresa true si el usuario existe en la base de datos y false en caso contrario</returns>
        public bool validaUsuario()
        {      
            try
            {
                cnSeguridad.Open();
                string cadnBusqueda = "SELECT COUNT(ID) from Usuarios WHERE Usuario='" + usuario + "' AND Contraseña='" + contraseña + "'";
                using (SqlCommand busqueda = new SqlCommand(cadnBusqueda,cnSeguridad))
                {

                    int contador = (int)busqueda.ExecuteScalar();
                    if (contador > 0)
                    {
                        //LOGIN CORRECTO
                        return true;
                    }
                    else
                    {
                        //LOGIN INCORRECTO
                        return false;
                    }
                }

            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {

                cnSeguridad.Close();
            }

        }

        public void usuarioIncorrecto()
        {
            MessageBox.Show("Nombre de Usuario o Contraseña Incorrectos");
        }

        public void creaUsuario(string _usuario , string _contraseña, int acceso)
        {
            this.nuevoUsuario(_usuario, _contraseña);

            if (this.validaUsuario()==false)
            {
                
                string updateSql = "INSERT INTO Usuarios (Usuario, Contraseña, Acceso) " +
                    "VALUES ('" + usuario + "', '" + contraseña + "', " + acceso + ")";

                SqlCommand UpdateCmd = new SqlCommand(updateSql, cnSeguridad);
                try
                {

                    cnSeguridad.Open();
                   int  result = UpdateCmd.ExecuteNonQuery();
                   MessageBox.Show(result.ToString());
                }
                catch (Exception ex)
                {
                    writeLog(ex.ToString());
                }
                finally
                {
                    cnSeguridad.Close();
                }
            }
            else
            {
                MessageBox.Show("Usuario Ya existente");
            }
        }

        private void writeLog(string p)
        {
            TextWriter tw = new StreamWriter("C:\\Historiador\\Temporal\\LogSeguridad.txt", true);
            tw.WriteLine("Evento: " + p + " Fecha: " + DateTime.Now);
            tw.Close();
        }




        //METODOS INTERNOS


        /// <summary>
        /// Calcula el Hash MD5 de una cadena de caracteres
        /// </summary>
        /// <param name="entrada">Cadena de caracteres a la que se le va a calcular el hash</param>
        /// <returns></returns>
        private string Hash(string entrada)
        {

            entrada = añadeSal(entrada);
            //utiliza la cadena de entrada para calcular 
            //el hash MD5.
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] bytesEntrada = System.Text.Encoding.ASCII.GetBytes (entrada);
            byte[] bytesHasheados  = md5.ComputeHash (bytesEntrada);
 
            //convierte el arreglo de Bytes a una cadena Hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytesHasheados.Length; i++)
             {
                 sb.Append(bytesHasheados[i].ToString("X2"));
      
             }
             return sb.ToString();
       }

        /// <summary>
        /// Para evitar la ingenieria reversa de los Hashes se les añade "Sal" 
        /// La sal es una cadena de caracteres secreta que se le añade a los Passwords
        /// REF: http://es.wikipedia.org/wiki/Sal_(criptograf%C3%ADa)
        /// </summary>
        /// <param name="p">Cadena a la que se le añadira la Sal</param>
        /// <returns>Cadena original con la sal concatenada </returns>
        private string añadeSal(string p)
        {
            string temp = p + "FvN6Pbzh";
            return temp; 
        }


    
    }
}
