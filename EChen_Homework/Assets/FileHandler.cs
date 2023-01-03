using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class FileHandler 
{
    public IDataParser dataParser = new UnityJsonParser();
    public IDataPath dataPath = new ProjectPath();

    public FileHandler() 
    { 

    }

    public FileHandler(IDataPath dataPath)
    {        
        this.dataPath = dataPath;
    }

    public FileHandler(IDataParser dataParser)
    {
        this.dataParser = dataParser;       
    }

    public FileHandler(IDataParser dataParser,IDataPath dataPath)
    {
        this.dataParser = dataParser;
        this.dataPath = dataPath;
    }
    
    public void SaveToJSON<T> (List<T> toSave, string filename) 
    {        
        string content = JsonHelper.ToJson<T> (toSave.ToArray());
        WriteFile (GetPath (filename), content);        
    }

    public void SaveToJSON<T> (T toSave)
    {
        string content = dataParser.ParseTo(toSave);     
        WriteFile(GetDataPath<T>(), content);
    }

    public List<T> ReadListFromJSON<T> (string filename)
    {
        string content = ReadFile (GetPath (filename));

        if (string.IsNullOrEmpty (content) || content == "{}") 
        {
            return new List<T> ();
        }

        List<T> res = JsonHelper.FromJson<T> (content).ToList ();
        return res;

    }

    public T ReadFromJSON<T> (string filename) 
    {
        string content = ReadFile (GetPath (filename));

        if (string.IsNullOrEmpty (content) || content == "{}") 
        {
            return default (T);
        }

        T res = JsonUtility.FromJson<T> (content);
        return res;

    }

    private string GetPath (string filename) 
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);       
        return directoryInfo.Parent.FullName + "/" + filename;       
    }

    private string GetDataPath<T>()
    {
        var dataName = $"{typeof(T).Name}.{dataParser.GetExtension().TrimStart('.')}";
        var m_dataPath = Path.Combine(dataPath.GetDataPath(), dataName);
        return m_dataPath;
    }

    private void WriteFile (string path, string content)
    {
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(content);
            }
        }       
    }

    private string ReadFile (string path) 
    {
        if (File.Exists (path)) 
        {
            using (StreamReader reader = new StreamReader (path)) 
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return "";
    }
}

public static class JsonHelper 
{
    public static T[] FromJson<T> (string json) 
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (json);
        return wrapper.Items;
    }

    public static string ToJson<T> (T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T> ();
        wrapper.Items = array;
        return JsonUtility.ToJson (wrapper);
    }

    public static string ToJson<T> (T[] array, bool prettyPrint) 
    {
        Wrapper<T> wrapper = new Wrapper<T> ();
        wrapper.Items = array;
        return JsonUtility.ToJson (wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T> {
        public T[] Items;
    }
}