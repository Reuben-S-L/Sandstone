using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelNumber : MonoBehaviour
{

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        text.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
