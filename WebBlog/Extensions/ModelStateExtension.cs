using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebBlog.Extensions;

public static class ModelStateExtension
{
    public static List<string> GetErrors(this ModelStateDictionary modelStateDictionary) // this adiciona esse método em todos os model state
    {
        var result = new List<string>();
        foreach (var item in modelStateDictionary.Values)
        {
            result.AddRange(item.Errors.Select(error => error.ErrorMessage));
        }
        return result;
    }
}