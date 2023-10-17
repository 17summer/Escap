using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMethod
{
    private static UIMethod instance;
    public static UIMethod GetInstance()
    {
        if (instance == null)
        {
            instance = new UIMethod();
        }
        return instance;
    }

    /// <summary>
    /// 返回场景中对应类型Canvas的游戏物体
    /// </summary>
    /// <returns>游戏场景中的Canvas物体</returns>
    public GameObject FindCanvas()
    {
        GameObject gameObject = GameObject.FindObjectOfType<Canvas>().gameObject;
        if (gameObject == null)
        {
            Debug.LogError("Can't find object in scene!");
        }
        return gameObject;
    }

    public GameObject FindObjectInChild(GameObject panel, string child_name)
    {
        Transform[] transforms = panel.GetComponentsInChildren<Transform>();

        foreach (Transform tra in transforms)
        {
            if (tra.gameObject.name == child_name)
            {
                return tra.gameObject;
            }
        }
        Debug.LogWarning($"No {panel.name} exist in scene!");
        return null;
    }

    public T AddOrGetComponent<T>(GameObject get_Obj) where T : Component
    {
        if (get_Obj.GetComponent<T>() != null)
        {
            return get_Obj.GetComponent<T>();
        }

        Debug.LogWarning($"Failed to obtain the target component from the {get_Obj }");
        return null;
    }

    public T GetOrAddSingleComponentInChild<T>(GameObject panel, string ComponentName) where T : Component
    {
        Transform[] transforms = panel.GetComponentsInChildren<Transform>();

        foreach (Transform tra in transforms)
        {
            if (tra.gameObject.name == ComponentName)
            {
                return tra.gameObject.GetComponent<T>();
            }
        }

        Debug.LogWarning($"Can't find {ComponentName} from {panel.name}");
        return null;
    }
}
