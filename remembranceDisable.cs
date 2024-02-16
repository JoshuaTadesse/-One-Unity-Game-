using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class remembranceDisable : MonoBehaviour
{
    public Orb5 orb5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            orb5.remembrance.enabled = false;
        }
    }
}
