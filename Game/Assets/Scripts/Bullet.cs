using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public float damage = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print(collision.transform.name);
        GameObject effect =  Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .45f);
        if(collision.transform.tag == "enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Damage(damage);
        }
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Damage(damage);
        }
        Destroy(gameObject);
    }
}
