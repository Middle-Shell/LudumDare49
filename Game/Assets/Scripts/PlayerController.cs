using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float health = 20f;
    public float kills = 0f;
    public float time = 0f;
    public float needKills = 0f;
    public List<GameObject> rooms;
    public Transform cam;

    public GameObject Spawner;
    private System.Random rnd = new System.Random();
    //private float 

    // Start is called before the first frame update14
    void Start()
    {
        rooms = new List<GameObject>();
        rooms.AddRange(GameObject.FindGameObjectsWithTag("Enter"));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Exit" && needKills <= kills)
        {
            int value = rnd.Next(0, rooms.Count);
            cam.position = new Vector3(rooms[value].transform.position.x, rooms[value].transform.position.y, -100);
            gameObject.transform.position = rooms[value].transform.position;
            rooms.RemoveAt(value);
            int countEnemy = rnd.Next(15, 40);
            var position = gameObject.transform.position;
            position.z -= 26;
            gameObject.transform.position = position;
            Spawner.GetComponent<Spawner>().StartSpawn(countEnemy, new int[] {((countEnemy / 2) * 2 / 3)+((countEnemy / 2) * 1 / 3)+(countEnemy/2), (countEnemy / 2) * 2 / 3, (countEnemy / 2) * 1 / 3 });
        }
    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
