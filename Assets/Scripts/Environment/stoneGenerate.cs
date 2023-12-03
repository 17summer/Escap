using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneGenerate : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private float xMin, xMax, zMin, zMax,xRotationMax,xRotationMin;
    // to control the quantities of the stone in the scene
    private List<GameObject> stones;
    // Start is called before the first frame update
    void Start()
    {
        xMax = 40.0f;
        xMin = -30.0f;
        zMax = 33.0f;
        zMin = -30.0f;
        xRotationMax = 120.0f;
        xRotationMin = 60.0f;
        stones = new List<GameObject>();
    }


    // Update is called once per frame
    void Update()
    {
        // if the stone has been collect it will become null
        stones.RemoveAll(item => item == null);
        //to make sure there are always stones in the scene
        if (stones.Count < 1)
        {
            GenerateStone();
        }    

    }

    void GenerateStone()
    {
        for(int i = 0; i < 10; i++)
        {
            float x = Random.Range(xMin, xMax);
            float z = Random.Range(zMin, zMax);
            float rotationX = Random.Range(xRotationMin,xRotationMax);
            stones.Add(Instantiate(prefabToSpawn, new Vector3(x, 1.3f, z), Quaternion.Euler(rotationX, 0f, 0f)));
        }
    }
}
