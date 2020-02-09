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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperAgenda
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        ContatoViwer contatoviwer;
        ContatoFiller contatofiller;
        List<Contato> Contatos;
        public MainWindow()
        {
            InitializeComponent();
            AtualizarContatos();
        }

        private void ContatoBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contatoviwer != null)contatoviwer.Close();
            if (ContatoBox.SelectedIndex < ContatoBox.Items.Count && ContatoBox.SelectedIndex >= 0)
            {
                contatoviwer = new ContatoViwer(Contato.ContatoCompleto(Contatos[ContatoBox.SelectedIndex].Id));
                contatoviwer.Show();
                contatoviwer.Top = this.Top;
                contatoviwer.Left = this.Left + this.Width;
            }
        }

        private void AdiconarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (contatofiller != null) contatofiller.Close();
            contatofiller = new ContatoFiller(this);
            contatofiller.Show();
            contatofiller.Top = this.Top;
            contatofiller.Left = this.Left + this.Width;
        }

        private void RemoverContato(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente remover este contato, está ação não poderá ser revertida.", "aviso", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Contato.RemoverContato(Contatos[ContatoBox.SelectedIndex].Id);
                AtualizarContatos();
            }
        }

        public void AtualizarContatos()
        {
            ProcurarBox.Text = "";
            ContatoBox.Items.Clear();
            Contatos = Contato.NomesContatos();
            if (Contatos.Count > 0) foreach (Contato Contato in Contatos) ContatoBox.Items.Add(Contato.Nome);
        }

        private void ProcurarBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ProcurarBox.Text != String.Empty)
            {
                ContatoBox.Items.Clear();
                Contatos = Contato.ProcurarContatos(ProcurarBox.Text);
                if (Contatos.Count > 0) foreach (Contato Contato in Contatos) ContatoBox.Items.Add(Contato.Nome);
            }
            else AtualizarContatos();
        }
    }
}
