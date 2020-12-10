using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    public Button button;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetFloat(button.GetComponentInChildren<Text>().text) == 1)
        {
            button.interactable = true;
        }
 
    }

    public void loadLevel()
    {
        if (button.GetComponentInChildren<Text>().text != "1")
        {

            SceneManager.LoadScene("Level" + button.GetComponentInChildren<Text>().text);
        }
        else 
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
