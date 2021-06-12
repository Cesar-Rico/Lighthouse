using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stuffScript : MonoBehaviour
{
	public GameObject shadow, generatorPosition, sharkGenerator, gameOver;
	public GameManage gameManager;
	private Vector3 scaleChange;

	private void Start()
	{
		shadow = GameObject.Find("shadow");
		generatorPosition = GameObject.Find("generatorPosition");
		sharkGenerator = GameObject.Find("sharkGenerator");
		gameOver = GameObject.Find("GameOver");
		gameManager = GameObject.Find("GameManager").GetComponent<GameManage>();
		scaleChange = new Vector3(0.1f, 0.1f, 0f);
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "player")
		{
            print("cogiste una parte");
			shadow.transform.localScale += scaleChange;
			if (shadow.transform.localScale == new Vector3(5f, 5f, 0f))
			{
				gameManager.GameOver();
			}
			else
			{
				generatorPosition.transform.position -= new Vector3(0.2f, 0f, 0f);
				sharkGenerator.transform.position = generatorPosition.transform.position;

				shadow.transform.GetChild(0).transform.GetChild(0).transform.position += new Vector3(0f, 0.1f, 0f);
				shadow.transform.GetChild(0).transform.GetChild(1).transform.position -= new Vector3(0f, 0.1f, 0f);
				shadow.transform.GetChild(0).transform.GetChild(2).transform.position += new Vector3(0.1f, 0f, 0f);
				shadow.transform.GetChild(0).transform.GetChild(3).transform.position -= new Vector3(0.1f, 0f, 0f);
				Destroy(gameObject);
			}
		}
    }
}
