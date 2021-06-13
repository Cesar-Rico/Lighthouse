using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowDetecter : MonoBehaviour
{
	public bool estaFuera = false;
	public GameObject faro;
	public HeartSystem playerHearts;

	// Start is called before the first frame update
	void Start()
    {
		playerHearts = GameObject.Find("player").GetComponent<HeartSystem>();
	}

    // Update is called once per frame
    void Update()
    {
		this.transform.position = faro.transform.position;
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
		yield return new WaitForSeconds(1f);
		if(estaFuera == false)
		{
			yield break;
		}
		else
		{
			print("Debes de llamar a tu funci�n que baje un corazon");
			playerHearts.damage(1);
			StartCoroutine(oscuridadMata());
		}
	}
}
