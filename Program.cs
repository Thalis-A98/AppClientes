using System.Globalization;
using Repositorio;

namespace AppClientes;
class Program
{
    static void Main(string[] args)
    {
        var cultura = new CultureInfo("pt-BR");
        Thread.CurrentThread.CurrentUICulture = cultura;
        Thread.CurrentThread.CurrentUICulture = cultura;

        _clienteRepositorio.LerDadosClientes();

        while (true)
        {   
            Menu();
            Console.ReadKey();
        }
    }

    static ClienteRepositorio _clienteRepositorio = new ClienteRepositorio();

    static void Menu()
    {
        Console.Clear();

        System.Console.WriteLine("Cadastro de Clientes");
        System.Console.WriteLine("--------------------");
        System.Console.WriteLine("1 - Cadastrar Cliente");
        System.Console.WriteLine("2 - Exibir Clientes");
        System.Console.WriteLine("3 - Editar Clientes");
        System.Console.WriteLine("4 - Excluir Clientes");
        System.Console.WriteLine("5 - Sair");
        System.Console.WriteLine("--------------------");

        EscolherOpcao();
    }

    static void EscolherOpcao()
    {
        Console.Write("Escolha uma opção: ");
        var opcao = Console.ReadLine();

        switch (int.Parse(opcao))
        {
            case 1:
            _clienteRepositorio.CadastrarCliente();
            Menu();
            break;

            case 2:
            _clienteRepositorio.ExibirClientes();
            Menu();
            break;

            case 3:
            _clienteRepositorio.EditarCliente();
            Menu();
            break;

            case 4:
            _clienteRepositorio.ExcluirCliente();
            Menu();
            break;

            case 5:
            _clienteRepositorio.GravarDadosCLiente();
            Environment.Exit(0);
            break;

            default:
            Console.Clear();
            System.Console.WriteLine("Opção Inválida!");
            break;
        }
    }
}
