using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerScript : MonoBehaviour
{
    private Vector3 mov;
    public GameManage gameManager;
    public GameObject gameOver;
    private HeartSystem heartSystem;
    // Start is called before the first frame update
    void Start()
    {
        heartSystem = this.GetComponent<HeartSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        manageMovement();
    }

    void manageMovement()
	{
        mov = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        );

        transform.position = Vector3.MoveTowards(
                            transform.position,
                            transform.position + mov,
                            5f * Time.deltaTime
                            );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "shark(Clone)")
        {
            print("Trigger");
            heartSystem.damage(1);
        }
    }
}
