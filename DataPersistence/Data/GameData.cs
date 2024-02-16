using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int orbs;
    public Vector3 vectorPoint;
    public bool collected;
    public bool collected2;
    public bool collected3;
    public bool collected4;
    public bool collected5;
    public bool collected6;

    public GameData()
    {
        this.orbs = 0;
        vectorPoint = new Vector3(271.4f, 70.4f, 339.9f);
        this.collected = false;
        this.collected2 = false;
        this.collected3 = false;
        this.collected4 = false;
        this.collected5 = false;
        this.collected6 = false;
    }
}
