using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthAnimationScript : MonoBehaviour
{
    public int hearthNumber;
    // Start is called before the first frame update
    void Start()
    {
        if(hearthNumber % 2 == 0)
		{
            StartCoroutine(down());
        }
		else
		{
            StartCoroutine(up());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator up()
	{
        this.transform.position += new Vector3(0f, 0.1f, 0f);
        yield return new WaitForSeconds(1f);
        StartCoroutine(down());
    }
    
    IEnumerator down()
	{
        this.transform.position -= new Vector3(0f, 0.1f, 0f);
        yield return new WaitForSeconds(1f);
        StartCoroutine(up());
    }
}
