using SearchIt.Services;

namespace SearchItUnitTest
{
    public class WordSearchTest
    {
        [Fact]
        public void SearchResultContainsCorrectCountOfWords()
        {
            var SearchAlgorithm = new WordSearchService(new WordListService()).GetSearchResult;

            int A = (int)'A';
            int Z = (int)'Z';
            String SearchWord = $"{(char)Random.Shared.Next(A, Z + 1)}"; // maxValue is excluded
            int ExpectedCount = 26 * 26 * 26;
            
            for (int i = 1; i <= 4; i++) {
                int Count = SearchAlgorithm(SearchWord).Words.Count();
                Assert.True(ExpectedCount == Count);
                SearchWord += $"{(char)Random.Shared.Next(A, Z + 1)}";
                ExpectedCount /= 26;
            }
            
        }
    }
}
