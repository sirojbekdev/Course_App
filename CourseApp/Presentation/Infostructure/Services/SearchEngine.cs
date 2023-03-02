using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Presentation.Domain.Entities;
using Presentation.Infostructure.Identity;
using Presentation.Infostructure.Persistence.Repositories;

namespace Presentation.Infostructure.Services
{
    public class SearchEngine
    {
        private const LuceneVersion _version = LuceneVersion.LUCENE_48;
        private readonly UnitOfWork _unitOfWork;
        private StandardAnalyzer _analyzer;
        private RAMDirectory _directory;
        private IndexWriter _writer;
        private List<AppUser> _users;
        private List<Topic> _topics;
        private List<Collection> _collections;
        private List<Item> _items;
        private List<Tag> _tags;
        public SearchEngine(UnitOfWork unitOfWork)
        {
            _analyzer = new StandardAnalyzer(_version);
            _directory = new RAMDirectory();
            var config = new IndexWriterConfig(_version, _analyzer);
            _writer = new IndexWriter(_directory, config);
            _unitOfWork = unitOfWork;
        }

        public void SetUpIndexes()
        {

        }
    }
}
