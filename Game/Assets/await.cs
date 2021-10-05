using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class await : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("startmiss", 34f);
    }

    void startmiss()
    {
        SceneManager.LoadScene(1);
    }
}
