using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class riseDisable : MonoBehaviour
{
    public Orb4 orb4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.E))
        {
            orb4.rise.enabled = false;
        } 
    }
}
