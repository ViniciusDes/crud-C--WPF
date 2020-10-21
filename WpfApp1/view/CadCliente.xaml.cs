using System;
using System.Collections.Generic;
using System.Linq;
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

            btnDeletar.IsEnabled = false;
            btnNovoCliente.IsEnabled = false;
        }
        private void CarregarInput()
        {
            var cliente = new Cliente();
            txtName.Text = cliente.Nome;
            txtCPF.Text = cliente.CPF;
        }

        private void deletarCliente(int id)
        {
            using (dadosEntities db = new dadosEntities())
            {
                try
                {
                    var clientes = db.Cliente;
                    var cliente = clientes.First(p => p.ID == id);
                    clientes.Remove(cliente);

                    db.SaveChanges();

                    MessageBox.Show("Sucesso ao deletar cliente");
                }
                catch
                {
                    MessageBox.Show("Erro ao deletar cliente");
                }
               

            }
        }

        private void LimparInputs()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtCPF.Text = "";
            txtTelefone.Text = "";
            txtCep.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            txtBairro.Text = "";
            txtLogradouro.Text = "";
            txtComplemento.Text = "";
            txtNumero.Text = "";
        }
       
        public void atualizaClienteCadastrado(int id)
        {
            using (dadosEntities db = new dadosEntities())
            {
                try
                {
                    var clientes = db.Cliente;
                    var cliente = clientes.First(p => p.ID == id);
                    cliente.Nome = txtName.Text;
                    cliente.CPF = txtCPF.Text;
                    cliente.Telefone = txtTelefone.Text;
                    cliente.CEP = txtCep.Text;
                    cliente.Cidade = txtCidade.Text;
                    cliente.Estado = txtEstado.Text;
                    cliente.Bairro = txtBairro.Text;
                    cliente.Logradouro = txtLogradouro.Text;
                    cliente.Complemento = txtComplemento.Text;
                    cliente.Numero = txtNumero.Text;

                    db.SaveChanges();

                    MessageBox.Show("Sucesso ao editar cliente");
                }
                catch
                {
                    MessageBox.Show("Erro ao editar cliente");
                }
                finally
                {
                }
               
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                atualizaClienteCadastrado(Int32.Parse(txtId.Text));

            }
            else
            {
                using (model.dadosEntities db = new dadosEntities())
                {
                    var cliente = new Cliente
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
                        db.Cliente.Add(cliente);
                        db.SaveChanges();
                        MessageBox.Show("Cliente cadastrado com sucesso");
                    }
                    catch
                    {
                        MessageBox.Show("Erro de cadastro, verifique");

                    };
                }
            };
            LimparInputs();
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
           

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var viewListarClientes = new ListarCliente();
            viewListarClientes.Show();
            this.Close();

        }

        private void txtId_Initialized(object sender, EventArgs e)
        {
            txtId.IsEnabled = false;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            deletarCliente(Int32.Parse(txtId.Text));
            LimparInputs();
        }

        private void Button_StylusLeave(object sender, StylusEventArgs e)
        {
            
        }

        private void btnNovoCliente_Click(object sender, RoutedEventArgs e)
        {
            LimparInputs();
            txtName.Focus();
        }
    }
}
