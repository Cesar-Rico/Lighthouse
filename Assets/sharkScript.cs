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
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = player.transform.position;
    }
}
