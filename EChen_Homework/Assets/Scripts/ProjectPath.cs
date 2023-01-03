using System.IO;
using UnityEngine;

public class ProjectPath : IDataPath
{
    public string GetDataPath()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
        return  directoryInfo.Parent.FullName;
        //TODO 改成創立在資料夾底下
    }  
}
