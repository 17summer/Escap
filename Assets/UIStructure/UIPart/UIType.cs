using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIType
{
    private string path;
    private string name;

    public string Path { get => path; }
    public string Name { get => name; }
    /// <summary>
    /// 获取UI信息
    /// </summary>
    /// <param name="ui_Path">ui的路径</param>
    /// <param name="ui_Name">ui的名称</param>
    public UIType(string ui_Path,string ui_Name)
    {
        path= ui_Path;
        name= ui_Name;  
    }
}
