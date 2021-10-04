using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private Transform Parent;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > Parent.position.x )
        {
            this.transform.localScale = new Vector2(this.transform.localScale.x > 0 ? this.transform.localScale.x * -1f : this.transform.localScale.x, this.transform.localScale.y);
        }
        else
        {
            this.transform.localScale = new Vector2(this.transform.localScale.x < 0 ? this.transform.localScale.x * -1f : this.transform.localScale.x, this.transform.localScale.y);
        }
    }
}
