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
    //private float 

    // Start is called before the first frame update14
    void Start()
    {
        rooms = new List<GameObject>();
        rooms.AddRange(GameObject.FindGameObjectsWithTag("Enter"));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Exit" && needKills == kills)
        {
            System.Random rnd = new System.Random();
            int value = rnd.Next(0, rooms.Count);
            gameObject.transform.position = rooms[value].transform.position;
            rooms.RemoveAt(value);
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
