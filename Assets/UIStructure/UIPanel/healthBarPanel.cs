using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarPanel : BasePanel
{
    private static string name = "HealthBar";
    private static string path = "Panel/HealthBar";

    public static readonly UIType uIType = new UIType(path, name);

    public healthBarPanel() : base(uIType)
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
