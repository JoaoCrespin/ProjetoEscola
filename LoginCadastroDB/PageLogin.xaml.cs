﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

namespace LoginCadastroDB
{
    /// <summary>
    /// Interação lógica para PageLogin.xam
    /// </summary>
    public partial class PageLogin : Page
    {
        private ConexaoBD _conexao;
        //private MainWindow _mainWindow = new MainWindow();
        public PageLogin()
        {
            InitializeComponent();
            _conexao = new ConexaoBD();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(areaLogin.Text) || string.IsNullOrWhiteSpace(areaSenha.Password))
                {
                    MessageBox.Show("Preencha os campos vazios!");
                }
                else
                {
                    Usuario user = new Usuario(_conexao);
                    bool sucesso = user.MetodoLogin(areaLogin.Text, areaSenha.Password);
                    if (sucesso)
                    {
                        MessageBox.Show("Login bem sucedido!");
                    }
                    else
                    {
                        MessageBox.Show("Login ou senha incorretos!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void areaSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(areaSenha.Password))
            {
                labelSenha.Visibility = Visibility.Visible;
            }
            else
            {
                labelSenha.Visibility = Visibility.Collapsed;
            }
        }

        private void pagCadastro(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageCadastro());

        }

        
    }
}

