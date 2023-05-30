using SearchIt.Services;

namespace SearchItUnitTest
{
    public class WordListTest
    {
        public IEnumerable<String> Words { get; }
        public WordListTest() {
            WordListService wordListService = new();
            Words = wordListService.GetAllWords();
        }
        [Fact]
        public void IsTheCountOfWordsInTheWordListCorrect()
        {
            Assert.IsAssignableFrom<IEnumerable<String>>(Words); // Stimmt der Datentyp
            Assert.True(Words.Count()==(int)Math.Pow(26,4));
        }

        /// <summary>
        /// Tests if the Words provided by the WordListService contains the words AAAA, BBBB, CCCC, ..., ZZZZ.
        /// </summary>
        [Fact]
        public void ContainsWordListWordsWithAllTheSameLetters()
        {
            for (char c = 'A' ; c <= 'Z'  ; c++)
            {        
                Assert.Contains($"{c}{c}{c}{c}", Words);
            }
        }

        [Fact]
        public void ContainsWordListARandomWord()
        {
            int A = (int)'A';
            int Z = (int)'Z';

            char c1 = (char)Random.Shared.Next(A, Z + 1); //Ascii from A-Z (65-90) second value is excluded
            char c2 = (char)Random.Shared.Next(A, Z + 1);
            char c3 = (char)Random.Shared.Next(A, Z + 1);
            char c4 = (char)Random.Shared.Next(A, Z + 1);
            string SearchText = $"{c1}{c2}{c3}{c4}";

            Assert.Contains(SearchText,Words);
        }

        [Fact]
        public void ContainsWordList1000RandomWords()
        {
            for (int i = 0;i < 1000; i++)
            {
                this.ContainsWordListARandomWord();
            }
        }
    }
}