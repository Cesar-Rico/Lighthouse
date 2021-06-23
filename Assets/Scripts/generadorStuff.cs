using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorStuff : MonoBehaviour
{
    float timer = 0;
    public GameObject stuff;
    public GameObject faro;
    // Update is called once per frame
    void Update()
    {
        //probando
        timer += Time.deltaTime;

        if (timer >= 0.6f)
        {
            timer = 0;
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-5f, 5f);
            Vector3 position = new Vector3(x, y, 0);
            //Quaternion rotation = new Quaternion();
            Instantiate(stuff, position + faro.transform.position, Quaternion.identity);
        }
    }
}
