int dice1 = 0, dice2 = 0, dice3 = 0, dice4 = 0, dice5 = 0;
bool fixed1 = false, fixed2 = false, fixed3 = false, fixed4 = false, fixed5 = false;

Console.Clear();
PlayGame(1);
Thread.Sleep(5000);
Console.Clear();
PlayGame(2);

void PlayGame(int player)
{
    System.Console.WriteLine();
    System.Console.WriteLine($"Player {player}");
    System.Console.WriteLine("=========");

    fixed1 = fixed2 = fixed3 = fixed4 = fixed5 = false;
    for (int i = 1; i <= 3 && !(fixed1 && fixed2 && fixed3 && fixed4 && fixed5); i++)
    {
        RollDice();
        if (i == 3) { SortDice(); }
        PrintDice(i);
        if (i < 3) { FixDice(); }
    }
}

void RollDice()
{
    if (!fixed1) { dice1 = Random.Shared.Next(1, 7); }
    if (!fixed2) { dice2 = Random.Shared.Next(1, 7); }
    if (!fixed3) { dice3 = Random.Shared.Next(1, 7); }
    if (!fixed4) { dice4 = Random.Shared.Next(1, 7); }
    if (!fixed5) { dice5 = Random.Shared.Next(1, 7); }
}

void PrintDice(int round)
{
    Console.WriteLine($"Dice Roll #{round} of 3: {dice1}, {dice2}, {dice3}, {dice4}, {dice5}");
}

void FixDice()
{
    fixed1 = fixed2 = fixed3 = fixed4 = fixed5 = false;
    System.Console.WriteLine("Which dice do you want to fix/unfix? (1-5 or 'r' to roll or end)");
    char input;
    do
    {
        input = Console.ReadKey(true).KeyChar; //(true hides the key the user enters)
        switch (input)
        {
            case '1': fixed1 = !fixed1; break;
            case '2': fixed2 = !fixed2; break;
            case '3': fixed3 = !fixed3; break;
            case '4': fixed4 = !fixed4; break;
            case '5': fixed5 = !fixed5; break;
            case 'r': break;
            default: Console.WriteLine("Invalid input. Please try again."); break;
        }

        if (input != 'r')
        {
            Console.Write("Fixed: ");
            if (fixed1) { Console.Write("1 "); }
            if (fixed2) { Console.Write("2 "); }
            if (fixed3) { Console.Write("3 "); }
            if (fixed4) { Console.Write("4 "); }
            if (fixed5) { Console.Write("5 "); }
            System.Console.WriteLine();
        }
        else { Console.WriteLine("---"); }
    }
    while (input != 'r');
}

void SortDice() //with help from Mark
{
    bool diceChange = true;
    do
    {
        diceChange = false;
        if (dice1 > dice2)
        {
            (dice1, dice2) = (dice2, dice1);
            diceChange = true;
        }
        if (dice2 > dice3)
        {
            (dice2, dice3) = (dice3, dice2);
            diceChange = true;
        }
        if (dice3 > dice4)
        {
            (dice3, dice4) = (dice4, dice3);
            diceChange = true;
        }
        if (dice4 > dice5)
        {
            (dice4, dice5) = (dice5, dice4);
            diceChange = true;
        }
    }
    while (diceChange == true);
}