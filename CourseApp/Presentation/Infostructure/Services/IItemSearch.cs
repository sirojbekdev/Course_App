using Presentation.Infostructure.SearchResults;

namespace Presentation.Infostructure.Services
{
    public interface IItemSearch
    {
        void Dispose();
        void Index();
        List<ItemResult> Search(string input);
    }
}