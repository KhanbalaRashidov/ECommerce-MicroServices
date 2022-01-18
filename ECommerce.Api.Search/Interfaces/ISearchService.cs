namespace ECommerce.Api.Search.Interfaces
{
    public interface ISearchService
    {
      Task<(bool IsSucccess, dynamic SearchResult)>  SearchAsync(int customerId);
    }
}
