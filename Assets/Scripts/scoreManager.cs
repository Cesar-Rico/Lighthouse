using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public static scoreManager stuffManager;
    int numStuff = 0;
    void Start()
    {
        stuffManager = this;
    }

    // Update is called once per frame
    public void TakeStuff(int i)
    {
        numStuff += i;
        print(numStuff);
    }

    public int UseStuff()
    {
        int stuffToRepair = numStuff;
        numStuff = 0;
        return stuffToRepair;
    }

}
