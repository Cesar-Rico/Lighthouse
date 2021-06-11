using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharkScript : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        
        
        Vector3 lookAt = player.transform.position;

        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

        float AngleDeg = ((180 / Mathf.PI) * AngleRad);

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg-90);

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = player.transform.position;


    }
}
