using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubo_codigo : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    //Función que se ejecuta una sola vez al comienzo.
    void Start()
    {

    }

    //Función que se ejecuta múltiples veces (cada frame) todo el tiempo
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
