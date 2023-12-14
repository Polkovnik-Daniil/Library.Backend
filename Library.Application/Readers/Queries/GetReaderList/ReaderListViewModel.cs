using Library.Application.Users.Queries.GetUserList;

namespace Library.Application.Readers.Queries.GetReaderList
{
    public class ReaderListViewModel
    {
        #region Fields
        public IList<ReaderLookupDto> Readers { get; set; }
        #endregion
    }
}
