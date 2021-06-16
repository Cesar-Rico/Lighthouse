using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stuffScript : MonoBehaviour
{

	private void Start()
	{
		StartCoroutine(rotateLeft());
	}


	private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "player")
		{
            print("cogiste una parte");
			scoreManager.stuffManager.TakeStuff(1);
			Destroy(gameObject);
			
		}

		if(collision.name.Contains("shark"))
		{
			Destroy(gameObject);
		}
    }

	IEnumerator rotateLeft()
	{
		this.transform.rotation = new Quaternion(0f, 0f, 10f, 0f);
		yield return new WaitForSeconds(0.5f);
		StartCoroutine(rotateRight());
	}

	IEnumerator rotateRight()
	{
		this.transform.rotation = new Quaternion(0f, 0f, -10f, 0f);
		yield return new WaitForSeconds(0.5f);
		StartCoroutine(rotateLeft());
	}
}
