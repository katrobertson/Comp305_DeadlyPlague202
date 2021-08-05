using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntidoteBehaviour : MonoBehaviour
{
    public GameObject SanitizerGun;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            SanitizerGun.GetComponent<Shooting>().state = 3;
        }
    }
}
