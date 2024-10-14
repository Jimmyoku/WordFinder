using System;
using System.Collections.Generic;
using System.Linq;


public class WordFinder
{
    private readonly char[,] _matrix;
    private readonly int _rows;
    private readonly int _cols;
    // private string[,] matrix;

    public WordFinder(IEnumerable<string> matrix)
    {
        // Checking if matrix is null
        if (matrix == null || !matrix.Any())
            throw new ArgumentException("Matrix cannot be null or empty.");

        _rows = matrix.Count();
        _cols = matrix.First().Length;

        // Checking on matrix size
        if (_rows > 64 || _cols > 64)
            throw new ArgumentException("Matrix size exceeds 64x64.");

        // Seting char[] _matrix size using matrix rows and columns size
        _matrix = new char[_rows, _cols];


        // Checking every line of matrix length before inserting each character in the char[] _matrix
        int row = 0;
        foreach (var line in matrix)
        {
            if (line.Length != _cols)
                throw new ArgumentException("All strings must have the same length.");

            for (int col = 0; col < _cols; col++)
            {
                _matrix[row, col] = line[col];
            }
            row++;
        }
    }

    // public WordFinder(string[,] matrix)
    // {
    //     this.matrix = matrix;
    // }

    public IEnumerable<string> Find(IEnumerable<string> wordStream)
    {
        // Checking if the word stream is not empty
        if (wordStream == null)
            throw new ArgumentException("Word stream cannot be null.");

        // Use a HashSet to avoid duplicate words in the word stream
        var uniqueWords = new HashSet<string>(wordStream);

        // var foundWords = new HashSet<string>();

        // Store found words in a dictionary to keep counts of repetive words
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        // Check horizontally (left to right)
        for (int r = 0; r < _rows; r++)
        {
            string rowString = new string(Enumerable.Range(0, _cols).Select(c => _matrix[r, c]).ToArray());
            foreach (var word in uniqueWords)
            {
                if (rowString.Contains(word))
                {
                    if (wordCounts.ContainsKey(word))
                        wordCounts[word]++;
                    else
                        wordCounts[word] = 1;
                }
            }
        }

        // Check vertically (top to bottom)
        for (int c = 0; c < _cols; c++)
        {
            string colString = new string(Enumerable.Range(0, _rows).Select(r => _matrix[r, c]).ToArray());
            foreach (var word in uniqueWords)
            {
                if (colString.Contains(word))
                {
                    if (wordCounts.ContainsKey(word))
                        wordCounts[word]++;
                    else
                        wordCounts[word] = 1;
                }
            }
        }

        // Get the list of 10 words sorted by count in descending order
        var sortedWords = wordCounts
            .OrderByDescending(pair => pair.Value)
            .Select(pair => pair.Key)
            .Take(10)
            .ToList();

        // List<string> firstFourItems = sortedWords.Take(2).ToList();

        // Display the top 10 most repeated words sorted
        Console.WriteLine("THE 10 MOST REPEATED WORDS FOUND ARE");
        foreach (var word in sortedWords)
        {
            Console.WriteLine(word);
        }

        // Return the top 10 most repeated words
        // var nas = foundWords.Take(2);
        return sortedWords;
    }
}