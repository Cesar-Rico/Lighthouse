using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public GameManage gameManager;
    private int life;
    private bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        life = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            print("Estas muerto");
            gameManager.GameOver();
        }
    }
    public void damage(int value)
    {
        if (life >= 1)
        {
            life -= value;
            Destroy(hearts[life].gameObject);
            if (life < 1)
            {
                dead = true;
            }
        }
    }

}
