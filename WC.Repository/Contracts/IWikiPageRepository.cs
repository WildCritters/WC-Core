using System.Collections.Generic;
using WC.Model;

namespace WC.Repository.Implementations
{
    interface IWikiPageRepository
    {
        IEnumerable<WikiPage> GetWikiPages();
        WikiPage GetWikiPageById(int id);
        void CreateWikiPage(WikiPage wikiPage);
        void DeleteWikiPage(int wikiPageId);
        void UpdateWikiPage(WikiPage wikiPage);
        void Save();
    }
}