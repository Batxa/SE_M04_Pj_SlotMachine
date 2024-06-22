using System;

class SlotMachineGame
{ 
    static Random random= new Random();
    static char[] symbols = { 'A', 'B', 'C', 'D', 'E' };

    static void Main(string[] args)
    {
        Console.WriteLine("Slot Machine Game");

        bool playAgain = true;
        while (playAgain)
        {
            Console.Write("Enter the wager amount: $");
            int wager = int.Parse(Console.ReadLine());

            Console.WriteLine("Select lines to play:");
            Console.WriteLine("1. Center Line");
            Console.WriteLine("2. All Horizontal Lines");
            Console.WriteLine("3. All Vertical Lines");
            Console.WriteLine("4. Diagonals");
            Console.Write("Enter your choice (1-4): ");
            int linesToPlay = int.Parse(Console.ReadLine());

            char[,] grid = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = symbols[random.Next(symbols.Length)];
                }
            }

            Console.WriteLine("Slot Machine Grid:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }

            int winnings = 0;
            if (linesToPlay == 1 || linesToPlay == 2)
            {
                if (grid[1, 0] == grid[1, 1] && grid[1, 1] == grid[1, 2]) winnings += 1;
            }
            if (linesToPlay == 2)
            {
                if (grid[0, 0] == grid[0, 1] && grid[0, 1] == grid[0, 2]) winnings += 1;
                if (grid[2, 0] == grid[2, 1] && grid[2, 1] == grid[2, 2]) winnings += 1;
            }
            if (linesToPlay == 3)
            {
                if (grid[0, 0] == grid[1, 0] && grid[1, 0] == grid[2, 0]) winnings += 1;
                if (grid[0, 1] == grid[1, 1] && grid[1, 1] == grid[2, 1]) winnings += 1;
                if (grid[0, 2] == grid[1, 2] && grid[1, 2] == grid[2, 2]) winnings += 1;
            }
            if (linesToPlay == 4)
            {
                if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2]) winnings += 1;
                if (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0]) winnings += 1;
            }

            Console.WriteLine($"You have won ${winnings}");

            Console.WriteLine("Do you want to play again? (yes/no)");
            string response = Console.ReadLine().ToLower();
            playAgain = response == "yes";
        }

        Console.WriteLine("Thank you for playing");
    }
}
