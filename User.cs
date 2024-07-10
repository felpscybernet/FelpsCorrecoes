#region Library
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text.Encodings;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using project;
using project.IntegracaoCep;
#endregion

namespace CadastroPessoa
{
    public class Users
    {
        #region Propriedades
        private string nome = string.Empty;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private int idade;
        public int Idade
        {
            get { return idade; }
            set { idade = value; }
        }

        private string cpf = string.Empty;
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public string cep { get; set; }
        public string complemento { get; set; }
        public string localidade { get; set; }
        public string bairro { get; set; }
        public string Uf { get; set; }
        public Endereco Endereco { get; set; }

        #region gender
        private string sexo = string.Empty;
        public string Sexo
        {
            get { return sexo; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    switch (value.ToUpper())
                    {
                        case "M":
                        sexo = "Masculino";
                        break;
                        case "F":
                        sexo = "Feminino";
                        break;
                        default:
                        sexo = "Formato Inválido";
                        break;
                    }
                }
            }
        }
        #endregion

        #region dateOfBirth
        private string dataDeNascimento = string.Empty;
        public string DataDeNascimento
        {
            get { return dataDeNascimento; }
            set { dataDeNascimento = value; }
        }
        #endregion

        #region fone
        private string telefone = string.Empty;
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        #endregion

        #endregion

        #region Construtores
        public Users()
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
            Sexo = "";
            Telefone = "";
            DataDeNascimento = "";
        }
        #endregion

        #region Metodos
        public void RemoverMascaraCpf()
        {
            if (!string.IsNullOrEmpty(Cpf))
            {
                cpf = Cpf.Replace(".", "").Replace("-", "");
            }
        }

        public bool validacaoCpfUsuario()
        {
            RemoverMascaraCpf();
            if (!string.IsNullOrEmpty(Cpf) && Cpf.Length == 11)
            {
                cpf = Cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                return true;
            }
            return false;
        }

        public bool validarIdadeUsuario()
        {
            if (Idade >= 18)
            {
                idade = Idade;
                return true;
            }
            return false;
        }

        public void dataNascimentoCadastro()
        {

            if (!string.IsNullOrEmpty(DataDeNascimento) && DataDeNascimento.Length == 8)
            {
                dataDeNascimento = DataDeNascimento.Insert(2, "/").Insert(5, "/");
                string[] separarAno = DataDeNascimento.Split('/');
                if (separarAno.Length >= 3 && int.TryParse(separarAno[2], out int anoNascimentoUsuario) && Idade <= 0)
                {
                    Idade = DateTime.Now.Year - anoNascimentoUsuario;
                }
            }
            else if (string.IsNullOrEmpty(DataDeNascimento))
            {
                /* Adicionar tratamento na mensagem de erro pra quando o usuário optar por não informar e quando informar 1 ou mais valores */
                Console.WriteLine($"Data de Nascimento não informada. Para prosseguir com o cadastro, informe a Idade do usuário.");
                Console.Write("Informe a Idade do usuário: ");
                Idade = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                dataDeNascimento = null;
            }
        }

        public void tratarCepCadastro()
        {
            if (!string.IsNullOrEmpty(cep) && cep.Length == 8)
            {
                cep = cep.Insert(6, "-");
            }
        }

        public void telefoneCadastro()
        {
            if (!string.IsNullOrEmpty(Telefone))
            {
                if (Telefone.Length == 9 && int.TryParse(Telefone, out int parsedTelefone))
                {
                    telefone = parsedTelefone.ToString();
                }
                else
                {
                    telefone = $"Telefone Inválido. Revalidar telefone '{Telefone}' informado.";
                }
            }
            else if (Telefone == string.Empty)
            {
                telefone = $"Usuário optou por não cadastrar Telefone";
            }
        }


        /* Test
           foreach (var usuariosCdastrados in listaUsuariosCadastrados)
             {
                 var jsonCadastroUsuario = JsonConvert.SerializeObject(cadastro);
                 var directoryJson = @"C:\\Users\\";
                 var caminhoJson = Path.Combine(jsonCadastroUsuario, "listUsuario.json");
                 File.WriteAllText(directoryJson, jsonCadastroUsuario);
             }
           */

        /* Método ExibirDados
        public void ExibirDados()
        {
            Console.WriteLine("Login Usuário: " + Nome);
            Console.WriteLine("CPF Usuário: " + cpf);
            Console.WriteLine("Idade Usuário: " + Idade);

            if (!string.IsNullOrEmpty(DataDeNascimento))
            {
                Console.WriteLine("Data de Nascimento: " + DataDeNascimento);
            }
            else
            {
                Console.WriteLine($"Data de Nascimento: O usuário optou por informar apenas a 'Idade'");
            }

            //Console.WriteLine("Sexo: " + Sexo);
            //Console.WriteLine("Telefone: " + Telefone);
        }
        */

        #endregion

    }
}
