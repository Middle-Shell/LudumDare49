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

    [Range(15, 100)]
    public int max_Count_Enemy;
    public GameObject Spawner;
    private System.Random rnd = new System.Random();
    //private float 
    [SerializeField]
    private GameObject lumen;

    // Start is called before the first frame update14
    void Start()
    {
        rooms = new List<GameObject>();
        rooms.AddRange(GameObject.FindGameObjectsWithTag("Enter"));
        SpawnStart(0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Exit" && needKills <= kills)
        {
            int value = rnd.Next(0, rooms.Count);
            cam.position = new Vector3(rooms[value].transform.position.x, rooms[value].transform.position.y, -100);
            gameObject.transform.position = rooms[value].transform.position;
            
            var position = gameObject.transform.position;
            position.z = -26;
            gameObject.transform.position = position;
            int RoomLayer = rooms[value].gameObject.layer;
            lumen.SetActive(false);
            print(RoomLayer);
            if (RoomLayer != 11)
                SpawnStart(RoomLayer == 9 ? 0 : RoomLayer == 8 ? 3 : 6);
            else
            {
                lumen.SetActive(true);
                needKills = 0;
            }
            rooms.RemoveAt(value);
            kills = 0;

        }
    }

    private void SpawnStart(int typeRoom)
    {
        print(typeRoom);
        int countEnemy = rnd.Next(15, max_Count_Enemy);
        needKills = ((countEnemy / 2) * 2 / 3) + (((countEnemy / 2) * 1 / 3) + (countEnemy / 2));
        Spawner.GetComponent<Spawner>().StartSpawn(countEnemy, new int[] { ((countEnemy / 2) * 2 / 3) + ((countEnemy / 2) * 1 / 3) + (countEnemy / 2), (countEnemy / 2) * 2 / 3, (countEnemy / 2) * 1 / 3 }, typeRoom);

    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            StartCoroutine(Dead(0.6f));
        }
    }
    IEnumerator Dead(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
