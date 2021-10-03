using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 5f;
    public Transform player;
    public float moveSpeed = 2.5f;
    public float distance = 5f;

    public byte role; //1 - easy enemy 2 - distance enemy 3 - Killer

    private Rigidbody2D rb;
    private Vector2 movement;
    

    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private Transform fireDot;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletForce = 20f;
    [SerializeField]
    private bool isShoot = false;
    [SerializeField]
    DragonBones.UnityArmatureComponent anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<DragonBones.UnityArmatureComponent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        switch (role)
        {
            case 1:
                InvokeRepeating("Easy", 0f, 0.01F);
                break;
            case 2:
                InvokeRepeating("Distance", 0f, 0.01F);
                break;
            case 3:
                InvokeRepeating("Killer", 0f, 0.01F);
                break;
        }
        
    }

    void Easy()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
        moveCharachter(movement);
    }
    void Distance()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
        
        
        if (Vector3.Distance(gameObject.transform.position, player.position) > 8f)
            moveCharachter(movement);

        if (!isShoot)
        {
            isShoot = true;
            InvokeRepeating("Rotate", 0f, 0.1f);
            InvokeRepeating("Shoot", 0f, 0.7f);
        }
    }
    void Killer()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.GetComponent<Rigidbody2D>().rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Damage(2f);
        }
    }

    void moveCharachter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void Damage(float damage)
    {
        health -= damage;
        if(health < 1)
        {
            player.gameObject.GetComponent<PlayerController>().kills += 1;
            Destroy(gameObject, .35f);
            anim.animation.Play("die");
        }
    }
    void Rotate()
    {
        Vector2 plpos = new Vector2(player.position.x, player.position.y);
        Vector2 fpPosition = new Vector2(firePoint.GetComponent<Transform>().position.x, firePoint.GetComponent<Transform>().position.y);
        Vector2 lookDir = plpos - fpPosition;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        firePoint.GetComponent<Transform>().rotation = Quaternion.Lerp(firePoint.GetComponent<Transform>().rotation, player.rotation, Time.time * 1f); ;
        firePoint.transform.Rotate(0.0f, 0.0f, angle, Space.Self);
        //firePoint.GetComponent<Transform>().rotation = angle;
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, fireDot.position, fireDot.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(fireDot.up * bulletForce, ForceMode2D.Impulse);
    }
}
