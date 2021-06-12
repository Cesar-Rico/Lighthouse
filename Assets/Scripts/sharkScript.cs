using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharkScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Vector3 playerPosIni;
    public Vector3 velocity;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        playerPosIni = player.transform.position;

        //Codigo para hacer que el tiburon mire al player
        Vector3 lookAt = player.transform.position;
        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);
        float AngleDeg = ((180 / Mathf.PI) * AngleRad);
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);

        //Codigo para hacer que el tiburon se lance
        distance = Mathf.Sqrt(Mathf.Pow(this.transform.position.y - playerPosIni.y,2) + Mathf.Pow(this.transform.position.x - playerPosIni.x,2));
        velocity = new Vector3((playerPosIni.x - this.transform.position.x)/distance, (playerPosIni.y - this.transform.position.y)/distance, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = player.transform.position;
        this.GetComponent<Rigidbody2D>().velocity = velocity * speed;
    }
}
