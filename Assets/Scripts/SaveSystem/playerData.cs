using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.IO;
using UnityEngine.UI;

public class playerData : MonoBehaviour
{
    [SerializeField] private float hitpoints;
    public Slider hitPointsBar;
    public Slider volumeBar;
    public HealthBar health;
    [SerializeField] private float volumeValue;
    
    [System.Serializable] class saveData
    {
        public float hitPoints;
        public float volumeBar;
        public Vector3 position;
    }
    //public playerData()
    //{
    //    hitpoints = hitPointsBar.value;
    //    volumeValue = volumeBar.value;
    //}

    public float VolumeValue => volumeValue;
    public float HitPoints => hitpoints;
    public Vector3 Position => transform.position;

    const string PLAYER_DATA_KEY = "PlayerData";
    const string PLAYER_DATA_FILE_NAME_1 = "PlayerData1.csv";
    const string PLAYER_DATA_FILE_NAME_2 = "PlayerData2.csv";

    private void Start()
    {
        if (saveSystem.LOAD == 1)
        {
            Load();
            saveSystem.LOAD= 0;
        }
    }


    #region JSON

    public void Save()
    {
        saveByJson();
    }
      
    public void Load()
    {
        LoadFromJson();
    }

    void saveByJson()
    {
        saveSystem.saveByJson(PLAYER_DATA_FILE_NAME_1, Saving());
    }

    void LoadFromJson()
    {
        var data = saveSystem.LoadFromJson<saveData>(PLAYER_DATA_FILE_NAME_1);

        LoadData(data);
    }

    void LoadData(saveData saveData)
    {
        health.maxHealth = saveData.hitPoints;
        volumeBar.value = saveData.hitPoints;
        transform.position = saveData.position;
        Debug.Log(volumeBar.value);
        Debug.Log(hitPointsBar.value);
        Debug.Log(transform.position);
        Debug.Log("Loading!");
    }

    saveData Saving()
    {
        var saveData= new saveData();
        saveData.hitPoints = hitPointsBar.value;
        saveData.volumeBar= volumeBar.value;
        saveData.position =Position;
        //volumeBar.value = VolumeValue;
        //hitPointsBar.value = HitPoints;


        return saveData;
    }
    
    public static void DeleteSavedFile(string fileName)
    {
        var path = Path.Combine(Application.dataPath, fileName);

        try
        {
            File.Delete(path);
        }
        catch(System.Exception e)
        {
            Debug.LogError($"Failed to delete data from {path}. \n Exception: {e.Message}");
        }
    }


    #endregion
}
