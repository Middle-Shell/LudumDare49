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



    public void StartSpawn(int countEnemy, int[] typeEnemy, int typeRoom)
    {
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
