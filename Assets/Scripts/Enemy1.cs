using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    //public Transform player;
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 movements;

    private Transform playerPos;
    private Vector2 currentPos;
    public float distance;

    //public PlayerMovement playerMovement;

    GameObject Player1;

    // Start is called before the first frame update
    void Start()
    {
        Player1 = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody2D>();

        playerPos = Player1.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player1.GetComponent<Transform>().position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movements = direction;

    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(transform.position, Player1.GetComponent<Transform>().position) < distance)
        {
            moveCharacter(movements);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, currentPos, moveSpeed * Time.fixedDeltaTime);
        }

    }

    void moveCharacter(Vector2 direction)
    {
        //Player1 = GameObject.Find("Player");
        if (!Player1.GetComponent<PlayerMovement>().getFaceMask())
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.fixedDeltaTime));
        }
    }

    
}
