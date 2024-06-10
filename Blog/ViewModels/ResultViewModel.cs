namespace Blog.ViewModels;

public class ResultViewModel<TData>
{
    public ResultViewModel(TData data, List<string> errors)
    {
        Data = data;
        Errors = errors;
    }

    public ResultViewModel(TData data)
    {
        Data = data;
    }

    public ResultViewModel(List<string> errors)
    {
        Errors = errors;
    }
    
    public ResultViewModel(string error)
    {
        Errors.Add(error);
    }
    
    public TData Data { get; private set; }
    public List<string> Errors { get; private set; } = new();
}