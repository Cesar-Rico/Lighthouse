using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject gameOverCanvas;
    private bool gameOver;
    public Animator playerAnimator;
    public int nScene;

    private void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
        playerAnimator = GameObject.Find("player").GetComponent<Animator>();
    }

	private void Update()
	{
		if(gameOver)
		{
            if (Input.GetKey("space") || Input.GetKey(KeyCode.Return))
			{
                Replay();
			}

            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
                gameOver = false;
            }
        }
	}

	public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        gameOverCanvas.transform.GetChild(0).gameObject.SetActive(true);
        gameOverCanvas.transform.GetChild(1).gameObject.SetActive(true);
        gameOverCanvas.transform.GetChild(4).gameObject.SetActive(true);
        Time.timeScale = 0;
        gameOver = true;
    }

    public void Win()
    {
        gameOverCanvas.SetActive(true);
        gameOverCanvas.transform.GetChild(2).gameObject.SetActive(true);
        gameOverCanvas.transform.GetChild(3).gameObject.SetActive(true);
        gameOverCanvas.transform.GetChild(4).gameObject.SetActive(true);
        Time.timeScale = 0;
        SoundSystemScript.PlaySound("SPECIAL_COLECT_3");
        gameOver = true;
    }

    public void Replay()
    {
        SceneManager.LoadScene(nScene);
    }
}
