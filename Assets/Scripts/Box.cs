using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canMove;
    private float moveSpeed = 5f;
    private bool ignoreCollision;
    private bool gameOver;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Start()
    {
        canMove = true;
        if (Random.Range(0,2)>0)
        {
            moveSpeed *= -1f;

        }
        
        Controller.current.currentBox = this;
    }

    void Update()
    {
        MoveBox();
    }

    void MoveBox() 
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime * Controller.current.acceleration;

            if (temp.x>Controller.current.max)
            {
                moveSpeed *= -1f;
            }
            else if (temp.x<Controller.current.min)
            {
                moveSpeed *= -1f;
            }
            transform.position = temp;
        }
    }

    public void DropBox() 
    {
        canMove = false;
        rb.gravityScale = 2;
    }

    void Landed()
    {
        if (gameOver)
        {
            return;
        }

        ignoreCollision = true;
        Controller.current.boxCount+=1;

        Controller.current.SpawnBox();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ignoreCollision)
        {
            return;
        }

        if (collision.gameObject.tag=="Platform" || collision.gameObject.tag == "Box")
        {
            Invoke("Landed", 0.1f);
            ignoreCollision = true;
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.tag=="OutOfBounds")
        {
            CancelInvoke("Landed");
            gameOver = true;
            

            Invoke("Restart", 1f);
        }
    }

    void Restart() 
    {
        Controller.current.Restart();
    }
}
