using System.Collections.Generic;

namespace Upletter.Models
{
    public class WordList
    {
        public long ListId { get; set; }
        public string ListName { get; set; }
        public IEnumerable<Word> WList { get; set; }
    }
}
