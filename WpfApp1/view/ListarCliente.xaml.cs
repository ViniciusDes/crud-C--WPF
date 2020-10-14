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
using CrudWPF.model;
namespace CrudWPF.view
{
    /// <summary>
    /// Lógica interna para ListarCliente.xaml
    /// </summary>
    public partial class ListarCliente : Window
    {
        public ListarCliente()
        {
            InitializeComponent();
            LoadingClientes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
        public void LoadingClientes()
        {
            using (dadosEntities4 db = new dadosEntities4())
            {
                var contatos = db.Contato.ToList();
                dtGridLista.ItemsSource = contatos;
            }
        }

        private void dtGridLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var contato = new Contato();

            var a = dtGridLista.SelectedValue;




            var viewCadClientes = new CadCliente();
            viewCadClientes.Show();
        }
    }
}
