using CadastroPessoa;
using project.IntegracaoCep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace project
{
    public class UsuarioLogin
    {
        public void TelaDeLogin()
        {
            Console.WriteLine("Bem vindo à Tela de Login\n");
            Console.WriteLine("\nDados Obrigátorios: Idade Ou Data de Nacismento/CPF\n\n");
        }

        public async Task CadastroLogin()
        {
            List<Users> listaCadastros = new List<Users>();

            string seguirCadastrosUsuarios = "S";

            //Adicionar cadastro de produtos por usuário, usuário poderar optar por produtos ex: (Tenis, Blusa, calça, etc...)
            //Verificar possibilidade de implementar funcionalidade de cadastro de produtos por usuário.

            //Adicionar busca CEP via API

            // verificação caso o S for um valor nulo aguardar o valor correto, em andamento..
            while (!string.IsNullOrEmpty(seguirCadastrosUsuarios) && seguirCadastrosUsuarios.ToUpper() == "S")
            {
                Users cadastros = new Users();
                viaCepApi resultadoCep = new viaCepApi();

                Console.Write("\nNome do usuário: ");
                cadastros.Nome = Console.ReadLine();

                Console.Write("\nCPF do usuário: ");
                cadastros.Cpf = Console.ReadLine();

                Console.Write("\nData de nascimento do usuário: ");
                cadastros.DataDeNascimento = Console.ReadLine();
                cadastros.dataNascimentoCadastro();

                /* UsingCase
                if (!string.IsNullOrEmpty(cadastros.DataDeNascimento))
                {
                    string[] separarAno = cadastros.DataDeNascimento.Split('/');
                    if (separarAno.Length >= 3 && int.TryParse(separarAno[2], out int anoNascimentoUsuario) && cadastros.Idade <= 0)
                    {
                        cadastros.Idade = DateTime.Now.Year - anoNascimentoUsuario;
                    }
                }
                else if (string.IsNullOrEmpty(cadastros.DataDeNascimento))
                {
                    Adicionar tratamento na mensagem de erro pra quando o usuário optar por não informar e quando informar 1 ou mais valores 
                    Console.WriteLine($"Data de Nascimento não informada. Para prosseguir com o cadastro, informe a Idade do usuário.");
                    Console.Write("Informe a Idade do usuário: ");
                    cadastros.Idade = Convert.ToInt32(Console.ReadLine());
                }

                Console.Write("\nInforme o CEP: ");
                cadastros.cep = Console.ReadLine();
                cadastros.Endereco = await resultadoCep.BuscarCepUsuario(cadastros.cep);
                */

                listaCadastros.Add(cadastros);

                Console.Write("\nDeseja cadastrar outros usuários? (S/N): ");
                seguirCadastrosUsuarios = Console.ReadLine();
            }

            ExibirDadosUsuariosCadastrados(listaCadastros);

        }

        public void ExibirDadosUsuariosCadastrados(List<Users> listaCadastros)
        {
            List<Users> usuariosValidos = new List<Users>();
            List<Users> usuariosInvalidos = new List<Users>();

            Console.WriteLine($"\nDados do Usuários\n");

            foreach (var user in listaCadastros)
            {
                // user.RemoverMascaraCpf();
                // Adicionar mensagem do por que não foi cadastrado CPF ou Idade.
                if (user.validacaoCpfUsuario() && user.validarIdadeUsuario())
                {
                    usuariosValidos.Add(user);
                }
                else
                {
                    usuariosInvalidos.Add(user);
                }
            }

            if (usuariosValidos.Count > 0)
            {
                Console.WriteLine("Usuários cadastrados");
                foreach (var user in usuariosValidos)
                {
                    Console.WriteLine($"\nNome: {user.Nome}");
                    Console.WriteLine($"CPF: {user.Cpf}");
                    Console.WriteLine($"Data de Nascimento: {user.DataDeNascimento}"); // Add verificação caso o usuario informe apenas a idade não apresentar a data de nascimento vazia.
                    Console.WriteLine($"Idade: {user.Idade}");

                    //user.tratarCepCadastro();
                    //Console.WriteLine("\n\nEndereço encontrado:");
                    //Console.WriteLine($"CEP: {user.cep}");
                    //Console.WriteLine($"Complemento: {user.complemento}");
                    //Console.WriteLine($"Bairro: {user.bairro}");
                    //Console.WriteLine($"Cidade: {user.localidade}");
                    //Console.WriteLine($"UF: {user.Uf}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum Usuário cadastrado");
            }

            if (usuariosInvalidos.Count > 0)
            {
                Console.WriteLine("\nUsuários não cadastrados");
                foreach (var user in usuariosInvalidos)
                {
                    Console.WriteLine($"\nNome: {user.Nome}");
                    if (user.Cpf.Length < 11 || user.Idade < 18)
                    {
                        Console.WriteLine("CPF: Não informado ou Incorreto.");
                    }
                    else
                    {
                        Console.WriteLine($"CPF: {user.Cpf}");
                    }
                    Console.WriteLine($"Data de Nascimento: {user.DataDeNascimento}");
                    Console.WriteLine($"Idade: {user.Idade}");
                }
            }
            else
            {
                Console.WriteLine("\nTodos Usuários Foram cadastrados corretamente.");
            }

            // Verificar se o cadastro foi concluído, caso tenha sido apresentar os dados do usuários e perguntar se o adm deseja remover algum dos usuários.
            // criar validação na lista que não permite o usuario cadastrar cpf igual para que seja mais dinamico os cadastros.
            // Criar validacao por ID, que caso tenha mais de 1 pedro ele não exclui os demais

            foreach (var user in usuariosValidos)
            {
                string removerUsuariosListaCadastrados = "S";
                Console.Write("\nDeseja remover algum usuário? ");
                removerUsuariosListaCadastrados = Console.ReadLine();

                //Erro loop, ele sempre valida que existe usuário e remove todos. Criar tratamento para que seja possivel remover so usuários cadastrados que foram informados.
                while (!string.IsNullOrEmpty(removerUsuariosListaCadastrados) && removerUsuariosListaCadastrados == "S".ToUpper())
                {
                    if (usuariosValidos != null)
                    {
                        Console.Write("\nQual Usuário deseja remover do cadastro? ");
                        user.Nome = Console.ReadLine();
                        Users usuarioRemover = usuariosValidos.FirstOrDefault(u => u.Nome.Equals(user.Nome, StringComparison.OrdinalIgnoreCase));

                        if (usuarioRemover != null)
                        {
                            usuariosValidos.Remove(usuarioRemover);
                            Console.WriteLine($"\nUsuário {user.Nome} Removido!!\n");

                            Console.Write("Deseja remover algum usuário? ");
                            removerUsuariosListaCadastrados = Console.ReadLine();
                        }
                    }
                }
                break;
            }
        }

        public void removerCadastroUsuario(List<Users> remover)
        {
        
            ExibirDadosUsuariosCadastrados(remover);
        }

        void ExibirErroCadastrarUsuario(string mensagemErro)
        {
            Console.WriteLine($"\n{mensagemErro}");
        }
    }
}
