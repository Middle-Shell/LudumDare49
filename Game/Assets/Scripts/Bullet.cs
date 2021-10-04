using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print(collision.transform.name);
        GameObject effect =  Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .25f);
        if(collision.transform.tag == "enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Damage(2f);
        }
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Damage(2f);
        }
        Destroy(gameObject);
    }
}
