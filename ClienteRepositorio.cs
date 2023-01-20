using Cadastro;

namespace Repositorio
{
    public class ClienteRepositorio
    {
        public List<Cliente> clientes = new List<Cliente>();

        public void GravarDadosCLiente()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(clientes);
            File.WriteAllText("clientes.txt", json);
        }
        public void LerDadosClientes()
        {
            if(File.Exists("clientes.txt"))
            {
                var dados = File.ReadAllText("clientes.txt");
                var clientesArquivo = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(dados);

                clientes.AddRange(clientesArquivo);
            }

        }

        public void ImprimirCliente(Cliente cliente)
        {
            System.Console.WriteLine("ID.............:" + cliente.Id);
            System.Console.WriteLine("Nome...........:" + cliente.Nome);
            System.Console.WriteLine("Desconto.......:" + cliente.Desconto.ToString("0.00"));
            System.Console.WriteLine("Data Nascimento:" + cliente.DataNascimento);
            System.Console.WriteLine("Data Cadastro..:" + cliente.CadastradoEm);
            System.Console.WriteLine("-----------------------------------");
        }

        public void ExibirClientes()
        {
            Console.Clear();

            foreach (var cliente in clientes)
            {
                ImprimirCliente(cliente);
            }

            Console.ReadKey();
        }

        public void CadastrarCliente()
        {
            Console.Clear();

            Console.Write("Nome do Cliente: ");
            var nome = Console.ReadLine();
            Console.Write(Environment.NewLine);

            Console.Write("Data de Nascimento: ");
            var dataNascimento = DateOnly.Parse(Console.ReadLine());
            Console.Write(Environment.NewLine);

            Console.Write("Desconto: ");
            var desconto = decimal.Parse(Console.ReadLine());
            Console.Write(Environment.NewLine);

            var cliente = new Cliente();
            cliente.Id = clientes.Count + 1;
            cliente.Nome = nome;
            cliente.DataNascimento = dataNascimento;
            cliente.Desconto = desconto;
            cliente.CadastradoEm = DateTime.Now;

            clientes.Add(cliente);

            System.Console.WriteLine("Cliente cadastrado com Sucesso! [Enter]");
            ImprimirCliente(cliente);
            Console.ReadKey();

        }

        public void EditarCliente()
        {
            Console.Clear();

            Console.Write("Informe o código do cliente:");
            var codigo = Console.ReadLine();

            var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

            if (cliente == null)
            {
                System.Console.WriteLine("Cliente não encontrado! [Enter]");
                Console.ReadKey();
                return;
            }
            ImprimirCliente(cliente);

            Console.Write("Nome do Cliente: ");
            var nome = Console.ReadLine();
            Console.Write(Environment.NewLine);

            Console.Write("Data de Nascimento: ");
            var dataNascimento = DateOnly.Parse(Console.ReadLine());
            Console.Write(Environment.NewLine);

            Console.Write("Desconto: ");
            var desconto = decimal.Parse(Console.ReadLine());
            Console.Write(Environment.NewLine);

            cliente.Nome = nome;
            cliente.DataNascimento = dataNascimento;
            cliente.Desconto = desconto;
            cliente.CadastradoEm = DateTime.Now;

            System.Console.WriteLine("Cliente alterado com Sucesso! [Enter]");
            ImprimirCliente(cliente);
            Console.ReadKey();
        }

        public void ExcluirCliente()
        {
            Console.Clear();

            Console.Write("Informe o código do cliente:");
            var codigo = Console.ReadLine();

            var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

            if (cliente == null)
            {
                System.Console.WriteLine("Cliente não encontrado! [Enter]");
                Console.ReadKey();
                return;
            }
            
            ImprimirCliente(cliente);

            clientes.Remove(cliente);

            System.Console.WriteLine("Cliente removido com Sucesso! [Enter]");
            Console.ReadKey();
        }

    }

}