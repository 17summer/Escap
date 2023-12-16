using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryPanel : BasePanel
{
    private static string name = "Inventory";
    private static string path = "Panel/Inventory";

    public static readonly UIType uIType = new UIType(path, name);

    public inventoryPanel() : base(uIType)
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
