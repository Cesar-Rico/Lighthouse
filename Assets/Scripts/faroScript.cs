using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faroScript : MonoBehaviour
{
    int randir;
    public float Hspeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(movement());
    }

    void Update()
    {
        switch (randir)
        {
            case 1:
                this.transform.Translate(-Vector2.up * Hspeed * Time.deltaTime);
                break;
            case 2:
                this.transform.Translate(Vector2.up * Hspeed * Time.deltaTime);
                break;
            case 3:
                this.transform.Translate(Vector2.right * Hspeed * Time.deltaTime);
                break;
            case 4:
                this.transform.Translate(-Vector2.right * Hspeed * Time.deltaTime);
                break;
        }
    }

    IEnumerator movement()
	{
        randir = Random.Range(1, 4);
        yield return new WaitForSeconds(Random.Range(0.2f, 1f));
        StartCoroutine(movement());
    }
}
