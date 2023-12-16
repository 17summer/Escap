using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfacePanel : BasePanel
{
    private static string name = "InterFace1";
    private static string path = "Panel/InterFace1";

    public static readonly UIType uIType = new UIType(path, name);

    public InterfacePanel() : base(uIType)
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
