using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassGenerate : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private float xMin, xMax, zMin, zMax, xRotationMax, xRotationMin;
    // to control the quantities of the stone in the scene
    private List<GameObject> grasses;

    // Start is called before the first frame update
    void Start()
    {
        xMax = 40.0f;
        xMin = -30.0f;
        zMax = 33.0f;
        zMin = -30.0f;
        xRotationMax = 120.0f;
        xRotationMin = 60.0f;
        grasses = new List<GameObject>();
        GenerateGrasses();
    }

    void GenerateGrasses()
    {
        HashSet<Vector3> generatedPositions = new HashSet<Vector3>();

        for (int i = 0; i < 100; i++)
        {
            Vector3 spawnPosition;
            float x, z;

            // Finds a new location in the generated location
            do
            {
                x = Random.Range(xMin, xMax);
                z = Random.Range(zMin, zMax);
                spawnPosition = new Vector3(x, 1f, z);
            } while (generatedPositions.Contains(spawnPosition));

            float rotationY = Random.Range(xRotationMin, xRotationMax);
            grasses.Add(Instantiate(prefabToSpawn, spawnPosition, Quaternion.Euler(0f,rotationY ,0f)));

            // Adds the generated location to the generated location collection
            generatedPositions.Add(spawnPosition);
        }

    }

}
