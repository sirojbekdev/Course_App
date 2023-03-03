using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Presentation.Application.Interfaces;
using Presentation.Domain.Entities;
using Presentation.Infostructure.SearchResults;

namespace Presentation.Infostructure.Services
{
    public class ItemSearch : IDisposable, IItemSearch
    {
        private const LuceneVersion _version = LuceneVersion.LUCENE_48;
        private static IUnitOfWork _unitOfWork;
        private readonly StandardAnalyzer _analyzer;
        private readonly RAMDirectory _directory;
        public readonly IndexWriter _writer;

        private List<Item> _items;

        public ItemSearch(IUnitOfWork unitOfWork)
        {
            _analyzer = new StandardAnalyzer(_version);
            _directory = new RAMDirectory();
            var config = new IndexWriterConfig(_version, _analyzer);
            _writer = new IndexWriter(_directory, config);
            _unitOfWork = unitOfWork;
        }

        public void Index()
        {
            //StandardAnalyzer analyzer = new StandardAnalyzer(_version);
            //var config = new IndexWriterConfig(_version, analyzer);
            //Writer = new IndexWriter(_directory, config);
            _items = _unitOfWork.Items.GetAll();

            var idField = new StringField("Id", "", Field.Store.YES);
            var titleField = new TextField("ItemTitle", "", Field.Store.YES);
            var appUserIdField = new StringField("AppUserId", "", Field.Store.YES);
            var appUserNameField = new TextField("AppUserName", "", Field.Store.YES);
            var collectionIdField = new StringField("CollectionId", "", Field.Store.YES);
            var collectionTitleField = new TextField("CollectionTitle", "", Field.Store.YES);

            var d = new Document()
            {
                idField,
                titleField,
                appUserIdField,
                appUserNameField,
                collectionIdField,
                collectionTitleField,
            };

            foreach (var item in _items)
            {
                idField.SetStringValue(item.Id.ToString());
                titleField.SetStringValue(item.Title);
                appUserIdField.SetStringValue(item.AppUserId.ToString());
                appUserNameField.SetStringValue(item.AppUserName);
                collectionIdField.SetStringValue(item.CollectionId.ToString());
                collectionTitleField.SetStringValue(item.Collection.Title);
                _writer.AddDocument(d);
            }
            _writer.Commit();
        }

        public void Dispose()
        {
            _writer.Dispose();
            _directory.Dispose();
        }

        public List<ItemResult> Search(string input)
        {
            var dirReader = DirectoryReader.Open(_directory);
            var searcher = new IndexSearcher(dirReader);

            string[] items = { "Id", "ItemTitle", "AppUserId", "AppUserName", "CollectionId", "CollectionTitle" };
            var multiFieldQP = new MultiFieldQueryParser(_version, items, _analyzer);
            Query query = multiFieldQP.Parse(input.Trim());

            var docs = searcher.Search(query, null, 1000).ScoreDocs;

            var results = new List<ItemResult>();
            for (int i = 0; i < docs.Length; i++)
            {
                Document d = searcher.Doc(docs[i].Doc);
                ItemResult item = new();
                item.Id = Guid.Parse(d.Get("Id"));
                item.Title = d.Get("ItemTitle");
                item.AppUserId = Guid.Parse(d.Get("AppUserId"));
                item.AppUserName = d.Get("AppUserName");
                item.CollectionId = Guid.Parse(d.Get("CollectionId"));
                item.CollectionTitle = d.Get("CollectionTitle");

                results.Add(item);
            }

            dirReader.Dispose();
            return results;
        }
    }
}
