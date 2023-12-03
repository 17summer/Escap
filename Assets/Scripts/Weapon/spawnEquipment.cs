using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEquipment : MonoBehaviour
{
    public GameObject current;
    public GameObject currentModel;
    public GameObject equipment;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gemStone = Instantiate(equipment,current.transform.position,current.transform.rotation);
        gemStone.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
