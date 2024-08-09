namespace TechRequest.API.Interfaces
{
    public interface IConverter<TSource, TDestination>
    {
        TDestination Convert(TSource sourceObject);
    }
}
