namespace Shortener.Data
{
    public interface IShortLinksRepo
    {
        string Get(string shortLink);
    }
}