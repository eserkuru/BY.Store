namespace BY.Toolkit.Responses.Service
{
    public interface IServiceResponse<T>
    {
        bool IsSuccess { get; }
        IList<string> Messages { get; }
        T Data { get; }
    }
}
