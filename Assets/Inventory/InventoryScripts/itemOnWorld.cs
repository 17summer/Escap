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
    //private void OnTriggerEnter2D(Collider2D collision)//�Զ�ʰȡ
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        AddNewItem();
    //        Destroy(gameObject);
    //    }
    //}
    public void AddNewItem(Item item)//�ڱ����������Ʒ
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
