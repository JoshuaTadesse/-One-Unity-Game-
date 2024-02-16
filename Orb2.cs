using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orb2 : MonoBehaviour, IDataPersistence
{
    public Player player;
    public AudioClip collectSound;
    public GameObject uiObject, checkPointObject;
    public Orb3 orb3;
    public bool collected2 = false;
    [SerializeField] public RawImage punishment;
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
       this.collected2 = data.collected2;
       uiObject.SetActive(!this.collected2);
       checkPointObject.SetActive(!this.collected2);
    }

    public void SaveData(ref GameData data)
    {
        data.collected2 = this.collected2;
    }
    public void onFirstOrb()
    {
        uiObject.SetActive(true);
        checkPointObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FirstPersonController")
        { 
            player.orbs += 1;
            orb3.onSecondOrb();
            player.playerSounds.PlayOneShot(collectSound); 
            this.collected2 = true;
            uiObject.SetActive(false);
            punishment.enabled = true;
        }
    }

}
