using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orb5 : MonoBehaviour, IDataPersistence
{
    public Player player;
    public AudioClip collectSound;
    public GameObject uiObject, checkPointObject;
    public adamsHouse adH;
    public finalScript fsc;
    public bool collected5 = false;
    [SerializeField] public RawImage remembrance;
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]

    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPersonController").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data)
    {
       this.collected5 = data.collected5;
       uiObject.SetActive(!this.collected5);
       checkPointObject.SetActive(!this.collected5);
    }

    public void SaveData(ref GameData data)
    {
        data.collected5 = this.collected5;
    }

    public void onFourthOrb()
    {
        uiObject.SetActive(true);
        checkPointObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FirstPersonController")
        { 
            player.orbs += 1;
            player.playerSounds.PlayOneShot(collectSound); 
            this.collected5 = true;
            uiObject.SetActive(false);
            adH.onFifthOrb();
            fsc.onFifthOrb();
            remembrance.enabled = true;
        }
    }

}
