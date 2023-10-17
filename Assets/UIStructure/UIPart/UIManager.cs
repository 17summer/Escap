using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIManager
{
    /// <summary>
    /// 存放UI的栈
    /// </summary>
    public Stack<BasePanel> ui_stack;

    /// <summary>
    /// 存储Panel名称与物体的对应关系
    /// </summary>
    public Dictionary<string, GameObject> ui_dict;

    /// <summary>
    /// 当前场景下对应的画布
    /// </summary>
    public GameObject canvasObj;

    /// <summary>
    /// 单例
    /// </summary>
    private static UIManager instance;  
    public static UIManager GetInstance() 
    { 
        if(instance == null)
        {
            Debug.LogError("UIManager Instance does not exist!");
            return instance;
        }
        else
        {
            return instance; 
        }
    }

    public UIManager()
    {
        instance= this;
        ui_stack = new Stack<BasePanel>();
        ui_dict= new Dictionary<string, GameObject>();
    }

    public GameObject GetSingleObject(UIType uiType)
    {
        if(ui_dict.ContainsKey(uiType.Name))
        {
            return ui_dict[uiType.Name];
        }

        if(canvasObj== null)
        {
            Debug.Log("Load Canvas");
            canvasObj = UIMethod.GetInstance().FindCanvas();

            //canvasObj = UIMethod.GetInstance().FindCanvas();
            //Debug.LogError("UIManager failed to obtain Canvas!");
            //return null;
        }

        if (!ui_dict.ContainsKey(uiType.Name))
        {
            if (canvasObj == null)
            {
                return null;
            }
            else
            {
                //Load a obj from local and instantiate it
                GameObject gameObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(uiType.Path), canvasObj.transform);
                return gameObject;
            }
        }
        return null;
    }

    /// <summary>
    /// 往栈中压入当前的面板
    /// </summary>
    /// <param name="bp">当前正在使用的面板</param>
    public void Push(BasePanel bp)
    {
        Debug.Log($"{bp.uiType.Name} is pushed into stack");

        if(ui_stack.Count > 0 )
        {
            ui_stack.Peek().OnDisable();
        }

        GameObject ui_object = GetSingleObject(bp.uiType);
    
        ui_dict.Add(bp.uiType.Name, ui_object);
        bp.ActiveObj= ui_object;
    
        if(ui_stack.Count == 0)
        {
            ui_stack.Push(bp);
        }
        else
        {
            if(ui_stack.Peek().uiType.Name != bp.uiType.Name)
            {
                ui_stack.Push(bp);
            }
        }
        bp.OnStart();
    }

    public void Pop() 
    {
        if (ui_stack.Count > 0)
        {
            ui_stack.Peek().OnDisable();
            ui_stack.Peek().OnDestroy();
            GameObject.Destroy(ui_dict[ui_stack.Peek().uiType.Name]);
            ui_dict.Remove(ui_stack.Peek().uiType.Name);
            ui_stack.Pop();
        
            if(ui_stack.Count > 0)
            {
                ui_stack.Peek().OnEnable();
            }
        }
    }

    public void PopAll()
    {
        if(ui_stack.Count>0)
        {
            ui_stack.Peek().OnDisable();
            ui_stack.Peek().OnDestroy();
            GameObject.Destroy(ui_dict[ui_stack.Peek().uiType.Name]);
            ui_dict.Remove(ui_stack.Peek().uiType.Name);
            ui_stack.Pop();
            PopAll();
        }
    }
}
