using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class despairDisable : MonoBehaviour
{
    public Orb3 orb3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            orb3.despair.enabled = false;
        }
    }
}
