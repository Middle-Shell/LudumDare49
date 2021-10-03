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
        //Spawn(0.2f);
        //TestCoroutine();
        InvokeRepeating("Spawn", 0f, 0.3F);
        StartCoroutine(Stop(2f));
    }

    IEnumerator TestCoroutine()
    {
        while (true)
        {
            yield return null;
            Debug.Log(Time.deltaTime);
        }
    }

    void Spawn()
    {
        
        System.Random rnd = new System.Random();
        int x = rnd.Next(-11, 12);
        int y = rnd.Next(-11, 11);
        Instantiate(EnemyList[0], new Vector3(this.startPosition.x + x, this.startPosition.y + y, -1f), Quaternion.identity);
    }
    IEnumerator Stop(float delay)
    {
        yield return new WaitForSeconds(delay);
        CancelInvoke();
    }
}
