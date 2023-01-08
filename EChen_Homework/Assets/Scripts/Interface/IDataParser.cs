using System.Collections.Generic;

public interface IDataParser  
{
    public string GetExtension();

    public T ParseFrom<T>(string data);

    public List<T> ParseFormListVer<T>(string data); 

    public string ParseTo(object data);

    public string ParseTo<T>(List<T> data);   
}
