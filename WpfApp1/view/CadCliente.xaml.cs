using System;
using System.Collections.Generic;
using System.Text;
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
    /// Lógica interna para CadCliente.xaml
    /// </summary>
    public partial class CadCliente : Window
    {
        public CadCliente()
        {
            InitializeComponent();
        }
        public void CarregarInput()
        {
            var contato = new Contato();
            txtName.Text = contato.Nome;
            txtCPF.Text = contato.CPF;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(model.dadosEntities4 db = new dadosEntities4())
            {
                var contato = new Contato
                {
                    Nome = txtName.Text,
                    CPF = txtCPF.Text,
                    Telefone = txtTelefone.Text,
                    CEP = txtCep.Text,
                    Cidade = txtCidade.Text,
                    Estado = txtEstado.Text,
                    Bairro = txtBairro.Text,
                    Logradouro = txtLogradouro.Text,
                    Complemento = txtComplemento.Text,
                    Numero = txtNumero.Text,
                };
                
                try
                {
                    db.Contato.Add(contato);
                    db.SaveChanges();
                    MessageBox.Show("Contato cadastrado com sucesso");
                }
                catch
                {
                    MessageBox.Show("Erro de cadastro, verifique");

                };
            };
          
        }

        private void txtTelefone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtName_TouchUp(object sender, TouchEventArgs e)
        {
            txtName.Text = "";
        }

        private void txtName_TouchLeave(object sender, TouchEventArgs e)
        {
            txtName.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Context db = new Context();
           
            //IEnumerable<Contato> lista = from p in db.Contato select p;

            //grpProdutos.Text = "Produtos: " + lista.Count();
            //gdvProdutos.DataSource = lista.ToList();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var viewListarClientes = new ListarCliente();
            viewListarClientes.Show();
        }
    }
}
