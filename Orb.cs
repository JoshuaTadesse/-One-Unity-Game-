using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orb : MonoBehaviour, IDataPersistence
{
    public Player player;
    public AudioClip collectSound;
    public GameObject uiObject, checkPointObject;
    public Orb2 orb2;
    public bool collected = false;
    [SerializeField] public RawImage hope;
    
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
       this.collected = data.collected;
       uiObject.SetActive(!this.collected);
       checkPointObject.SetActive(!this.collected);
    }

    public void SaveData(ref GameData data)
    {
        data.collected = this.collected;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FirstPersonController")
        {
                player.orbs += 1;
                orb2.onFirstOrb();
                player.playerSounds.PlayOneShot(collectSound);
                this.collected = true; 
                uiObject.SetActive(false);
                hope.enabled = true;
        }
    }

}
