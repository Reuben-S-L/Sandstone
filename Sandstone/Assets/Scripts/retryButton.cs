using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retryButton : MonoBehaviour
{
    public GameObject music;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void retry()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            Destroy(music);
        }

        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
