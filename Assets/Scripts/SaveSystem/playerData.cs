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
    public HealthBar health;
    public GameObject healthPanel;
    public HealthBar realHealth;
    //record the load information
    public float currentHealth;
    // record the continue status
    public float loadStatus;
    
    [System.Serializable] class saveData
    {
        public float hitPoints;
        public Vector3 position;
    }

    public float HitPoints => hitpoints;
    public Vector3 Position => transform.position;

    const string PLAYER_DATA_KEY = "PlayerData";
    const string PLAYER_DATA_FILE_NAME_1 = "PlayerData1.csv";
    const string PLAYER_DATA_FILE_NAME_2 = "PlayerData2.csv";

    private void Start()
    {
        loadStatus = 0;
        realHealth = healthPanel.GetComponent<HealthBar>();
        if (saveSystem.LOAD == 0)
        {
            itemOnWorld.GetInstance().clearItems();
        }

        if (saveSystem.LOAD == 1)
        {
            loadStatus = 1;
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
        currentHealth = saveData.hitPoints;
        realHealth.health = saveData.hitPoints;
        transform.position = saveData.position;
        Debug.Log("Loading!");
    }

    saveData Saving()
    {
        var saveData= new saveData();
        saveData.hitPoints = health.healthSlider.value;
        saveData.position =Position;

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
