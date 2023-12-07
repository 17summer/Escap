using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnWorld : MonoBehaviour
{
    private static itemOnWorld instance;
    public static itemOnWorld GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("itemOnWorld Instance does not exist!");
            return instance;
        }
        else
        {
            return instance;
        }
    }

    public itemOnWorld()
    {
        instance = this;
    }

    public Item thisItem;
    public Inventory playerInventory;

    public void AddNewItem(Item item)//在背包中添加物品
    {
        if (!playerInventory.itemList.Contains(item))
        {
            //playerInventory.itemList.Add(thisItem);
            //InventoryManager.CreateNewItem(thisItem);
            for(int i = 0; i <playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = item;
                    break;
                }
            }
        }
        else
        {
            item.itemHeld += 1;
        }
        InventoryManager.RefreshItem();
    }
}
