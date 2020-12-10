using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DontDelete : MonoBehaviour
{
    public GameObject music;
    public Button retryBtn;

    // Start is called before the first frame update
    void Start()
    {
            DontDestroyOnLoad(music);
    }


}
