// See https://aka.ms/new-console-template for more information

// Find how many times a character shows up in a text
// Extend method on Dictionary to print key-value pairs

// Create a new dictionary key strings and values int.
Dictionary<string, int> alphabet = new Dictionary<string, int>();

string text = "hah aha.;;";

for (int i = 0; i < text.Length; i++)
{
    string character =text.Substring(i,1);
    countCharacters(character);
}


// printing over extension method
alphabet.printDictionary();


int countCharacters (string character) {
    if(alphabet.Keys.Contains(character)) return alphabet[character]++;
    
    alphabet.Add(character, 1);
    return 0;
}


// notice the static keywords and this for the first argument
static class DictionaryPrinter
{
    // printDictionary is extension method to Dictionary<string, int>
    public static void printDictionary(this Dictionary<string, int> alphabet)
    {
        foreach (KeyValuePair<string, int> kvp in alphabet)
        {
            Console.WriteLine($"Character {kvp.Key} was found {kvp.Value} times");

        }
    }
};



