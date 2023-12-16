using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftSystem : MonoBehaviour
{
    public List<Items> items=new List<Items>();
    public List<Items> craftbleItems =new List<Items>();

    public bool isCrafting;
    public string currentCraftID;

    public List<Dropdown> craftInputs=new List<Dropdown>();
    public List<Image> craftImages =new List<Image>();
    public Image resultImage;
    public Sprite emptySlot;

    public GameObject stoneSword;
    public GameObject gemSword;
    public GameObject axe;

    public bool stoneSwordFlag;
    public bool genSwordFlag;
    public bool axeFlag;

    //tips
    public GameObject tips;
    public GameObject tipsParent;
    Items FetchItemByID(int _id){
        for(int i=0;i<items.Count;i++){
            if(items[i].ID == _id){
                return items[i];
            }
        }
        return null;
    }

    Items FetchCraftItem(string _id){
        for(int i=0;i<craftbleItems.Count;i++){
            if(craftbleItems[i].craftID == _id){
                return craftbleItems[i];
            }
        }
        return null;
    }

    void ConstractCraftItems(){
        for(int i=0;i<items.Count;i++){
            if(items[i].craftble){
                craftbleItems.Add(items[i]);
            }
        }
    }

    void Craft()
    {
        currentCraftID = "";
        for (int i = 0; i < craftInputs.Count; i++)
        {
            if (craftInputs[i].value != 0)
            {
                currentCraftID += craftInputs[i].value;
                craftImages[i].sprite = FetchItemByID(craftInputs[i].value).sprite;
            }
            else
            {
                currentCraftID += "";
                craftImages[i].sprite = emptySlot;
            }
        }

        if (!string.IsNullOrEmpty(currentCraftID))
        {
            Items result = FetchCraftItem(currentCraftID);
            if (result != null)
            {
                resultImage.sprite = result.sprite;
            }
            else
            {
                resultImage.sprite = emptySlot;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ConstractCraftItems();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCrafting){
            Craft();
        }
    }

    public void pushIntoInventory()
    {
        GameObject model = null;
        bool flag = false;
        if(currentCraftID == "412")
        {
            model = Instantiate(axe);
            flag = itemOnWorld.GetInstance().AddNewItem(model.GetComponent<Axe>().item);
        }else if(currentCraftID == "336")
        {
            model = Instantiate(gemSword);
            flag = itemOnWorld.GetInstance().AddNewItem(model.GetComponent<GemSword>().item);
        }
        else if(currentCraftID == "442")
        {
            model = Instantiate(stoneSword);
            flag = itemOnWorld.GetInstance().AddNewItem(model.GetComponent<StoneSword>().item);
        }
        if(!flag)
        {
            showUp();
        }
        if(model != null)
        {
            Destroy(model);
        }
        
    }

    public void showUp()
    {
        GameObject popup = Instantiate(tips, tipsParent.transform.parent);
        Text popupText = popup.GetComponentInChildren<Text>();
        if (popupText != null)
        {
            // set tips text
            popupText.text = "You don't have enough materials!";
        }
        Destroy(popup, 1f);
    }
}

[System.Serializable]
public class Items{
    public string name;
    public int ID;
    public Sprite sprite;
    public bool craftble;
    public string craftID;
}
