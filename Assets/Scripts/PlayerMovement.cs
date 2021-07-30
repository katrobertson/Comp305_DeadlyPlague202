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
    [Header("FaceMask")]
    public GameObject faceMask;
    public bool isfaceMask = false;

    public Text Finish;
    public Text GroceriesCollect;

    public HealthBar healthbar;
    public int maxHealth = 100;
    public int currentHealth;

    public int Groceries = 0;
    public GameObject SanitizerGun;
    public GameObject End;

    public GameObject gameoverMenuUI;
    public GameObject levelCompleteUI;


    // Start is called before the first frame update
    void Start()
    {
        miniMap.SetActive(false);
        healthbar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        //SanitizerGun.SetActive(false);
        //End.SetActive(false);
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

        faceMask.SetActive(isfaceMask);


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
            //Debug.Log("Level Completed");
            //Finish.gameObject.SetActive(true);
            LevelCompleted();

        }
        
        if (collision.gameObject.tag == "Enemy1")
        {
            currentHealth = currentHealth - 10;
            healthbar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                GameOver();
            }
        }

        if (collision.gameObject.tag == "EnemyDanger")
        {
            currentHealth = currentHealth - 50;
            healthbar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                GameOver();
            }
        }

        if (collision.gameObject.tag == "Mask")
        {
            Destroy(collision.gameObject);
            isfaceMask = true;
            StartCoroutine(ResetMask());
        }

        if (collision.gameObject.tag == "Groceries")
        {
            Destroy(collision.gameObject);
            Groceries += 1;
            GroceriesCollect.text = (Groceries + "/10");
            if (Groceries > 10)
            {
                End.SetActive(true);
            }
        }

        if (collision.gameObject.tag == "SanitizerBlue")
        {
            Destroy(collision.gameObject);
            SanitizerGun.GetComponent<Shooting>().state = 1;
        }

        if (collision.gameObject.tag == "SanitizerGreen")
        {
            Destroy(collision.gameObject);
            SanitizerGun.GetComponent<Shooting>().state = 2;
            StartCoroutine(ResetPower());

        }
    }

    //Powerup Timer
    private IEnumerator ResetMask()
    {
        yield return new WaitForSeconds(10);
        isfaceMask = false;
        //Debug.Log(System.DateTime.Now);
    }

    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(30);
        SanitizerGun.GetComponent<Shooting>().state = 1;
    }
    

    //Return facemask status
    public bool getFaceMask()
    {
        return isfaceMask;
    }

    public void GameOver()
    {
        gameoverMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void LevelCompleted()
    {
        levelCompleteUI.SetActive(true);
        Time.timeScale = 0f;

    }

}
