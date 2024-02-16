Dusing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public Orb orb1;
    public Orb2 orb2;
    public Orb3 orb3;
    public Orb4 orb4;
    public Orb5 orb5;
    public adamsHouse adH;
    public finalScript fsh;
    public Player player; 
    public static DataPersistenceManager instance { get; private set; }
    
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more than one DataPersistenceManager in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
        if(gameData.orbs == 0)
        {
            orb1.uiObject.SetActive(true);
            orb1.checkPointObject.SetActive(true);
            orb2.uiObject.SetActive(false);
            orb2.checkPointObject.SetActive(false);
            orb3.uiObject.SetActive(false);
            orb3.checkPointObject.SetActive(false);
            orb4.uiObject.SetActive(false);
            orb4.checkPointObject.SetActive(false);
            orb5.uiObject.SetActive(false);
            orb5.checkPointObject.SetActive(false);
            adH.uiObject.SetActive(false);
            fsh.uiObject.SetActive(false);
            fsh.checkPointObject.SetActive(false);

        }
        if(gameData.orbs == 1)
        {
            orb2.uiObject.SetActive(true);;
            orb2.checkPointObject.SetActive(true);
            orb3.uiObject.SetActive(false);
            orb3.checkPointObject.SetActive(false);
            orb4.uiObject.SetActive(false);
            orb4.checkPointObject.SetActive(false);
            orb5.uiObject.SetActive(false);
            orb5.checkPointObject.SetActive(false);
            adH.uiObject.SetActive(false);
            fsh.uiObject.SetActive(false);
            fsh.checkPointObject.SetActive(false);
        }
        else if(gameData.orbs == 2)
        {
            orb3.uiObject.SetActive(true);
            orb3.checkPointObject.SetActive(true);
            orb4.uiObject.SetActive(false);
            orb4.checkPointObject.SetActive(false);
            orb5.uiObject.SetActive(false);
            orb5.checkPointObject.SetActive(false);
            adH.uiObject.SetActive(false);
            fsh.uiObject.SetActive(false);
            fsh.checkPointObject.SetActive(false);
        }
        else if(gameData.orbs == 3)
        {
            orb4.uiObject.SetActive(true);
            orb4.checkPointObject.SetActive(true);
            orb5.uiObject.SetActive(false);
            orb5.checkPointObject.SetActive(false);
            adH.uiObject.SetActive(false);
            fsh.uiObject.SetActive(false);
            fsh.checkPointObject.SetActive(false);
        }
        else if(gameData.orbs == 4)
        {
            orb5.uiObject.SetActive(true);
            orb5.checkPointObject.SetActive(true);
            adH.uiObject.SetActive(false);
            fsh.uiObject.SetActive(false);
            fsh.checkPointObject.SetActive(false);
        }
        else if(gameData.orbs >= 5)
        {
            adH.uiObject.SetActive(true);
            fsh.uiObject.SetActive(true);
            fsh.checkPointObject.SetActive(true);

        }
    }

    public void NewGame()
    {
        this.gameData = new GameData();
        player.orbs = 0;
        orb1.collected = false;
        orb2.collected2 = false;
        orb3.collected3 = false;
        orb4.collected4 = false;
        orb5.collected5 = false;
        fsh.collected6 = false;
        player.vectorPoint = new Vector3(271.4f, 70.4f, 339.9f);
        player.transform.position = player.vectorPoint;
        SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if(this.gameData == null)
        {
            Debug.Log("No data was found, initializing with default settings.");
            NewGame();
        }
        
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

}
