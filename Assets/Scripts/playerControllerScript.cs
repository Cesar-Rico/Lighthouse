using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { ADVENTURE, MENU }

public class playerControllerScript : MonoBehaviour
{
    private Vector3 mov;
    public GameManage gameManager;
    public GameObject gameOver;
    private HeartSystem heartSystem;
    private bool musica = false;
    public Animator anim;
    public State state;
    // Start is called before the first frame update
    void Start()
    {
        heartSystem = this.GetComponent<HeartSystem>();
        anim = this.GetComponent<Animator>();
        state = State.ADVENTURE;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.ADVENTURE)
		{
            manageMovement();
            if (musica == false)
            {
                musica = true;
                SoundSystemScript.PlaySoundtrack("Water-adventure");
            }
        }
    }

    void manageMovement()
	{
        mov = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        );

        if (mov.x != 0f)
        {
            anim.SetFloat("x", mov.x);
            
        }
        if(mov.y != 0f)
		{
            anim.SetFloat("y", mov.y);
        }

        transform.position = Vector3.MoveTowards(
                            transform.position,
                            transform.position + mov,
                            5f * Time.deltaTime
                            );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name.Contains("shark"))
        {
            print("Mordisco");
            SoundSystemScript.PlaySound("Bite");
            heartSystem.damage(1);
        }
    }

    public void GameOver()
	{
        state = State.MENU;
	}
}
