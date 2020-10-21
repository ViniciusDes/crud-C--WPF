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
            using (dadosEntities db = new dadosEntities())
            {
                var clientes = db.Cliente.ToList();
                dtGridLista.ItemsSource = clientes;
            }
        }

        private void dtGridLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Object _cliente = dtGridLista.SelectedValue;
            var id = _cliente.GetType().GetProperty("ID").GetValue(_cliente, null );
            var nome = _cliente.GetType().GetProperty("Nome").GetValue(_cliente, null );
            var CPF = _cliente.GetType().GetProperty("CPF").GetValue(_cliente, null );
            var Telefone = _cliente.GetType().GetProperty("Telefone").GetValue(_cliente, null );
            var CEP = _cliente.GetType().GetProperty("CEP").GetValue(_cliente, null );
            var Cidade = _cliente.GetType().GetProperty("Cidade").GetValue(_cliente, null );
            var Estado = _cliente.GetType().GetProperty("Estado").GetValue(_cliente, null );
            var Bairro = _cliente.GetType().GetProperty("Bairro").GetValue(_cliente, null );
            var Logradouro = _cliente.GetType().GetProperty("Logradouro").GetValue(_cliente, null );
            var Complemento = _cliente.GetType().GetProperty("Complemento").GetValue(_cliente, null );
            var Numero = _cliente.GetType().GetProperty("Numero").GetValue(_cliente, null );
        
            

            var viewCadClientes = new CadCliente();
                viewCadClientes.txtId.Text = id.ToString();
                viewCadClientes.txtName.Text = nome.ToString();
                viewCadClientes.txtCPF.Text = CPF.ToString();
                viewCadClientes.txtTelefone.Text = Telefone.ToString();
                viewCadClientes.txtCep.Text = CEP.ToString();
                viewCadClientes.txtCidade.Text = Cidade.ToString();
                viewCadClientes.txtEstado.Text = Estado.ToString();
                viewCadClientes.txtBairro.Text = Bairro.ToString();
                viewCadClientes.txtLogradouro.Text = Logradouro.ToString();
                viewCadClientes.txtComplemento.Text = Complemento.ToString();
                viewCadClientes.txtNumero.Text = Numero.ToString();

            viewCadClientes.Show();
            viewCadClientes.btnDeletar.IsEnabled = true;
            viewCadClientes.btnNovoCliente.IsEnabled = true;
            this.Close();
        }
    }
}
