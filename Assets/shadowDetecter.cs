using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowDetecter : MonoBehaviour
{
	public bool estaFuera = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.name == "player")
		{
			estaFuera = false;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.name == "player")
		{
			estaFuera = true;
			StartCoroutine(oscuridadMata());
		}
	}


	IEnumerator oscuridadMata()
	{
		yield return new WaitForSeconds(3f);
		if(estaFuera == false)
		{
			yield break;
		}
		else
		{
			print("Debes de llamar a tu función que baje un corazon");
			StartCoroutine(oscuridadMata());
		}
	}
}
