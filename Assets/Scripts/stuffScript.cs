using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stuffScript : MonoBehaviour
{

	private void Start()
	{
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "player")
		{
            print("cogiste una parte");
			scoreManager.stuffManager.TakeStuff(1);
			Destroy(gameObject);
			
		}
    }
}
