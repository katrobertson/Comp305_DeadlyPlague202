using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShipActivator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject Alienship;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Alienship.SetActive(true);
            gameObject.SetActive(false);

        }
    }

}