using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faroScript : MonoBehaviour
{
    int randir;
    public float Hspeed;
    public GameObject shadow, generatorPosition, sharkGenerator, gameOver;
    public GameManage gameManager;
    private Vector3 scaleChange;
    public CircleCollider2D shadowDetecter;
    private float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(movement());
        shadow = GameObject.Find("shadow");
        generatorPosition = GameObject.Find("generatorPosition");
        sharkGenerator = GameObject.Find("sharkGenerator");
        gameOver = GameObject.Find("GameOver");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManage>();
        shadowDetecter = GameObject.Find("shadowDetecter").GetComponent<CircleCollider2D>();
        scaleChange = new Vector3(0.1f, 0.1f, 0f);
        timePassed = 0;
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

        timePassed += Time.deltaTime;
        if (timePassed > 5) reduceRadius();
    }

    IEnumerator movement()
	{
        randir = Random.Range(1, 4);
        yield return new WaitForSeconds(Random.Range(0.2f, 1f));
        StartCoroutine(movement());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            int num = scoreManager.stuffManager.UseStuff();
            timePassed = 0;
            if (num>0) 
            { 
                shadow.transform.localScale += (scaleChange*num);
                sharkGenerator.transform.localScale += (scaleChange*num);
                shadowDetecter.radius += 0.25f * num;
                if (Vector3.Distance(shadow.transform.localScale, new Vector3(6f, 6f, 0f))<1)
                {
                    gameManager.Win();
                }
                else
                {
                    generatorPosition.transform.position -= new Vector3(0.25f*num , 0f, 0f);
                    sharkGenerator.transform.position = generatorPosition.transform.position;

                    shadow.transform.GetChild(0).transform.GetChild(0).transform.position += new Vector3(0f, 0.1f * num, 0f);
                    shadow.transform.GetChild(0).transform.GetChild(1).transform.position -= new Vector3(0f, 0.1f * num, 0f);
                    shadow.transform.GetChild(0).transform.GetChild(2).transform.position += new Vector3(0.1f * num, 0f , 0f);
                    shadow.transform.GetChild(0).transform.GetChild(3).transform.position -= new Vector3(0.1f * num, 0f , 0f);
                }
            }
        }
        
    }

    private void reduceRadius()
    {
        int num = 2;
        shadow.transform.localScale -= (scaleChange * num);
        sharkGenerator.transform.localScale -= (scaleChange * num);
        shadowDetecter.radius -= 0.25f * num;

        generatorPosition.transform.position += new Vector3(0.25f * num, 0f, 0f);
        sharkGenerator.transform.position = generatorPosition.transform.position;

        shadow.transform.GetChild(0).transform.GetChild(0).transform.position -= new Vector3(0f, 0.1f * num, 0f);
        shadow.transform.GetChild(0).transform.GetChild(1).transform.position += new Vector3(0f, 0.1f * num, 0f);
        shadow.transform.GetChild(0).transform.GetChild(2).transform.position -= new Vector3(0.1f * num, 0f, 0f);
        shadow.transform.GetChild(0).transform.GetChild(3).transform.position += new Vector3(0.1f * num, 0f, 0f);

        timePassed = 0;
    }


}
