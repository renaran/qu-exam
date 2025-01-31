using System.Collections.Generic;
using System.Linq;

namespace MyApp.WordFinder
{
    public class WordFinder
    {
        private HashSet<string> _matrixWords;
        public WordFinder(IEnumerable<string> matrix)
        {
            _matrixWords = new HashSet<string>();

            var matrixArray = matrix.ToArray();
            var rows = matrixArray.Length;
            var cols = matrixArray[0].Length;

            //Horizontal words  
            for (var i = 0; i < rows; i++)
            {
                _matrixWords.Add(matrixArray[i]);
            }

            //Vertical words
            for (var j = 0; j < cols; j++)
            {
                var verticalWord = new char[rows];

                for (var i = 0; i < rows; i++)
                {
                    verticalWord[i] = matrixArray[i][j];
                }

                _matrixWords.Add(new string(verticalWord));
            }        
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var wordCount = new Dictionary<string, int>();
            var countedWords = new HashSet<string>();

            foreach(var word in wordstream)
            {
                //check if the word is in the matrix and if it has not been counted yet
                if (_matrixWords.Any(x => x.Contains(word)) && !countedWords.Contains(word))
                {
                    if(!wordCount.ContainsKey(word))
                    {
                        wordCount.Add(word, 1);                        
                        countedWords.Add(word);
                    }
                    else
                    {
                        wordCount[word]++;
                    }                    
                }
            }

            //return the top 10 words
            return wordCount.OrderByDescending(x => x.Value)
                            .Take(10)
                            .Select(x => x.Key);
        }
    }
}   
