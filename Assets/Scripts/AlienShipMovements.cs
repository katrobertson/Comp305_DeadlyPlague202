using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShipMovements : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    float randX;
    float randY;
    float randX2;
    float randY2;
    Vector2 whereToSpawn;
    Vector2 whereToSpawn2;
    public float spawnRate = 2f;
    public float spawnRate2 = 4f;
    float nextSpawn = 0.0f;
    float nextSpawn2 = 0.0f;

    public HealthBar healthbar;
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject levelCompleteUI;

    public int damageLevel = 5;

    //Change Position
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 movements;

    private Transform playerPos;
    private Vector2 currentPos;
    public float distance;

    public Transform SafePos1;
    public Transform SafePos2;
    public Transform SafePos3;
    public Transform SafePos4;
    public Transform SafePos5;

    public GameObject antidote;

    // Start is called before the first frame update
    void Start()
    {
        healthbar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;

        rb = this.GetComponent<Rigidbody2D>();

        currentPos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-2f, 2f);
            randY = Random.Range(-2f, 2f);
            whereToSpawn = new Vector2(transform.position.x + randX, transform.position.y + randY);
            Instantiate(enemy1, whereToSpawn, Quaternion.identity);

        }

        if (Time.time > nextSpawn2)
        {
            nextSpawn2 = Time.time + spawnRate2;
            randX2 = Random.Range(-2f, 2f);
            randY2 = Random.Range(-2f, 2f);
            whereToSpawn2 = new Vector2(transform.position.x + randX, transform.position.y + randY);
            Instantiate(enemy2, whereToSpawn2, Quaternion.identity);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BulletsBlue")
        {
            Damage(damageLevel);
        }
        else if(collision.gameObject.tag == "BulletsGreen")
        {
            Damage(damageLevel*3);
        }

    }

    public void Damage(int damage_level)
    {
        currentHealth = currentHealth - damage_level;
        healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        { 
            antidote.SetActive(true);
            antidote.transform.position = transform.position;
            Destroy(gameObject);
            LevelCompleted();
        }
        else if (currentHealth <= 10)
        {
            //Move(SafePos5);
            transform.position = SafePos5.position;
        }
        else if (currentHealth <= 20 && currentHealth > 10)
        {
            //Move(SafePos4);
            transform.position = SafePos4.position;
        }
        else if (currentHealth <= 40 && currentHealth > 20)
        {
            //Debug.Log("Target Position before call : " + SafePos3.position);
            //Move(SafePos3);
            transform.position = SafePos3.position;
        }
        else if (currentHealth <= 60 && currentHealth > 40)
        {
            //Move(SafePos2);
            transform.position = SafePos2.position;
        }
        else if(currentHealth <= 80 && currentHealth >60)
        {
            //Move(SafePos1);
            transform.position = SafePos1.position;
        }

    }

    public void LevelCompleted()
    {
        
        levelCompleteUI.SetActive(true);
        Time.timeScale = 0f;

    }

    private void Move(Transform Pos)
    {
       
        Vector3 direction = Pos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movements = direction;

        rb.MovePosition((Vector2)transform.position + (movements * moveSpeed * Time.fixedDeltaTime));

         
        //transform.position = Vector2.MoveTowards(transform.position, Pos.position, moveSpeed * Time.fixedDeltaTime);
        //Debug.Log("PositionCalled");
        //Debug.Log(currentHealth);
        //Debug.Log("Target Position: "+ Pos.position);
        //Debug.Log("Current Position: " + transform.position);

    }


}
