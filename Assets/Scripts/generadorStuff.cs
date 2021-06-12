using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorStuff : MonoBehaviour
{
    float timer = 0;
    public GameObject stuff;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.6f)
        {
            timer = 0;
            float x = Random.Range(-7f, 7f);
            float y = Random.Range(-0.5f, 8f);
            Vector3 position = new Vector3(x, y, 0);
            Quaternion rotation = new Quaternion();
            Instantiate(stuff, position, rotation);
        }
    }
}
