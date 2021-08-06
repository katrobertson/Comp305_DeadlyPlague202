using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatrolingR : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;

    public Vector2 boundaries = new Vector2(-4.0f, 4.0f);

    private GameObject outTile;
    public GameObject PeopleCured;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > boundaries.y )
        {
            transform.localScale = new Vector2(-1.0f, transform.localScale.y);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0f);
            //Debug.Log("Transform read");
        }
        else if(transform.position.x < boundaries.x)
        {
            transform.localScale = new Vector2(1.0f, transform.localScale.y);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0f);
            //Debug.Log("Transform read");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Antidote")
        {
            outTile = transform.Find("VirusM").gameObject;
            Destroy(outTile);
            PeopleCured.GetComponent<PeopleCured>().peoplecured();
            //PeopleCured.peoplecured();
        }
    }

    
}
