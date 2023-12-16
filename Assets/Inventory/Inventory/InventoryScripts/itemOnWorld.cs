using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

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

    public bool AddNewItem(Item item)//add item into inventory
    {
        bool grassexist = false;
        bool stoneexist = false;
        bool woodexist = false;
        int grasstmp = 0;
        int stonetmp = 0;
        int woodtmp = 0;
        if (item.itemName == "Axe")
        {
            
            for (int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] != null)
                {
                    if (playerInventory.itemList[i].itemName == "Grass")
                    {
                        if(playerInventory.itemList[i].itemHeld <=0)
                        {
                           
                        }else
                        {
                            grasstmp = i;
                            grassexist = true;
                        }
                    }
                    else if (playerInventory.itemList[i].itemName == "Stone")
                    {
                        if (playerInventory.itemList[i].itemHeld <= 0)
                        {
                           
                        }
                        else
                        {
                            stonetmp = i;

                            stoneexist = true;
                        }

                    }
                    else if (playerInventory.itemList[i].itemName == "Wood")
                    {
                        if (playerInventory.itemList[i].itemHeld <= 0)
                        {
                           
                        }
                        else
                        {
                            woodtmp = i;

                            woodexist = true;
                        }
                    }
                    if(grassexist&& stoneexist&& woodexist)
                    {
                    playerInventory.itemList[grasstmp].itemHeld -= 1;
                    playerInventory.itemList[stonetmp].itemHeld -= 1;
                    playerInventory.itemList[woodtmp].itemHeld -= 1;

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        else if (item.itemName == "GemSword")
        {
            for (int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i].itemName == "Gem")
                {
                    playerInventory.itemList[i].itemHeld -= 2;

                }
                else if (playerInventory.itemList[i].itemName == "StoneSword")
                {
                    playerInventory.itemList[i].itemHeld -= 1;

                }

            }
        }
        else if (item.itemName == "StoneSword")
        {
            for (int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i].itemName == "Stone")
                {
                    playerInventory.itemList[i].itemHeld -= 2;

                }
                else if (playerInventory.itemList[i].itemName == "Grass")
                {
                    playerInventory.itemList[i].itemHeld -= 1;

                }

            }
        }

        if (!playerInventory.itemList.Contains(item))
        {
            for(int i = 0; i <playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = item;
                    break;
                }
            }
        }
        
            item.itemHeld += 1;
        

        InventoryManager.RefreshItem();
        return true;
    }

    public void clearItems()
    {
        for (int i = 0; i < playerInventory.itemList.Count; i++)
        {
            if (playerInventory.itemList[i] != null)
            {
                playerInventory.itemList[i].itemHeld = 0;
                playerInventory.itemList[i] = null;
                Destroy(playerInventory.itemList[i]);
            }
        }
        InventoryManager.RefreshItem();

    }
}
