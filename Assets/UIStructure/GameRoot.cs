using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ýű���Ҫ��������Ϸ�����ϵ� ����Ҫ�̳���MonoBehaviour��
/// </summary>
public class GameRoot : MonoBehaviour
{
    private UIManager uIManager;
    public UIManager root_UIMananger { get => uIManager; }
   
    private SceneControl sceneControl;
    public SceneControl root_SceneControl { get => sceneControl; }

    public bool _onOff = true;

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
        //root_UIMananger.Push(new healthBarPanel());
        #endregion

    }

    void Update()
    {
        
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Debug.Log("Press ESC!");
        //    root_UIMananger.Push(new InterfacePanel());
        //    if (_onOff)
        //    {
        //        Cursor.lockState = CursorLockMode.None;
        //    }
        //    else
        //    {
        //        Cursor.lockState = CursorLockMode.Locked;
        //    }

        //    _onOff = !_onOff;
        //    flag= 1;
        //}
        
        //if (Input.GetKeyDown(KeyCode.Escape) && flag == 1)
        //{
        //    root_UIMananger.Pop();
        //    flag = 0;
        //}


        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    root_UIMananger.Push(new inventoryPanel());
        //    if (_onOff)
        //    {
        //        Cursor.lockState = CursorLockMode.None;
        //    }
        //    else
        //    {
        //        Cursor.lockState = CursorLockMode.Locked;
        //    }

        //    _onOff = !_onOff;
        //}

        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    root_UIMananger.Push(new synthesisPanel());
        //    if (_onOff)
        //    {
        //        Cursor.lockState = CursorLockMode.None;
        //    }
        //    else
        //    {
        //        Cursor.lockState = CursorLockMode.Locked;
        //    }

        //    _onOff = !_onOff;
        //}

    }
}
