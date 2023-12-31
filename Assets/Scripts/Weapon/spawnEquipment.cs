using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class spawnEquipment : MonoBehaviour
{
    public GameObject current;
    public GameObject currentModel;
    public GameObject Axe;
    public GameObject GemSword;
    public GameObject Sword;

    private void Start()
    {
        swapWeapon("Sword");
    }

    private static spawnEquipment instance;
    public static spawnEquipment GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("spawnEquipment Instance does not exist!");
            return instance;
        }
        else
        {
            return instance;
        }
    }

    public spawnEquipment()
    {
        instance= this;
    }

    public void swapWeapon(string weaponName)
    {
        Debug.Log(weaponName);
        if(currentModel == null)
        {
            if(weaponName == Axe.tag)
            {   
                currentModel = Instantiate(Axe, current.transform.position, current.transform.rotation);
                currentModel.transform.parent = this.transform;
                Quaternion newRotation = Quaternion.Euler(90.0f, 30.0f, 7.0f);
                currentModel.transform.localRotation = newRotation;

            }
            else if(weaponName == GemSword.tag)
            { 
                currentModel = Instantiate(GemSword, current.transform.position, current.transform.rotation);
                currentModel.transform.parent = this.transform;
            }else
            {
                currentModel = Instantiate(Sword, current.transform.position, current.transform.rotation);
                currentModel.transform.parent = this.transform;
            }
        }else
        {
            Destroy(currentModel);
            if (weaponName == Axe.tag)
            {
                currentModel = Instantiate(Axe, current.transform.position, current.transform.rotation);
                currentModel.transform.parent = this.transform;
            }
            else if (weaponName == GemSword.tag)
            {
                currentModel = Instantiate(GemSword, current.transform.position, current.transform.rotation);
                currentModel.transform.parent = this.transform;
            }
            else
            {
                currentModel = Instantiate(Sword, current.transform.position, current.transform.rotation);
                currentModel.transform.parent = this.transform;
            }
        }
        
    }
}
