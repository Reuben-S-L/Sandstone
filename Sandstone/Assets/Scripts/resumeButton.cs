using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeButton : MonoBehaviour
{
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;

    public void resume()
    {
        Time.timeScale = 1;

        btn1.SetActive(false);
        btn2.SetActive(false);
        btn3.SetActive(false);
    }
}
