using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDataPersistence
{
    public int orbs = 0;
    public AudioSource playerSounds;
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] public Vector3 vectorPoint;
    [SerializeField] float dead;
    [SerializeField] public RawImage fadeIn;
    [SerializeField] public RawImage story;
    [SerializeField] public RawImage story1;
    [SerializeField] public RawImage story2;
    [SerializeField] public RawImage story3;
    [SerializeField] public RawImage story4;
    [SerializeField] public RawImage story5;
    [SerializeField] public RawImage story6;
    [SerializeField] public RawImage story7;
    [SerializeField] public RawImage etocontinue;
    [SerializeField] public RawImage ayzon;

    // Start is called before the first frame update
    void Start()
    {
        ayzon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < -dead) 
        {
            player.transform.position = vectorPoint;
            ayzon.enabled = true;
            etocontinue.enabled = true;

        }

        if (Input.GetKey(KeyCode.E))
        {
            fadeIn.enabled = false;
            story.enabled = false;
            story1.enabled = false;
            story2.enabled = false;
            story3.enabled = false;
            story4.enabled = false;
            story5.enabled = false;
            story6.enabled = false;
            story7.enabled = false;
            etocontinue.enabled = false;
            ayzon.enabled = false;
        } 
    }

    public void LoadData(GameData data)
    {
        player.transform.position = data.vectorPoint;
        vectorPoint = data.vectorPoint;
        this.orbs = data.orbs;
    }

    public void SaveData(ref GameData data)
    {
        data.vectorPoint = vectorPoint;
        data.orbs = this.orbs;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "CheckPoint1" || other.gameObject.name == "CheckPoint2" || other.gameObject.name == "CheckPoint3" || other.gameObject.name == "CheckPoint4" || other.gameObject.name == "CheckPoint5" || other.gameObject.name == "CheckPoint6")
        {
            vectorPoint = player.transform.position;
            Destroy(other.gameObject);
        }
    }
}
