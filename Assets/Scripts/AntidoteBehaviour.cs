using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntidoteBehaviour : MonoBehaviour
{
    public GameObject SanitizerGun;
    public GameObject CuredPeople;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CuredPeople.SetActive(true);
        }
    }
}
