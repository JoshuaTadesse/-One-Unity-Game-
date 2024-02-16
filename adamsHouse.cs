using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adamsHouse : MonoBehaviour
{
    public Player player;
    public AudioClip collectSound;
    public GameObject uiObject;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPersonController").GetComponent<Player>();
    }
    
        // Update is called once per frame
    void Update()
    {
        
    }

    public void onFifthOrb()
    {
        uiObject.SetActive(true);
    }

}
