namespace simpleDuolingo;

public static class Helpers
{
    public static string ReadSecret(string prompt = "")
    {
        Console.Write(prompt);
        string password = "";
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
                break;
            password += key.KeyChar;
        }

        Console.WriteLine();
        return password;
    }
}