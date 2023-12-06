using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneGenerate : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject branchPrefabToSpawn;
    private float xMin, xMax, zMin, zMax,xRotationMax,xRotationMin;
    // to control the quantities of the stone in the scene
    private List<GameObject> stones;
    private List<GameObject> branches;
    private bool flag;

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
        branches = new List<GameObject>();
        flag = true;
        GenerateStone();
        branchesGenerate();
    }


    // Update is called once per frame
    void Update()
    {
        // if the stone has been collect it will become null
        stones.RemoveAll(item => item == null);
        //to make sure there are always stones in the scene
        if (stones.Count == 0 && flag)
        {
            Debug.Log(stones.Count);
            Debug.Log("Generated!");
            flag= false;
            StartCoroutine(delayGenerateStones());
        }    

    }


    // if the whole stones have been picked up
    // genetate new stones 
    IEnumerator delayGenerateStones()
    {
        yield return new WaitForSeconds(10);
        GenerateStone();
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
        flag = true;
    }

    void branchesGenerate()
    {
        for(int i = 0; i < 50; i++)
        {
            float x = Random.Range(xMin, xMax);
            float z = Random.Range(zMin, zMax);
            float rotationY = Random.Range(xRotationMin, xRotationMax);
            branches.Add(Instantiate(branchPrefabToSpawn, new Vector3(x, 0.65f, z), Quaternion.Euler(0f, rotationY, 0f)));
        }
    }
}
