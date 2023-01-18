// See https://aka.ms/new-console-template for more information

// Find how many times a character shows up in a text

// Create a new dictionary key strings and values int.
Dictionary<string, int> alphabet = new Dictionary<string, int>();

string text = "hah aha.;;";

for (int i = 0; i < text.Length; i++)
{
    string character =text.Substring(i,1);
    countCharacters(character);
}


foreach ( KeyValuePair<string, int> kvp in alphabet )
{
    Console.WriteLine($"Character {kvp.Key} was found {kvp.Value} times");  
 
}


int countCharacters (string character) {
    if(alphabet.Keys.Contains(character)) return alphabet[character]++;
    
    alphabet.Add(character, 1);
    return 0;
}


class myClass {
    public string? MyNam { get; set; }
};


