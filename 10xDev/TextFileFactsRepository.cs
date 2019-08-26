using System.IO;

namespace _10xDev
{
    public class TextFileFactsRepository : IFactsRepository
    {
        private readonly string _path;

        public TextFileFactsRepository(string path)
        {
            _path = path;
        }
        
        public string GetFacts()
        {
            return File.ReadAllText(_path);
        }
    }
}
