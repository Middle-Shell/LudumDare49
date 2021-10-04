using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    DragonBones.UnityArmatureComponent anim;
    
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    AudioSource audioSrc;

    public sbyte coof = 1;

    Vector2 movement;
    Vector3 mousePos;

    bool canMove = true;
    bool die = false;

    public GameObject Hand;
    public Transform firepoint;
    public Transform RotationPivot;
    private float angle;


    private void Start()
    {
        anim = GetComponent<DragonBones.UnityArmatureComponent>();
        audioSrc = GetComponent<AudioSource>();
        //InvokeRepeating("Transform", 0f, 0.1f);
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        RotateToCursor();
        UpdateAnimation(movement.x, movement.y, Input.GetButtonDown("Fire1"), gameObject.GetComponent<PlayerController>().health);
        
    }
    void UpdateAnimation(float inputX, float inputY, bool attack, float health)
    {
        if (health > 0)
        {
  
                // Атакуем
                if (attack)
                {
                    if (anim.animation.lastAnimationName != "ydar")
                        anim.animation.Play("ydar", 1);
                    audioSrc.Play();
                }
                // Ждём сперва окончания анимации
                else if ((anim.animation.lastAnimationName == "ydar") && anim.animation.isPlaying)
                {
                    //rb.AddForce(new Vector2(4, 7), ForceMode2D.Impulse);
                }
                // Стоим на месте
                else if (inputX == 0 && inputY == 0)
                {
                    //audioSrc.Stop();
                    if (anim.animation.lastAnimationName != "idle")
                        anim.animation.Play("idle");
                }
                // Идём
                else if (anim.animation.lastAnimationName != "walk_horizontally")
                {
                    anim.animation.Play("walk_horizontally");
                        if (!audioSrc.isPlaying)
                            audioSrc.Play();
                        /*if (transform.position.x >= 52f)
                        {
                            AudioSystem("Loli_step_snow");
                        }
                        else
                        {
                            AudioSystem("Loli_step");
                        }*/
                }
        }
        else
        {
            audioSrc.Stop();
            if (die && health <= 0)
            {
                anim.animation.Play("die");
                die = false;
            }
        }
    }
    /*void Rotate()
    {
        Vector3 lookDir = mousePos - fireDot.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        fireDot.GetComponent<Rigidbody2D>().rotation = angle;
    }*/
    private void RotateToCursor()
    {
        if ((angle - 180 < 90) && (angle - 180 > -90))
        {
            this.transform.localScale = new Vector2(-1f, this.transform.localScale.y);
            Hand.transform.localScale = new Vector2(-1f, -1f);
            firepoint.transform.localScale = new Vector2(-1f, -1f);
            coof = -1;
        }
        else
        {
            this.transform.localScale = new Vector2(1f, this.transform.localScale.y);
            Hand.transform.localScale = new Vector2(1f, 1f);
            firepoint.transform.localScale = new Vector2(1f, 1f);
            Hand.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 84));
            coof = 1;
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = (RotationPivot.position - cam.transform.position).z;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(RotationPivot.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg + 180;
        
        Hand.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
