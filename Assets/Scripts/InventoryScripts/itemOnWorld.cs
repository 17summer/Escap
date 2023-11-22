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
    public Item thisItem;
    public Inventory playerInventory;
    private void OnTriggerEnter2D(Collider2D collision)//自动拾取
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }
    public void AddNewItem()//在背包中添加物品
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            //playerInventory.itemList.Add(thisItem);
            //InventoryManager.CreateNewItem(thisItem);
            for(int i = 0; i <playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1;
        }
        InventoryManager.RefreshItem();
    }
}
