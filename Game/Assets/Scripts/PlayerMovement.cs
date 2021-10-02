using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
<<<<<<< Updated upstream

=======
    DragonBones.UnityArmatureComponent anim;
>>>>>>> Stashed changes
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    AudioSource audioSrc;


    Vector2 movement;
    Vector2 mousePos;


    bool canMove = true;
    bool die = false;


    private void Start()
    {
        anim = GetComponent<DragonBones.UnityArmatureComponent>();
        audioSrc = GetComponent<AudioSource>();
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

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        /* if(mousePos.x >= 0)
         {
             this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
         }
         else
             this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
        */
        rb.rotation = angle;
        UpdateAnimation(movement.x, movement.y, Input.GetButtonDown("Fire1"), gameObject.GetComponent<PlayerController>().health);
    }
    void UpdateAnimation(float inputX, float inputY, bool attack, float health)
    {
        if (health > 0)
        {
            anim.animation.timeScale = 1;
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
                else if (inputX == 0)
                {
                    audioSrc.Stop();
                    if (anim.animation.lastAnimationName != "idle")
                        anim.animation.Play("idle");
                }
                // Идём
                else if (anim.animation.lastAnimationName != "goes")
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
}
