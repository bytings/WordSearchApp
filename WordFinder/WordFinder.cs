using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearchApp
{
    public class WordFinder
    {
        private readonly char[,] _matrix;
        private readonly int _rows;
        private readonly int _cols;

        public WordFinder(IEnumerable<string> matrix)
        {
            _rows = matrix.Count();
            _cols = matrix.First().Length;
            _matrix = new char[_rows, _cols];

            int rowIndex = 0;
            foreach (var row in matrix)
            {
                for (int colIndex = 0; colIndex < _cols; colIndex++)
                {
                    _matrix[rowIndex, colIndex] = row[colIndex];
                }
                rowIndex++;
            }
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (var word in wordstream.Distinct())
            {
                int count = CountOccurrences(word);
                if (count > 0)
                {
                    wordCount[word] = count;
                }
            }

            return wordCount.OrderByDescending(w => w.Value)
                            .Take(10)
                            .Select(w => w.Key);
        }

        private int CountOccurrences(string word)
        {
            int count = 0;

            // Busco en filas
            for (int row = 0; row < _rows; row++)
            {
                string rowText = new string(Enumerable.Range(0, _cols).Select(c => _matrix[row, c]).ToArray());
                count += CountWordInText(rowText, word);
            }

            // Busco en columnas
            for (int col = 0; col < _cols; col++)
            {
                string colText = new string(Enumerable.Range(0, _rows).Select(r => _matrix[r, col]).ToArray());
                count += CountWordInText(colText, word);
            }

            return count;
        }

        private int CountWordInText(string text, string word)
        {
            int count = 0;
            int index = text.IndexOf(word);

            while (index != -1)
            {
                count++;
                index = text.IndexOf(word, index + word.Length); // Continuo búscando después de encontrar la palabra
            }

            return count;
        }
    }

}
