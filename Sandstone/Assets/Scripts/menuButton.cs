using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuButton : MonoBehaviour
{
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;

    // Start is called before the first frame update
    void Start()
    {
        btn1.SetActive(false);
        btn2.SetActive(false);
        btn3.SetActive(false);
    }

    public void showMenu()
    {

        btn1.SetActive(true);
        btn2.SetActive(true);
        btn3.SetActive(true);

        Time.timeScale = 0;

    }
}
