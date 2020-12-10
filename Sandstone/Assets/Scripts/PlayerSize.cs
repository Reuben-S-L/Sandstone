using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSize : MonoBehaviour
{

    public Rigidbody2D rb;

    public Vector3 shrinkSpeed;

    public ParticleSystem ps;

    public GameObject retry;
    public GameObject main;
    public GameObject resume;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        

        if (rb.velocity != new Vector2 (0f,0f) && transform.localScale.x > 0)
        {
            if (!ps.isPlaying)
            { 
                ps.Play(); 
            }

            transform.localScale = transform.localScale - (shrinkSpeed * Time.deltaTime);
        }

        if (rb.velocity == new Vector2(0f, 0f))
        {
            if (ps.isPlaying)
            {
                ps.Stop();
            }
        }

        if (transform.localScale.x <= 0)
        {
            retry.SetActive(true);
            main.SetActive(true);
            resume.SetActive(true);

        }
    }
}
