using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generador_codigo : MonoBehaviour
{
    public float timer = 0, turnSpeed, maxTime = 1;
    public GameObject shark;
    public GameObject faro;
    public GameObject player;

    //Función que se ejecuta una sola vez al comienzo.
    void Start()
    {
    }

    //Función que se ejecuta múltiples veces (cada frame) todo el tiempo
    void Update()
    {
        //Gira el objeto invisible en el que se instancia un tiburon.
        this.transform.RotateAround(faro.transform.position, Vector3.forward, turnSpeed * Time.deltaTime);

        if (timer > maxTime)
        {
            var rotation = Quaternion.LookRotation(player.transform.position);
            rotation *= Quaternion.Euler(0, 90, 0); // this adds a 90 degrees Y rotation
            GameObject newshark = Instantiate(shark);
            newshark.transform.position = this.transform.position;
            //newshark.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);


            Destroy(newshark, 10);
			timer = 0;
		}
		timer += Time.deltaTime;		
    }
}
