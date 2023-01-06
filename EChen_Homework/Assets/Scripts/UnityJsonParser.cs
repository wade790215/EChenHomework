using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityJsonParser : IDataParser
{
    public string GetExtension()
    {
        return ".GG";
    }

    public T ParseFrom<T>(string data)
    {
        return JsonUtility.FromJson<T>(data);
    }

    public string ParseTo(object data)
    {
        return JsonUtility.ToJson(data, true);
    }

    public string ParseTo<T>(List<T> data)
    {
        return JsonHelper.ToJson(data.ToArray());
    }
}
