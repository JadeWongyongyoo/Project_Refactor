using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Move_character : MonoBehaviour
{
    public GameObject heart_1 ,heart_2, heart_3, heart_4;
    public GameObject hitbox;
    float move;
    public float jumpForce = 500f;
    public float speed = 10f;
    float Horizontalmove = 0f;
    bool Jump = false;
    bool gamestarted = false;
    bool grounded = false;
    private bool m_FacingRight = true;

    Rigidbody2D rigidbody;
    Animator anim;
    AudioSource AudioClip;
    public void TargetDamage()
    {
        if (heart_4.gameObject.activeSelf == true)
        {
            heart_4.gameObject.SetActive(false);
        }
        else if (heart_3.gameObject.activeSelf == true)
        {
            heart_3.gameObject.SetActive(false);
        }
        else if (heart_2.gameObject.activeSelf == true)
        {
            heart_2.gameObject.SetActive(false);
        }
        else if (heart_1.gameObject.activeSelf == true)
        {
            heart_1.gameObject.SetActive(false);
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }       
    }
    public void TargetHeal()
    {
        if (heart_1.gameObject.activeSelf == false)
        {
            heart_1.gameObject.SetActive(true);
        }
        else if (heart_2.gameObject.activeSelf == false)
        {
            heart_2.gameObject.SetActive(true);
        }
        else if (heart_3.gameObject.activeSelf == false)
        {
            heart_3.gameObject.SetActive(true);
        }
        else if (heart_4.gameObject.activeSelf == false)
        {
            heart_4.gameObject.SetActive(true);
                        
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        hitbox.gameObject.SetActive(false);
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        AudioClip = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2.0f);
        hitbox.gameObject.SetActive(false);
    }
    void Update()
    {   

        if (Input.GetButtonDown("Fire1"))
        {
            hitbox.gameObject.SetActive(true);
            anim.SetTrigger("Attack");
            StartCoroutine(Delay());
            
        } 
        
        if (Input.GetButtonDown("Jump"))
        {
            if ((grounded == true) && (gamestarted == true))
            Jump = true;
            grounded = false;
            anim.SetTrigger("Jump");
            AudioClip.Play();
        }
        else
        {
            gamestarted = true;
            anim.SetTrigger("Start");
        }
        anim.SetBool("Grounded", grounded);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }
    private void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));

        rigidbody.velocity = new Vector2(speed * move, rigidbody.velocity.y);

        if (Jump == true)
        {
            rigidbody.AddForce(new Vector2(0f, jumpForce));
            Jump = false;
        }
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
