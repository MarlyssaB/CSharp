using System;
using System.Collections.Generic;

public class Program
{
    private static Dictionary<string, List<int>> pegs;

    
    static Program()
    {
        pegs = new Dictionary<string, List<int>>
        {
            { "a", new List<int>() { 4, 3, 2, 1 } },
            { "b", new List<int>() { } },
            { "c", new List<int>() { } }
        };

    }

    public static void Main()
    {
        Console.WriteLine("Welcome to the Towers of Hanoi!");
        Console.WriteLine();
        Console.WriteLine("Rules: Move all the disks from Peg A to Peg C. You may only move the top disk of a stack and can only move one disk at a time. ");
        Console.WriteLine("You cannot set a disk on top of a smaller disk. So while you can move Disk 1 on top of Disk 4, you cannot move Disk 4 on top of Disk 1");
        Console.WriteLine();
        Console.WriteLine("Press enter to begin.");
        Console.ReadLine();


        while (!GameOver())
        {
            Console.Clear(); //clears out the old boards. Mostly makes it look nicer
            Console.WriteLine();
            DrawPegs();
            Console.WriteLine();

            Console.WriteLine("Starting Peg:");
            string start = Console.ReadLine();

            Console.WriteLine("Move to Peg:");
            string finish = Console.ReadLine();

            if (IsValid(start, finish))
            {
                MovePiece(start, finish);
            }
            else
            {
                Console.WriteLine("Invalid move. Try again ");
            }

        }

        Console.Clear();
        DrawPegs();
        Console.WriteLine("Congratulations! You won!");
    }

    public static bool GameOver()
    {
        if (pegs["b"].Count == 4 || pegs["c"].Count == 4) //ends game if all 4 disks end up on the second or third pegs
        {
            return true;
        }

        return false;
    }

    public static void MovePiece(string start, string finish)
    {
        List<int> startPeg = pegs[start]; 
        List<int> endPeg= pegs[finish];

        int movingDisk = startPeg[startPeg.Count - 1]; // gets the block that we will move

        endPeg.Add(movingDisk);
        startPeg.Remove(movingDisk);
    }

    public static bool IsValid(string start, string finish)
    {
        // Checks if the ending peg is empty. If it is, any disk can be moved here and it will not check the disks. 
        if (pegs[finish].Count == 0)
        {
            return true;
        }
           

        List<int> startPeg  = pegs[start]; // these lists contain all the disks on the starting/ending pegs
        List<int> endPeg = pegs[finish];

        int movingDisk = startPeg[startPeg.Count - 1]; // grabs the top disk from the chosen peg. This is the disk that will be moved 
        int lastBlockEndPeg = endPeg[endPeg.Count - 1]; // gets the top disk of the ending peg. It will be compared to movingDisk to make sure the move is allowed

        //checks that the disk being moved is smaller than the top disk of the chosen pag. 
        if (movingDisk < lastBlockEndPeg)
        {
            return true;
        }
        else if (movingDisk > lastBlockEndPeg)
        {
            Console.WriteLine("Invalid move. Try again");
            return false;
        }
        else
        {
            Console.WriteLine("I'm a chicken! bockbockbockbock");
            return false;
        }
       
        
    }

    public static void DrawPegs()
    {// does what it says on the tin. Draws out the pegs and current disk positions for the player

        string[] letters = new string[] { "a", "b", "c" }; 
        for (var i = 0; i < letters.Length; i++)
        {
            List<string> disks = new List<string>();
            for (var j = 0; j < pegs[letters[i]].Count; j++)
            {
                disks.Add(pegs[letters[i]][j].ToString());
            }
            Console.WriteLine(letters[i] + ": " + String.Join(" ", disks));
        }
    }
}