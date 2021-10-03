using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] EnemyList;
    private Vector2 startPosition;



    public void StartSpawn(int countEnemy, int[] typeEnemy)
    {
        startPosition = gameObject.transform.position;
        print("start");
        while(countEnemy > 0)
        {
            int i = 0;
            while (i < 3)
            {
                if (typeEnemy[i] > 0)
                {
                    Invoke("Spawn(i)", 0.3F);
                    typeEnemy[i]--;
                    countEnemy--;
                }
                i++;
            }
            
        }    
        //InvokeRepeating("Spawn", 0f, 0.3F);
        StartCoroutine(Stop(2f, "Spawn"));
    }

    void Spawn(int i)
    {
        System.Random rnd = new System.Random();
        int x = rnd.Next(-11, 12);
        int y = rnd.Next(-11, 11);
        Instantiate(EnemyList[i], new Vector3(this.startPosition.x + x, this.startPosition.y + y, -1f), Quaternion.identity);
    }
    IEnumerator Stop(float delay, string name)
    {
        yield return new WaitForSeconds(delay);
        CancelInvoke(name);
    }
}
