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

    public FileHandler(IDataParser dataParser, IDataPath dataPath)
    {
        this.dataParser = dataParser;
        this.dataPath = dataPath;
    }

    public void SaveToJSON<T>(List<T> toSave)
    {
        string content = dataParser.ParseTo(toSave);
        WriteFile(GetDataPath<T>(), content);
    }

    public void SaveToJSON<T>(T toSave)
    {
        string content = dataParser.ParseTo(toSave);
        WriteFile(GetDataPath<T>(), content);
    }

    public List<T> ReadListFromJSON<T>()
    {
        string content = ReadFile(GetDataPath<T>());

        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>();
        }

        List<T> res = dataParser.ParseFormListVer<T>(content);
        return res;
    }

    public T ReadFromJSON<T>()
    {
        string content = ReadFile(GetDataPath<T>());

        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return default;
        }

        T res = dataParser.ParseFrom<T>(content);
        return res;
    }

    private string GetDataPath<T>()
    {
        var dataName = $"{typeof(T).Name}.{dataParser.GetExtension().TrimStart('.')}";
        var m_dataPath = Path.Combine(dataPath.GetDataPath(), dataName);
        return m_dataPath;
    }

    private void WriteFile(string path, string content)
    {
        if (File.Exists(path))
        {
            var result = MessageBoxController.ShowMessageBox("是否要覆寫設定檔案??", "警告", MessageBoxRetrunNumber.OKNo);
            if (result == (int)MessageResult.OK)
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.Write(content);
                        Debug.Log("儲存成功");
                    }
                }
            }
            else
            {
                Debug.Log($"選擇不複寫檔案");
            }
        }
        else
        {
            string directoryPath = Path.GetDirectoryName(path);

            if (Directory.Exists(directoryPath) == false)
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.Write(content);
                }
            }
        }
    }

    private string ReadFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return string.Empty;
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, true);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}