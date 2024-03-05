// This example demonstrates the
//     Console.CursorLeft and
//     Console.CursorTop properties, and the
//     Console.SetCursorPosition and
//     Console.Clear methods.
using System;
using ChessLibrary;

class Sample
{
    protected static int origRow;
    protected static int origCol;

    protected static void WriteAt(string s, int x, int y)
    {
        try
        {
            Console.SetCursorPosition(origCol + x, origRow + y);
            Console.Write(s);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }

    public static void Main()
    {
        Console.Clear();

        Console.WriteLine();
        Console.WriteLine();

        origRow = Console.CursorTop;
        origCol = Console.CursorLeft;
        
        const int ColumnOffset = 10;
        const int RowOffset = 4;
        for (var row = 0; row < 8; ++row)
        {
            var isDarkBackground = row % 2 == 0;


            for (var column = 0; column < 8; ++column)
            {
                Console.BackgroundColor = isDarkBackground ? ConsoleColor.White : ConsoleColor.Black;
                Console.ForegroundColor = row < 4 ? ConsoleColor.DarkBlue : ConsoleColor.Red;

                WriteAt(" O ", column * 3 + ColumnOffset, row + RowOffset);
                isDarkBackground = !isDarkBackground;
            }
        }

        Console.ResetColor();
        
        WriteAt("All done!", 0, 8 + 2 + RowOffset);
        Console.WriteLine();
    }
}
