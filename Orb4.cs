using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orb4 : MonoBehaviour, IDataPersistence
{ 
    public Player player;
    public AudioClip collectSound;
    public GameObject uiObject, checkPointObject;
    public Orb5 orb5;
    public bool collected4 = false;
    [SerializeField] public RawImage rise;
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
       this.collected4 = data.collected4;
       uiObject.SetActive(!this.collected4);
       checkPointObject.SetActive(!this.collected4);
    }

    public void SaveData(ref GameData data)
    {
        data.collected4 = this.collected4;
    }

    public void onThirdOrb()
    {
        uiObject.SetActive(true);
        checkPointObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FirstPersonController")
        { 
            player.orbs += 1;
            orb5.onFourthOrb();
            player.playerSounds.PlayOneShot(collectSound); 
            this.collected4 = true;
            uiObject.SetActive(false);
            rise.enabled = true;
        }
    }

}
