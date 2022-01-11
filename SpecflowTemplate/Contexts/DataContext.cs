namespace SpecflowTemplate.Contexts
{
    internal interface IDataContext
    {
        string ArticleSearchedFor { get; set; }
    }

    internal class DataContext : IDataContext
    {
        public string ArticleSearchedFor { get; set; }
    }
}
