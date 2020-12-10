using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMain : MonoBehaviour
{
    public void backToMainMenu()
    {

        

        Destroy(GameObject.Find("Music"));

        Time.timeScale = 1;

        SceneManager.LoadScene("Menu");

    }
}
