namespace Programm
{
    public class MainClass
    {
        static void Main()
        {
            // 0 - empty
            // 1 - X player 1
            // 2 - O player 2
            string[] cells = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            bool secondPlayer = false;

            // 0 - continue
            // 1 - win
            // 2 - tie
            int gameState = 0;

            while (true)
            {
                int currentPlayer = Convert.ToInt32(secondPlayer) + 1;
                int cellId = -1;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"\n {cells[0]} | {cells[1]} | {cells[2]} ");
                    Console.WriteLine($"---+---+---");
                    Console.WriteLine($" {cells[3]} | {cells[4]} | {cells[5]} ");
                    Console.WriteLine($"---+---+---");
                    Console.WriteLine($" {cells[6]} | {cells[7]} | {cells[8]} ");
                    Console.WriteLine($"Игрок 1:X Игрок 2:O\n");

                    if (gameState == 1)
                    {
                        Console.WriteLine($"Игрок {currentPlayer} победил!");
                        break;
                    }
                    else if (gameState == 2)
                    {
                        Console.WriteLine($"Ничья!");
                        break;
                    }

                    Console.WriteLine($"Игрок {currentPlayer}, выберите клетку [1-9]:");
                    cellId = Convert.ToInt32(Console.ReadLine());
                    if (cellId > 0 && cellId <= 9)
                    {
                        if (cells[cellId - 1] != "X" && cells[cellId - 1] != "O")
                        {
                            break;
                        } else
                        {
                            Console.WriteLine("Нельзя выбрать клетку, на которую сходили ранее!");
                            Console.WriteLine("Нажмите Enter, чтобы продолжить");
                            Console.ReadLine();
                        }
                        
                    }
                    else
                    {

                        Console.WriteLine("Не верный ввод! Число должно быть в пределах от 1 до 9!");
                        Console.WriteLine("Нажмите Enter, чтобы продолжить");
                        Console.ReadLine();
                    }
                }

                if (gameState != 0) break;

                cells[cellId - 1] = currentPlayer == 1 ? "X" : "O";

                int row = (cellId - 1) / 3;
                if (cells[row*3] == cells[row*3+1] && cells[row*3+1] == cells[row*3 + 2])
                {
                    gameState = 1;
                    continue;
                }

                int column = (cellId - 1) % 3;
                if (cells[column] == cells[column + 3] && cells[column + 3] == cells[column + 3 * 2])
                {
                    gameState = 1;
                    continue;
                }

                if ((cells[0] == cells[4] && cells[4] == cells[8]) || (cells[2] == cells[4] && cells[4] == cells[6]))
                {
                    gameState = 1;
                    continue;
                }

                bool emptyCellFinded = false;
                foreach(string s in cells)
                {
                    if (s != "X" && s != "O") 
                    {
                        emptyCellFinded = true;
                        break;
                    }
                }

                if (!emptyCellFinded)
                {
                    gameState = 2;
                    continue;
                }

                secondPlayer = !secondPlayer;
            }
        }
    }

}
