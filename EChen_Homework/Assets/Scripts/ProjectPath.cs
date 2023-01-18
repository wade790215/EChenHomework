using System.IO;
using UnityEngine;

public class ProjectPath : IDataPath
{
    public string GetDataPath()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
        return Path.Combine(directoryInfo.Parent.FullName, "Setting");
    }  
}
