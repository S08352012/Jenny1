using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    Rigidbody rb;
    bool isG = true;
    Animator ani;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isG)
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isG = false;
            ani.SetTrigger("Jump_trig");
            dirt.Stop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isG = true;
            dirt.Play();
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            ani.SetBool("Death_b", true);
            ani.SetInteger("DeathType_int", 1);
            explosion.Play();
            dirt.Stop();
        }
    }
}
