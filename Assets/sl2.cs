using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sl2 : MonoBehaviour
{
    public GameObject Paused;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        Paused.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pauza()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Paused.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Paused.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Continue()
    {
        isPaused = false;
        Paused.SetActive(false);
        Time.timeScale = 1f;
    }
}
