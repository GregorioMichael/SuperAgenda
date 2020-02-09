using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SuperAgenda
{
    /// <summary>
    /// Lógica interna para ContatoFiller.xaml
    /// </summary>
    public partial class ContatoFiller : Window
    {
        MainWindow Main;
        public ContatoFiller(MainWindow wind)
        {
            InitializeComponent();
            Main = wind;
        }

        private void SalvarBtn_Click(object sender, RoutedEventArgs e)
        {
            Contato contato = new Contato();
            contato.Nome = NomeBox.Text;
            contato.TelRes = TelResBox.Text;
            contato.TelCom = TelComBox.Text;
            contato.Cel = CelBox.Text;
            contato.Email = EmailBox.Text;
            contato.Website = WebBox.Text;
            contato.Facebook = FaceBox.Text;
            contato.LinkdIn = LinkedInBox.Text;
            contato.Nota = NotaBox.Text;
            contato.Foto = FotoImg;


            if (contato.InserirContato())
            {
                Main.AtualizarContatos();
                this.Close();
            }
        }
    }
}
