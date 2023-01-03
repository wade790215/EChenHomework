public interface IDataParser  
{
    public string GetExtension();

    public T ParseFrom<T>(string data);

    public string ParseTo(object data);  
}
