using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    //transform of inventory
    public Transform inventoryParentObj;

    public GameObject inventoryUnit;
    //make it convenient to manage inventory units 
    public List<GameObject> inventoryGroup = new List<GameObject>();
    
    //the size of backpack
    public int InventoryCap = 15;
    // Start is called before the first frame update
    void Start()
    {
        changeBackpackCap(InventoryCap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeBackpackCap(int number)
    {
        //add the inventory unit to the backpack
        for(int i = 0; i < number ; i++)
        {
            inventoryGroup.Add(Instantiate(inventoryUnit, inventoryParentObj));
            inventoryGroup[inventoryGroup.Count-1].SetActive(true);
        }
    }
}
