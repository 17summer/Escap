using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel
{
    public UIType uiType;

    /// <summary>
    /// 此Panel在场景中对应的物体
    /// </summary>
    public GameObject ActiveObj;

    public BasePanel(UIType uIType) 
    { 
        uiType= uIType; 
    }

    public virtual void OnStart() 
    {
        Debug.Log("Obj is loaded!");
        if (ActiveObj.GetComponent<CanvasGroup>() == null)
        {
            ActiveObj.AddComponent<CanvasGroup>();
        }
    }

    public virtual void OnEnable() { 
        UIMethod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = true; 
    }
    public virtual void OnDisable() { UIMethod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = false; }
    public virtual void OnDestroy() { 
        UIMethod.GetInstance().AddOrGetComponent<CanvasGroup>(ActiveObj).interactable = false;
    }

}
