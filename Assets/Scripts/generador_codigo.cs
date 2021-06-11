using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generador_codigo : MonoBehaviour
{
    public float timer = 0, turnSpeed, maxTime = 1;
    public GameObject shark;
    public GameObject faro;

    //Función que se ejecuta una sola vez al comienzo.
    void Start()
    {
        //GameObject newpipe = Instantiate(pipe);
        //newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-height -1.75f, height - 1.75f), 0);
    }

    //Función que se ejecuta múltiples veces (cada frame) todo el tiempo
    void Update()
    {
        //if (timer > maxTime)
        //{
        //    GameObject newpipe = Instantiate(pipe);
        //    newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-height - 1.75f, height - 1.75f), 0);
        //    Destroy(newpipe, 10);
        //    timer = 0;
        //}
        //timer += Time.deltaTime;

        this.transform.RotateAround(faro.transform.position, Vector3.forward, turnSpeed * Time.deltaTime);
    }
}
