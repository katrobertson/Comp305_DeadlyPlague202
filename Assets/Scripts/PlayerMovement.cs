using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public Rigidbody2D rb;
    //public Camera cam;

    public Animator animator;

    private Vector2 movement;
    //private Vector2 mousePos;

    [Header("Minimap")]
    public GameObject miniMap;

    public Text Finish;

    // Start is called before the first frame update
    void Start()
    {
        miniMap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //mousePos = cam.ScreenToViewportPoint(Input.mousePosition);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);



        if (Input.GetKeyDown(KeyCode.M))
        {
            //toggle the Minimap on/off
            miniMap.SetActive(!miniMap.activeInHierarchy);
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Vector2 lookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            Finish.gameObject.SetActive(true);
        }
    }
}
