using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adamDisabled : MonoBehaviour
{
    public finalScript fsc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey(KeyCode.E))
        {
            fsc.adam.enabled = false;
        }        
    }
}
