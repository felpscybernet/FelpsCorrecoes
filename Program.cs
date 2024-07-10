#region Library
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text.Encodings;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using project;
#endregion

namespace CadastroPessoa
{
    class Program
    {
        static async Task Main(string[] args)
        {
            UsuarioLogin dadosTelaPrincipal = new UsuarioLogin();
            dadosTelaPrincipal.TelaDeLogin();
            await dadosTelaPrincipal.CadastroLogin();


            #region UsingCase
            //dadosTelaPrincipal.TelaDeLogin();
            //Console.Write("Nome do usuário: ");
            //cadastro.Nome = Console.ReadLine();

            //Console.Write("\nCPF do usuário: ");
            //cadastro.Cpf = Console.ReadLine();
            //cadastro.RemoverMascaraCpf();

            //Console.Write("\nData de nascimento do usuário: ");
            //cadastro.DataDeNascimento = Console.ReadLine();

            // Criar verificação da Data de Nascimento, caso esteja preenchida utilizando DateTime.Now.ToShortDateString() */

            //cadastro.dataNascimentoCadastro();
            //if (!string.IsNullOrEmpty(cadastro.DataDeNascimento))
            //{
            //    string[] separarAno = cadastro.DataDeNascimento.Split('/');
            //    if (separarAno.Length >= 3 && int.TryParse(separarAno[2], out int anoNascimentoUsuario) && cadastro.Idade <= 0)
            //    {
            //        cadastro.Idade = DateTime.Now.Year - anoNascimentoUsuario;
            //    }
            //}
            //else if (string.IsNullOrEmpty(cadastro.DataDeNascimento))
            //{
            //    /* Adicionar tratamento na mensagem de erro pra quando o usuário optar por não informar e quando informar 1 ou mais valores */
            //    ExibirErroCadastrarUsuario(mensagemErro: $"Data de Nascimento não informada. Para prosseguir com o cadastro, informe a Idade do usuário.");
            //    Console.Write("Informe a Idade do usuário: ");
            //    cadastro.Idade = Convert.ToInt32(Console.ReadLine());
            //}

            //Console.WriteLine($"\n#Dados de Cadastro#\n");

            //bool idadeVerificar = cadastro.Idade >= 18;
            //if (cadastro.validacaoCpfUsuario())
            //{
            //    if (idadeVerificar)
            //    {
            //        ExibirMensagensPadrao(mensagemPadrao: $"{cadastro.Nome}");
            //        cadastro.ExibirDados();
            //    }
            //    else
            //    {
            //        if (!idadeVerificar)
            //        {
            //            ExibirErroCadastrarUsuario(mensagemErro: $"\nNão foi possível cadastrar usuário: {cadastro.Nome}\n");
            //            cadastro.ExibirDados();

            //            ExibirErroCadastrarUsuario(mensagemErro: $"Idade informada não permitida {cadastro.Idade}");
            //        }
            //    }
            //}
            //else if (cadastro.validacaoCpfUsuario() == false)
            //{
            //    ExibirErroCadastrarUsuario(mensagemErro: $"\nNão foi possível cadastrar usuário: {cadastro.Nome}\n");
            //    cadastro.ExibirDados();

            //    ExibirErroCadastrarUsuario(mensagemErro: $"CPF incorreto, por favor revalidar.");

            //    if (!idadeVerificar)
            //    {
            //        ExibirErroCadastrarUsuario(mensagemErro: $"\nIdade informada não permitida: {cadastro.Idade}");
            //    }
            //}
            //#region Methods Mensagens Tratadas
            //void ExibirErroCadastrarUsuario(string mensagemErro)
            //{
            //    Console.WriteLine($"\n{mensagemErro}");
            //}

            //void ExibirMensagensPadrao(string mensagemPadrao)
            //{
            //    Console.WriteLine($"\nUsuários cadastrados {mensagemPadrao}");
            //}
            //#endregion
            #endregion

            Console.ReadLine();
        }
    }
}