using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalScript : MonoBehaviour, IDataPersistence
{
    public Player player;
    public GameObject uiObject, checkPointObject;
    [SerializeField] public RawImage beauty, adam, note, logo;
    [SerializeField] public RawImage finalVid;
    [SerializeField] public RawImage ftocontinue;
    public int timeToStop;
    // public GameObject videoPlayer;
    public bool collected6 = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPersonController").GetComponent<Player>();
        // videoPlayer.SetActive(false);
    }

    public void LoadData(GameData data)
    {
       this.collected6 = data.collected6;
       uiObject.SetActive(!this.collected6);
       checkPointObject.SetActive(!this.collected6);
    }

    public void SaveData(ref GameData data)
    {
        data.collected6 = this.collected6;
    }

    public void onFifthOrb()
    {
        uiObject.SetActive(true);
        checkPointObject.SetActive(true);
    }

    public void onBeautyDisable()
    {
            finalVid.enabled = true;
            ftocontinue.enabled = true;
                    
    }

    // private IEnumerator RemoveAfterSeconds(int seconds, GameObject obj, RawImage vid)
    // {
    //     yield return new WaitForSeconds(seconds);
    //     obj.SetActive(false);
    //     vid.enabled = false;
    // }
    // Update is called once per frame
    void Update()
    {      
        if(finalVid.enabled)
        {
            if (Input.GetKey(KeyCode.F))
            {
                finalVid.enabled = false;
                ftocontinue.enabled = false;
                onFinalVidDisabled();
            }
        }
    }
    public void onFinalVidDisabled()
    {
        logo.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FirstPersonController")
        {
            player.orbs += 1; 
            beauty.enabled = true;
            this.collected6 = true;
        }
    }
}
