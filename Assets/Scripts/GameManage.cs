using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject gameOverCanvas;
    private bool gameOver;

    private void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
    }

	private void Update()
	{
		if(gameOver)
		{
            if (Input.GetKey("space") || Input.GetKey(KeyCode.Return))
			{
                Replay();
			}

        }
	}

	public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        gameOverCanvas.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0;
        gameOver = true;
    }

    public void Win()
    {
        gameOverCanvas.SetActive(true);
        gameOverCanvas.transform.GetChild(1).gameObject.SetActive(true);
        Time.timeScale = 0;
        SoundSystemScript.PlaySound("POP_POSITIVE_5");
        gameOver = true;
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }
}
