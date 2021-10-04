using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject a;// создаю игровой объект чт
    //public RememberOrder script;
    ////public int orderOfHits; не сохраняется
    //private int hitObjectNumber;
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
        //if (collision.transform.tag == "target")
        //{
        //    print("HIT IT");
        //    script = a.GetComponent<RememberOrder>();
        //    print("HOHOHOOHOH");
        //    print(script.orderOfHits);
        //    print("HAHAHHAH");

        //    //int.TryParse(collision.gameObject.name, out hitObjectNumber); // перевод имени из строки в число
        //    //print("WOW you got" + collision.gameObject.name); // Смотрим на имя объекта
        //    //print(hitObjectNumber); // на преобразованное имя
        //    //print(orderOfHits % 10);
        //    //if ((orderOfHits != 0) && ((orderOfHits % 10) == hitObjectNumber))
        //    //{
        //    //    Destroy(collision.gameObject);
        //    //}
        //    //    orderOfHits = orderOfHits / 10;
            
        //}
            Destroy(gameObject);
    }
}
