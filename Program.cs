Console.OutputEncoding = System.Text.Encoding.Default;

int dice1 = 0, dice2 = 0, dice3 = 0, dice4 = 0, dice5 = 0;
bool fixed1 = false, fixed2 = false, fixed3 = false, fixed4 = false, fixed5 = false;
string hand = "";
int handValue = 0, hand1 = 0, hand2 = 0;

Console.Clear();
System.Console.WriteLine("🎲 Welcome to Poker dice! 🎲");
Console.Clear();
PlayGame(1);
hand1 = handValue;
Thread.Sleep(10_000);
Console.Clear();
PlayGame(2);
hand2 = handValue;
DetermineWinner();

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
        if (i == 3) { AnalyzeAndPrintResult(); }
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
    Console.Write($"Dice Roll #{round} of 3: ");
    Console.BackgroundColor = ConsoleColor.Gray;
    System.Console.WriteLine($"{dice1}, {dice2}, {dice3}, {dice4}, {dice5}");
    Console.ResetColor();
}

void FixDice()
{
    fixed1 = fixed2 = fixed3 = fixed4 = fixed5 = false;
    System.Console.WriteLine("Which dice do you want to fix/unfix? 🤔 (1-5 or 'r' to roll or end)");
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
            default: Console.WriteLine("Invalid input. 😭 Please try again."); break;
        }

        if (input is '1' or '2' or '3' or '4' or '5')
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

void SortDice() //with help from
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

void AnalyzeAndPrintResult()
{
    if (dice1 == dice2 && dice1 == dice3 && dice1 == dice4 && dice1 == dice5)
    {
        hand = "five of a kind";
        handValue = 1;
    }
    else if ((dice1 == dice2 && dice1 == dice3 && dice1 == dice4) || (dice2 == dice3 && dice2 == dice4 && dice2 == dice5))
    {
        hand = "four of a kind";
        handValue = 2;
    }
    else if ((dice1 == dice2 && dice1 == dice3 && dice4 == dice5) || (dice1 == dice2 && dice3 == dice4 && dice3 == dice5))
    {
        hand = "a full house";
        handValue = 3;
    }
    else if ((dice1 == 1 && dice2 == 2 && dice3 == 3 && dice4 == 4 && dice5 == 5) || (dice1 == 2 && dice2 == 3 && dice3 == 4 && dice4 == 5 && dice5 == 6))
    {
        hand = "a straight";
        handValue = 4;
    }
    else if ((dice1 == dice2 && dice1 == dice3) || (dice2 == dice3 && dice2 == dice4) || (dice3 == dice4 && dice3 == dice5))
    {
        hand = "three of a kind";
        handValue = 5;
    }
    else if ((dice1 == dice2 && dice3 == dice4) || (dice1 == dice2 && dice4 == dice5) || (dice2 == dice3 && dice4 == dice5))
    {
        hand = "two pairs";
        handValue = 6;
    }
    else if (dice1 == dice2 || dice2 == dice3 || dice3 == dice4 || dice4 == dice5)
    {
        hand = "one pair";
        handValue = 7;
    }
    else if (dice1 != dice2 && dice2 != dice3 && dice3 != dice4 && dice4 != dice5)
    {
        hand = "a bust";
        handValue = 8;
    }
    System.Console.WriteLine($"---\nYou have {hand}! 🎲");
}

void DetermineWinner()
{
    System.Console.WriteLine("---");
    if (hand1 < hand2) { System.Console.WriteLine("Player 1 wins! 🥳"); }
    else if (hand2 < hand1) { System.Console.WriteLine("Player 2 wins! 🥳"); }
    else { System.Console.WriteLine("It's a draw! 👽"); }
}
