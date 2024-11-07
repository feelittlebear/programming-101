using System;

class SubstitutionCipher
{
    static string alphabet = "abcdefghijklmnopqrstuvwxyz";
    static string scrambledAlphabet = "opqrstuvwxyzabcdefghijklmn";

    // Encode method
    static string Encode(string input)
    {
        char[] encoded = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];

            // Only encode alphabetic characters
            if (char.IsLetter(currentChar))
            {
                bool isUpper = char.IsUpper(currentChar);
                currentChar = char.ToLower(currentChar);
                int index = alphabet.IndexOf(currentChar);

                if (index != -1)
                {
                    char encodedChar = scrambledAlphabet[index];
                    encoded[i] = isUpper ? char.ToUpper(encodedChar) : encodedChar;
                }
            }
        }

        return new string(encoded);
    }

    // Decode method
    static string Decode(string input)
    {
        char[] decoded = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];

            // Only decode alphabetic characters
            if (char.IsLetter(currentChar))
            {
                bool isUpper = char.IsUpper(currentChar);
                currentChar = char.ToLower(currentChar);
                int index = scrambledAlphabet.IndexOf(currentChar);

                if (index != -1)
                {
                    char decodedChar = alphabet[index];
                    decoded[i] = isUpper ? char.ToUpper(decodedChar) : decodedChar;
                }
            }
        }

        return new string(decoded);
    }

    // Method to validate input (only allows alphabetic characters)
    static bool IsValidInput(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLetter(c)) // Check if any character is non-alphabetic
            {
                return false;
            }
        }
        return true;
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Enter 'encode', 'decode', or 'exit' to quit:");
            string? option = Console.ReadLine()?.ToLower();

            if (option == "exit")
            {
                Console.WriteLine("Exiting...");
                break; // Exit the loop and end the program
            }
            else if (option == "encode")
            {
                Console.WriteLine("Enter text to encode (alphabetic characters only):");
                string? textToEncode = Console.ReadLine();

                if (IsValidInput(textToEncode!))
                {
                    string encodedText = Encode(textToEncode!);
                    Console.WriteLine($"Encoded: {encodedText}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter only alphabetic characters.");
                }
            }
            else if (option == "decode")
            {
                Console.WriteLine("Enter text to decode (alphabetic characters only):");
                string? textToDecode = Console.ReadLine();

                if (IsValidInput(textToDecode!))
                {
                    string decodedText = Decode(textToDecode!);
                    Console.WriteLine($"Decoded: {decodedText}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter only alphabetic characters.");
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose 'encode', 'decode', or 'exit'.");
            }
        }
    }
}