using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class touchControls : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;

    public float jumpStrength;

    private bool onGround;

    public bool hasJump = false;

    public float jumpCooldown = 1f;

    private float cooldownReset;

    private Ray2D jumpCheck;

    private RaycastHit2D hit;

    int layerMask;

    public AudioSource audioSource;

    public AudioClip jumpSound;

    public AudioClip hiJumpCollect;

    public AudioClip hiJump;



    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), 1f);  //Setting number associated with this level to one so can mark progress in level selector

        cooldownReset = jumpCooldown;

        jumpCheck = new Ray2D(rb.transform.position, Vector2.down);

        layerMask = LayerMask.GetMask("Ground");

        audioSource.pitch = 0.9f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        jumpCooldown -= Time.deltaTime;

        if (Physics2D.Raycast(rb.transform.position, Vector2.down, (1.2f * rb.transform.localScale.x), layerMask))
        {
            onGround = true;
        }


        if (Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);


            if (firstTouch.position.x > Screen.width/2)
            {

                rb.AddForce(new Vector2(1 * speed * Time.deltaTime, 0), ForceMode2D.Impulse);

            }

            if(firstTouch.position.x < Screen.width/2)
            {
                rb.AddForce(new Vector2(-1 * speed * Time.deltaTime, 0), ForceMode2D.Impulse);
            }

            
        }

        if (transform.localScale.x >= 0.95f)
        {
            audioSource.pitch = 0.9f;
        }

        if (Input.touchCount > 0)

        {
            if (Input.touches[0].tapCount == 2 && onGround == true && jumpCooldown <= 0)
            {

                onGround = false;

                jumpCooldown = cooldownReset;

                audioSource.pitch += ((1 - transform.localScale.x)/4);
                audioSource.PlayOneShot(jumpSound);

                rb.AddForce(new Vector2(0, jumpStrength - transform.localScale.x * 110), ForceMode2D.Impulse);


            }
        }

        if (rb.velocity.y < 2.5 && onGround == false)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * 4f * Time.deltaTime;

        }

        if (Input.touchCount == 2 && hasJump == true)
        {
           
            audioSource.PlayOneShot(hiJump);

            rb.AddForce(new Vector2(0, jumpStrength * 1.25f), ForceMode2D.Impulse);

            hasJump = false;

            onGround = false;
        }

        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            onGround = true;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "High-Jump")
        {

           
            audioSource.PlayOneShot(hiJumpCollect);

            Destroy(collision.gameObject);

            hasJump = true;


        }

        if (collision.gameObject.tag == "Refresh")
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (collision.gameObject.tag == "End")
        {
            

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.tag == "Spikes")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        if (collision.gameObject.tag == "Alt")
        {
            SceneManager.LoadScene("Level2");
        }

    }
}
