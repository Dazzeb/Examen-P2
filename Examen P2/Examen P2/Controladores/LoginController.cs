using Examen_P2.Modelos.DAO;
using Examen_P2.Modelos.Entidades;
using Examen_P2.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_P2.Controladores
{
    public class LoginController
    {
        LoginView Vista;

        public LoginController(LoginView view)
        {
            Vista = view;
            Vista.button1.Click += new EventHandler(ValidarUsuario);
        }

        private void ValidarUsuario(object serder, EventArgs e)
        {
            bool esValido = false;
            UsuarioDAO userDao = new UsuarioDAO();
            Usuario user = new Usuario();
            user.NUsuario = Vista.textBox1.Text;
            user.Clave = Vista.textBox2.Text;
            esValido = userDao.ValidarUsuario(user);
            if (esValido)
            {
                MessageBox.Show("Usuario Valido");
                MenuView menu = new MenuView();
                Vista.Hide();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Usuario Incorrecto");
               
            }

         /* public static string EncriptarClave(string str)
            {

                string cadena = str + "Clave";
                SHA256 sha256 = SHA256Managed.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = sha256.ComputeHash(encoding.GetBytes(cadena));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[1]);
                return sb.ToString();

             }   No me deja utilizar el public static string, ya actualice y aun asi no me deja trabajar */
        

        }
    }
}
