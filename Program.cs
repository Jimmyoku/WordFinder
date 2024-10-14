// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// AUTHOR : Jimmy Oku
// Date : Oct 14th, 2024


WordFinder wordFinder; //= new WordFinder();

static IEnumerable<string> CreateStringList()
    {
        List<string> strings = new List<string>
        {
            "americanstc",
            "mcpublmcofi",
            "eiyorkecity",
            "rtsslsrsodk",
            "iyorksiyork"
        };
        return strings;
    }

static IEnumerable<string> StreamWordsList()
    {
        List<string> strings = new List<string>
        {
            "city",
            "meri",
            "meri",
            "york",
            "pcka",
            "ijso"
        };
        return strings;
    }

// string[,] matrix = new string[,]
//         {
//             { "a", "b", "a", "d", "c" },
//             { "n", "a", "s", "p", "k" },
//             { "p", "i", "n", "k", "z" },
//             { "q", "s", "t", "u", "v" },
//         };

wordFinder = new WordFinder(CreateStringList());
wordFinder.Find(StreamWordsList());

//Console.WriteLine(find);
// wordFinder.


Console.Read();