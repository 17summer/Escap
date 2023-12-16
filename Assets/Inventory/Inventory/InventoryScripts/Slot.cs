using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public int slotID;
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public GameObject itemInSlot;
    public string slotinfo;
    public static Item temp;
    public void ItemOnClicked()
    {
        InventoryManager.UpdateItemInfo(slotinfo);
        Debug.Log(slotItem.itemName);
        temp = slotItem;
    }
    public void SetupSlot(Item item)
    {
        if (item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }
        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemHeld.ToString();
        slotinfo = item.itemInfo;
        slotItem= item; 
    }

    public void useEqiupment()
    {
        Debug.Log(temp);
        Debug.Log(temp.itemName);
        spawnEquipment.GetInstance().swapWeapon(temp.itemName);
    }
}
    