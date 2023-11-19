using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 该脚本是要挂载在游戏物体上的 所以要继承自MonoBehaviour类
/// </summary>
public class GameRoot : MonoBehaviour
{
    private UIManager uIManager;
    public UIManager root_UIMananger { get => uIManager; }
   
    private SceneControl sceneControl;
    public SceneControl root_SceneControl { get => sceneControl; }

    private static GameRoot instance;
    public static GameRoot GetInstance()
    {
        if(instance == null)
        {
            Debug.LogWarning("Failed to Obtain the GameRoot instance!");
            return instance;
        }
        return instance;
    }

    private void Awake()
    {
        if(instance==null)
        {
            instance= this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        uIManager = new UIManager();
        sceneControl= new SceneControl();
        
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        root_UIMananger.canvasObj = UIMethod.GetInstance().FindCanvas();

        #region push the first panel
        //root_SceneControl.scene_dict.Add();
        //root_UIMananger.Push(new beginPanel());
        #endregion

    }
}
