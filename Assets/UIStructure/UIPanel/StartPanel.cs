using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    private static string name = "StartPanel";
    private static string path = "Panel/Start_Panel";

    public static readonly UIType uIType = new UIType(path, name);
    
    public StartPanel():base(uIType)
    {

    }


    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnDisable()
    {

        base.OnDisable();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnStart()
    {
        base.OnStart();
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Start").onClick.AddListener(GameStart);
    }

    private void GameStart()
    {
        GameRoot.GetInstance().root_UIMananger.Pop();
        GameRoot.GetInstance().root_UIMananger.Push(new beginPanel());
    }
}
