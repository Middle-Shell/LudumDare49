using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public int Roomtype;
    public GameObject[] EnemyList;
    private Vector2 startPosition;
    private System.Random rnd = new System.Random();

    [Range(80, 200f)]
    public int Max_time_spawn;

    public AudioClip[] audioClips;
    public AudioSource AS;


    public void StartSpawn(int countEnemy, int[] typeEnemy, int typeRoom)
    {
        AS = gameObject.GetComponent<AudioSource>();
        if (typeRoom == 0)
        {
            AS.clip = audioClips[0];
            AS.Play();
        }
        else if(typeRoom == 3)
        {
            AS.clip = audioClips[1];
            AS.Play();
        }
        else
        {
            AS.clip = audioClips[2];
            AS.Play();

        }
        startPosition = gameObject.transform.position;
        print("start");
        while(countEnemy > 0)
        {
            int i = 0;
            while (i < 3)
            {
                print(typeRoom + i);
                if (typeEnemy[i] > 0)
                {
                    
                    StartCoroutine(Spawn(rnd.Next(5, Max_time_spawn) /10, typeRoom + i, rnd.Next(-10, 11), rnd.Next(-10, 10)));
                    typeEnemy[i]--;
                    countEnemy--;
                    
                }
                i++;
            }
            
        }    
        //InvokeRepeating("Spawn", 0f, 0.3F);
        //StartCoroutine(Stop(2f, "Spawn"));
    }

    IEnumerator Spawn(float delay, int i, int x, int y)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(EnemyList[i], new Vector3(this.startPosition.x + x, this.startPosition.y + y, -1f), Quaternion.identity);
        StopCoroutine("Spawn");
    }
    /*IEnumerator Stop(float delay, string name)
    {
        yield return new WaitForSeconds(delay);
        CancelInvoke(name);
    }*/
}
