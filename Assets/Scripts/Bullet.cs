using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hiteffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
            

        if (collision.gameObject.tag == "Enemy1")
        {
            SoundManager.PlaySound("enemyDeath");
            GameObject effect = Instantiate(hiteffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "AlienSpaceShip")
        {
            SoundManager.PlaySound("enemyDeath");
            GameObject effect = Instantiate(hiteffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
        else if (collision.gameObject.tag == "EnemyDanger")
        {
            SoundManager.PlaySound("enemyDeath");
            GameObject effect = Instantiate(hiteffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }

    }
}
