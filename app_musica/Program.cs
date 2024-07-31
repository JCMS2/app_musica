using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;


string boasvindas = "Bem-Vindo ao app de musica";

//List<string> listaDasBandas = new List<string> {"30 PRA UM","Turma do pagode"};

Dictionary<string,List<int>> MediaBanda = new Dictionary<string,List<int>>();
MediaBanda.Add("30 pra um", new List<int> {9,10,8 });
MediaBanda.Add("turma do pagode", new List<int> {10 });


void  exibirBoasVindas()
{
    Console.WriteLine(@"
░█████╗░██████╗░██████╗░  ███╗░░░███╗██╗░░░██╗░██████╗██╗░█████╗░░█████╗░
██╔══██╗██╔══██╗██╔══██╗  ████╗░████║██║░░░██║██╔════╝██║██╔══██╗██╔══██╗
███████║██████╔╝██████╔╝  ██╔████╔██║██║░░░██║╚█████╗░██║██║░░╚═╝███████║
██╔══██║██╔═══╝░██╔═══╝░  ██║╚██╔╝██║██║░░░██║░╚═══██╗██║██║░░██╗██╔══██║
██║░░██║██║░░░░░██║░░░░░  ██║░╚═╝░██║╚██████╔╝██████╔╝██║╚█████╔╝██║░░██║
╚═╝░░╚═╝╚═╝░░░░░╚═╝░░░░░  ╚═╝░░░░░╚═╝░╚═════╝░╚═════╝░╚═╝░╚════╝░╚═╝░░╚═╝
");
    Console.WriteLine(boasvindas);
}

void exibirOpçoes()
{

    Console.WriteLine("\ndigite 1 para registrar uma banda");
    Console.WriteLine("digite 2 para mostrar todas as bandas");
    Console.WriteLine("digite 3 para avaliar ums bandas");
    Console.WriteLine("digite 4 para exibir a media de uma banda bandas");
    Console.WriteLine("digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opçaoescolhida = Console.ReadLine()!;
    int opçaoescolhidaint = int.Parse(opçaoescolhida);
    switch (opçaoescolhidaint)
    {
        case 1: registrarbanda();
            break;
        case 2 :exibirBandas();
            break;
        case 3 :avaliaçaototal();
            break;
        case 4 : MediaDabanda();
            break;
        case -1: Console.WriteLine("fechando aplicaçao");
            break;
        default: Console.WriteLine("opçao invalida");
            Console.Clear();
            Console.Write("Essa opção não é válida");
            Thread.Sleep(2000);
            Console.WriteLine("\nPrecione qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            exibir();
            exibirOpçoes();
            break;
    }
}

void registrarbanda()
{
    Console.Clear();
    titulo("Registrar uma banda");
    Console.Write("\nDigite o nome da banda que deseja registrar!");
    string nomedabanda = Console.ReadLine()!;
    MediaBanda.Add(nomedabanda,new List<int>());
    Console.WriteLine($"\na Banda {nomedabanda} foi registrada com sucesso" );
    Thread.Sleep(2000);
    Console.WriteLine("Clique em entrer para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    exibir();
}

void exibirBandas()
{
    Console.Clear();
    titulo("Mostrar as bandas");
    Thread.Sleep(2000);
    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
    //Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}

    foreach (string banda in MediaBanda.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nClique em entrer para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    exibir();


}

/*void MediaDabanda()
{
    Console.Clear();
    titulo("Exibir media uma banda");
    foreach (var banda in MediaBanda)
    {
        Console.WriteLine($"Banda: {banda.Key}");
    }
    
    Console.Write("\nDigite o nome da banda que deseja Ver media!");
    string nomedabanda = Console.ReadLine()!;
    if (MediaBanda.ContainsKey(nomedabanda)) 
    {
        List<int> notasDaBanda=MediaBanda[nomedabanda];
        Console.WriteLine($"A media da banda {nomedabanda} é {notasDaBanda.Average()}");
        Console.WriteLine("\nClique em entrer para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        exibir();
    }
    else
    {
        Console.WriteLine("essa banda nao existe tente novamente! ");
        Console.WriteLine("\nClique em entrer para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        exibir();
    }
}*/

 void MediaDabanda()
{
    Console.Clear();
    foreach (var banda in MediaBanda)
    {
        Console.WriteLine($"Banda: {banda.Key}");
        Console.Write("Notas: ");
        float soma = 0;
    foreach(int nota in banda.Value)
        {
            Console.Write($"{nota}, ");
            soma += nota;
        }
        
        Console.WriteLine();
        int quantidadedenotas = banda.Value.Count;
        float media=(quantidadedenotas>0)? soma/quantidadedenotas:0;
        Console.WriteLine($"A  media da Banda é {media}");
    }
    Console.WriteLine("\nClique em entrer para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    exibir();
}


void avaliaçaototal()
{
    Console.Clear();
    titulo("Avaliaçao Banda");
    foreach (var banda in MediaBanda)
    {
        Console.WriteLine($"Banda: {banda.Key}");
    }

    Console.Write("digite a banda que voce quer avaliar! ");
    string nomedabanda = Console.ReadLine()!;
    if (MediaBanda.ContainsKey(nomedabanda))
    {
        Console.WriteLine("\nMe diga a nota da banda");
        int nota = int.Parse(Console.ReadLine()!);
        MediaBanda[nomedabanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi regristrada com sucesso para a banda {nomedabanda}");
        Thread.Sleep(1000);
        Console.WriteLine("precione entrer para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        exibir();
        
    }
    else {
        Console.WriteLine($"\nA banda {nomedabanda} nao foi encontrada");
        Console.WriteLine("digite uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        exibir();
    }
}

void titulo(string titulo)
{
    int quantidadeDeLetras= titulo.Length;
    string AS= string.Empty.PadLeft(quantidadeDeLetras,'-');
    Console.WriteLine(AS);
    Console.WriteLine(titulo);
    Console.WriteLine(AS);
}

void exibir()
{
    exibirBoasVindas();
    exibirOpçoes();
}
exibir();