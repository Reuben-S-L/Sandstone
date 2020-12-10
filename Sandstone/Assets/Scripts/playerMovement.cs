using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;

    public float jumpStrength;

    private bool onGround;

    public bool hasJump;

    private Ray2D jumpCheck;

    private RaycastHit2D hit;

    public float jumpResetHeight;

    int layerMask;

    public float jumpCooldown = 1f;

    private float cooldownReset;

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
    }

    // Update is called once per frame
    void Update()
    {

        jumpCooldown -= Time.deltaTime;

        if (Physics2D.Raycast(rb.transform.position, Vector2.down, (1.19f * rb.transform.localScale.x), layerMask))
        {
            onGround = true;
        }


        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.AddForce(new Vector2(1 * speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.AddForce(new Vector2(-1 * speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround == true && jumpCooldown <= 0)
        {
            jumpCooldown = cooldownReset;

           
            audioSource.PlayOneShot(jumpSound);

            rb.AddForce(new Vector2(0, jumpStrength - transform.localScale.x*110), ForceMode2D.Impulse);

            onGround = false;
        }

        if(rb.velocity.y < 2.5 && onGround == false)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * 4f * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && hasJump == true)
        {
           
            audioSource.PlayOneShot(hiJump);

            rb.AddForce(new Vector2(0, jumpStrength*1.25f), ForceMode2D.Impulse);

            hasJump = false;

            onGround = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Ground")
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
