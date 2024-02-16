using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orb3 : MonoBehaviour, IDataPersistence
{
    public Player player;
    public AudioClip collectSound;
    public GameObject uiObject, checkPointObject;
    public Orb4 orb4;
    public bool collected3 = false;
    [SerializeField] public RawImage despair;
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
       this.collected3 = data.collected3;
       uiObject.SetActive(!this.collected3);
       checkPointObject.SetActive(!this.collected3);
    }

    public void SaveData(ref GameData data)
    {
        data.collected3 = this.collected3;
    }

    public void onSecondOrb()
    {
        uiObject.SetActive(true);
        checkPointObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FirstPersonController")
        { 
            player.orbs += 1;
            orb4.onThirdOrb();
            player.playerSounds.PlayOneShot(collectSound);
            this.collected3 = true;
            uiObject.SetActive(false);
            despair.enabled = true;
        }
    }

}
