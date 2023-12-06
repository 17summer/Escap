using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAYCastPickup : MonoBehaviour
{
    public float range = 2.0f;
    public int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Environment");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log(Input.mousePosition);
            PickUp();
        }
    }

    void PickUp()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range,layerMask))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider != null)
            {
                Debug.Log("Detect!");
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "stone")
                {
                    Destroy(hit.collider.gameObject);
                    Debug.Log("Destroyed!!");
                }
            }

            if (hit.collider != null)
            {
                if(hit.collider.tag == "Grass")
                {
                    Destroy(hit.collider.gameObject);
                    Debug.Log(hit.collider.gameObject.GetComponent<Grass>().item.name);
                    itemOnWorld.GetInstance().AddNewItem(hit.collider.gameObject.GetComponent<Grass>().item);
                }
            }
            
            if (hit.collider != null)
            {
                if(hit.collider.tag == "Branch")
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
