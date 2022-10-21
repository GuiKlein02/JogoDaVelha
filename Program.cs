//Matriz do Jogo da Velha
const int jogadas = 9;
char[,] matriz = new char[3, 3];
char player = 'X'; //X sempre começa

for (int jogada = 0; jogada < jogadas; jogada++)
{
    DesenhaTabuleiro(matriz);

    bool vazio = false;

    while (!vazio)
    {
        bool valorLinhaOK = false;
        int linha = -1;
        while (!valorLinhaOK)
        {
            try
            {
                Console.WriteLine("Digite a linha para jogar de 0 a 2  " + player);
                linha = int.Parse(Console.ReadLine());
                if (linha > 2)
                    throw new Exception();
                else
                    valorLinhaOK = true;
            }
            catch
            {
                Console.WriteLine("Valor da linha inválido");
                valorLinhaOK = false;
            }
        }

        bool valorColunaOK = false;
        int coluna = -1;
        while (!valorColunaOK)
        {
            try
            {
                Console.WriteLine("Digite a coluna para jogar de 0 a 2 " + player);
                coluna = int.Parse(Console.ReadLine());
                if (coluna > 2)
                    throw new Exception();
                else
                    valorColunaOK = true;
            }
            catch
            {
                Console.WriteLine("Valor da linha inválido");
                valorColunaOK = false;
            }
        }

        if (matriz[linha, coluna] == '\0')
        {
            //Marca a posição escolhida
            matriz[linha, coluna] = player;
            vazio = true;
        }
        else
        {
            Console.WriteLine("Posição informada já possui uma jogada! Realize novamente a jogada!");
            DesenhaTabuleiro(matriz);
            vazio = false;
        }
    }

    //Alterna o player atual
    if (player == 'X')
        player = 'O';
    else
        player = 'X';

    if (VerificaGanhador(matriz) != '\0')
    {
        Console.WriteLine("Jogador " + VerificaGanhador(matriz) + " ganhou!");
        break;
    }
}

static void DesenhaTabuleiro(char[,] matriz)
{
    Console.WriteLine("     0        1       2");
    Console.WriteLine($"0:   {(matriz[0, 0] == '\0' ? " " : matriz[0, 0])}   |   {(matriz[0, 1] == '\0' ? " " : matriz[0, 1])}   |   {(matriz[0, 2] == '\0' ? " " : matriz[0, 2])}   ");
    Console.WriteLine("   ---------------------");
    Console.WriteLine($"1:   {(matriz[1, 0] == '\0' ? " " : matriz[1, 0])}   |   {(matriz[1, 1] == '\0' ? " " : matriz[1, 1])}   |   {(matriz[1, 2] == '\0' ? " " : matriz[1, 2])}   ");
    Console.WriteLine("   ---------------------");
    Console.WriteLine($"2:   {(matriz[2, 0] == '\0' ? " " : matriz[2, 0])}   |   {(matriz[2, 1] == '\0' ? " " : matriz[2, 1])}   |   {(matriz[2, 2] == '\0' ? " " : matriz[2, 2])}   ");
    Console.WriteLine();
}


static char VerificaGanhador(char[,] matriz)
{
    //Verifico as linhas
    for (int linha = 0; linha < 3; linha++)
    {
        char player = matriz[linha, 0];
        bool ganhou = true;
        for (int coluna = 0; coluna < 3; coluna++)
        {
            if (matriz[linha, coluna] != player)
            {
                ganhou = false;
                break;
            }
        }
        if (ganhou)
            return player;
    }

    //Verifica colunas
    for (int coluna = 0; coluna < 3; coluna++)
    {
        char player = matriz[0, coluna];
        bool ganhou = true;
        for (int linha = 0; linha < 3; linha++)
        {
            if (matriz[linha, coluna] != player)
            {
                ganhou = false;
                break;
            }
        }
        if (ganhou)
            return player;
    }

    //Verifica a Diagonal Principal
    char playerGeral = matriz[0, 0];
    bool ganhouGeral = true;
    for (int i = 0; i < 3; i++)
    {
        if (matriz[i, i] != playerGeral)
        {
            ganhouGeral = false;
            break;
        }
    }
    if (ganhouGeral)
        return playerGeral;

    //Verifica a outra Diagonal 
    if (matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
        return matriz[0, 2];

    bool deuVelha = true;
    for (int linha = 0; linha < 3; linha++)
    {
        for (int coluna = 0; coluna < 3; coluna++)
        {
            if (matriz[linha, coluna] == '\0'
                || matriz[linha, coluna] == ' ')
            {
                deuVelha = false;
                break;
            }
        }
    }
    if (deuVelha)
        return 'V';

    return '0'; //Ninguém ganhou mas o jogo ainda não acabou
}
