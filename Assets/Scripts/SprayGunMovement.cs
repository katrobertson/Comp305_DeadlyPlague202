using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayGunMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public Rigidbody2D rb;

    public GameObject player;

    //Vector2 movement;
    Vector2 mousePos;

    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        rb.position = player.transform.position;

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
