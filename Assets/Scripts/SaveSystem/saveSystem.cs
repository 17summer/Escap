using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;

public static class saveSystem
{

    public static int LOAD = 0;
    public static void saveByJson(string fileName,object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.persistentDataPath,fileName);

        try
        {
            File.WriteAllText(path, json);
            Debug.Log("Successfully saved data to local!"+$" Path is {path}");
        }
        catch (System.Exception e)
        {
            Debug.Log($"Failed saved data to {path}.And exception is "+e.Message);
        }
    }

    public static T LoadFromJson<T>(string fileName)
    {
        var path = Path.Combine(Application.persistentDataPath, fileName);
    
        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
            return data;
        }
        catch (System.Exception e) 
        {
            Debug.Log($"Failed to load data from {path}. And Exception is " + e.Message);
            return default;
        }
    }



    //public static void saveByPlayerPrefs(string key,object data)
    //{
    //    var json = JsonUtility.ToJson(data);
    //    Debug.Log(json);

    //    PlayerPrefs.SetString(key, json);
    //    PlayerPrefs.Save();

    //    #if UNITY_EDITOR
    //        Debug.Log("Successfully saved data to PlayerPrefs!");
    //    #endif
    //}

    //public static string LoadFromPlayerPrefs(string key)
    //{
    //    return PlayerPrefs.GetString(key,null);
    //}
}
