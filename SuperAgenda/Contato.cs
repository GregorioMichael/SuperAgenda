using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace SuperAgenda
{
    public class Contato
    {
        public string Nome, TelRes, TelCom, Cel, Email, Endereco, Website, Facebook, LinkdIn, Nota;
        public Image Foto;
        public int Id;


        public static List<Contato> NomesContatos()
        {
            List<Contato> resultado = new List<Contato>();
            try
            {
                string canal = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + @System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + @"\SuperAgendaData.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(canal);
                connection.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT Id, Nome FROM Contatos ORDER BY Nome", connection);
                SqlDataReader rb = cmd.ExecuteReader();
                while (rb.Read())
                {
                    Contato cont = new Contato();

                    cont.Id = int.Parse(rb[0].ToString());
                    cont.Nome = rb[1].ToString();

                    resultado.Add(cont);
                }

                connection.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }

            return (resultado);
        }

        public static List<Contato> ProcurarContatos(string src)
        {
            List<Contato> resultado = new List<Contato>();
            try
            {
                string canal = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ @System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + @"\SuperAgendaData.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(canal);
                connection.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT Id, Nome FROM Contatos WHERE Nome LIKE'"+src+"%'ORDER BY Nome", connection);
                SqlDataReader rb = cmd.ExecuteReader();
                while (rb.Read())
                {
                    Contato cont = new Contato();

                    cont.Id = int.Parse(rb[0].ToString());
                    cont.Nome = rb[1].ToString();

                    resultado.Add(cont);
                }

                connection.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            return (resultado);
        }

        public static Contato ContatoCompleto(int id)
        {
            Contato contato = new Contato();
            List<Contato> resultado = new List<Contato>();
            try
            {
                string canal = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + @System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + @"\SuperAgendaData.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(canal);
                connection.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT Id, Nome, TelRes, TelCom, Celular, Email, Endereco, Website, Facebook, LinkedIn, Nota, Foto FROM Contatos WHERE Id = "+id, connection);
                SqlDataReader rb = cmd.ExecuteReader();
                while (rb.Read())
                {
                    contato.Id = int.Parse(rb[0].ToString());
                    contato.Nome = rb[1].ToString();
                    contato.TelRes = rb[2].ToString();
                    contato.TelCom = rb[3].ToString();
                    contato.Cel = rb[4].ToString();
                    contato.Email = rb[5].ToString();
                    contato.Endereco = rb[6].ToString();
                    contato.Website = rb[7].ToString();
                    contato.Facebook = rb[8].ToString();
                    contato.LinkdIn = rb[9].ToString();
                    contato.Nota = rb[10].ToString();
                    /*
                    string forto = rb[11].ToString();
                    if (forto != String.Empty)
                    {
                        byte[] image = new byte[forto.Length];
                        for(int i=0; i<forto.Length; i++) image[i] = (Byte)forto[i];
                        contato.Foto.Source = ByteToImage(image);
                    }
                    */
                }

                connection.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            return (contato);
        }

        public static bool RemoverContato(int id)
        {
            Contato contato = new Contato();
            List<Contato> resultado = new List<Contato>();
            try
            {
                string canal = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + @System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + @"\SuperAgendaData.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(canal);
                connection.Open();
                SqlCommand cmd = new SqlCommand(@"DELETE FROM Contatos WHERE Id='" + id + "' ", connection);
                SqlDataReader rb = cmd.ExecuteReader();
                connection.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return (false);
            }
            return (true);
        }

        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }

        public bool InserirContato()
        {
            if (ValidadorGeral())
            {
                try
                {
                    string canal = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + @System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + @"\SuperAgendaData.mdf;Integrated Security=True";
                    SqlConnection connection = new SqlConnection(canal);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO Contatos (Nome, TelRes, TelCom, Celular, Email, Endereco, Website, Facebook, LinkedIn, Nota, Foto) VALUES ('" + @Nome + "', '" + @TelRes + "', '" + @TelCom + "', '" + @Cel + "', '" + @Email + "', '" + @Endereco + "', '" + @Website + "', '" + @Facebook + "', '" + @LinkdIn + "', '" + @Nota + "', '" + @Foto + "') ", connection);
                    SqlDataReader rb = cmd.ExecuteReader();
                    connection.Close();
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                    return (false);
                }
                return (true);
            }
            else return (false);
        }

        public bool ValidadorGeral()
        {
            Regex regTel, regNome, regEmail;
            regTel = new Regex(@"^[0-9]");
            regNome = new Regex(@"^[a-zA-Z\s]");
            regEmail = new Regex(@"^[a-zA-Z0-9\._\-+]+@[a-zA-Z0-9]+\.[A-Za-z0-9]{2,}");

            bool isNome = regNome.IsMatch(Nome) && Nome != String.Empty;
            bool isCel = regTel.IsMatch(Cel) || Cel == String.Empty;
            bool isRes = regTel.IsMatch(TelRes) || TelRes == String.Empty;
            bool isCom = regTel.IsMatch(TelCom) || TelCom == String.Empty;
            bool isMail = regEmail.IsMatch(Email) || TelCom == String.Empty;

            if (isNome && isCel && isRes && isCom && isMail) return (true);
            else
            {
                string resposta="";
                if (!isNome) resposta = resposta + "nome invalido\n";
                if (!isCel) resposta = resposta + "Celular invalido\n";
                if (!isRes) resposta = resposta + "Telefone residencial invalido\n";
                if (!isCom) resposta = resposta + "Telefone comercial invalido\n";
                if (!isMail) resposta = resposta + "Email invalido\n";
                System.Windows.MessageBox.Show(resposta);
                return (false);
            }
        }
    }
}
