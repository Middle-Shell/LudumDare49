using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punching : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public float other_range;
    
    public Transform attackPose; // позиция игрока
    public float attackRange; // дальность атаки
    public LayerMask whatIsEnemy;
    public float damage;
    private void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPose.position, attackRange, whatIsEnemy);
               for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().Damage(damage);
                }
            }

            timeBetweenAttack = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPose.position, attackRange);
    }
}

//https://www.youtube.com/watch?v=fNImkqOPCPE&ab_channel=GraphicalDesign