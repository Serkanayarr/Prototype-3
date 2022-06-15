using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioSource playerAudio;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    public bool canDJump =true;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isOnGround || canDJump) && !gameOver) 
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            if (isOnGround) 
            {
                canDJump = true;
            }
            else
            {
                canDJump=false;
            }
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.1f);   

        }
     
       /* if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !gameOver && canDJump)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            canDJump = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.1f);

        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("GAME OVER!!!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1f);


        }
        else if (collision.gameObject.CompareTag("Obstacle2")) 
        {
            gameOver = true;
            Debug.Log("GAME OVER!!!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 2);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1f);
        }
        
    }
}