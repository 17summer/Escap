using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class beginPanel : BasePanel
{
    private static string name = "Begin_Panel";
    private static string path = "Panel/Begin_Panel";

    public static readonly UIType uIType = new UIType(path, name);

    public beginPanel():base(uIType)
    {

    }

    public void GameStart()
    {
        SceneManager.LoadScene("DemoDay");
    }

    public override void OnStart()
    {
        base.OnStart();
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "New").onClick.AddListener(GameStart);

    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}
