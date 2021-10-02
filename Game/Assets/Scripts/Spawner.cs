using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] EnemyList;

    public void StartSpawn(int countEnemy, int[] typeEnemy)
    {
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
        int x = rnd.Next(-13, 13);
        int y = rnd.Next(-10, 8);
        Instantiate(EnemyList[0], new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y + y, -1f), Quaternion.identity);
    }
    IEnumerator Stop(float delay)
    {
        yield return new WaitForSeconds(delay);
        CancelInvoke();
    }
}
