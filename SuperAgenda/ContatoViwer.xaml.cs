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
    /// Lógica interna para ContatoViwer.xaml
    /// </summary>
    public partial class ContatoViwer : Window
    {
        public ContatoViwer()
        {
            InitializeComponent();
        }
        public ContatoViwer(Contato Cont)
        {
            InitializeComponent();

            Title = Cont.Nome;

            NomeTxt.Text = Cont.Nome;
            TelComTxt.Text = Cont.TelCom;
            TelResTxt.Text = Cont.TelRes;
            CelTxt.Text = Cont.Cel;
            EndeTxt.Text = Cont.Endereco;
            EmailTxt.Text = Cont.Email;
            WebsiteTxt.Text = Cont.Website;
            FacebooTxt.Text = Cont.Facebook;
            LinkedInTxt.Text = Cont.LinkdIn;
            NotaTxt.Text = Cont.Nota;
            ContatoImg = Cont.Foto;
        }
    }
}
