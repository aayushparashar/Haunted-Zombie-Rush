using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip clip;
    public AudioClip death;
    Animator anim;
    Rigidbody rb;
    public float force = 20f;
    bool jump = false;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GameOver && GameManager.instance.GameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.PlayerStarted();
                anim.Play("Jump");
                source.PlayOneShot(clip);
                jump = true;
                rb.useGravity = true;

            }
        }
        
    }
    private void FixedUpdate()
    {
        if (jump)
        {
            jump = false;
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(0, force, 0, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        print("triggereeed");
        if(other.gameObject.tag == "obstacle")
        {
            GameManager.instance.PlayerCollided();
            rb.AddForce(50, 20, 0, ForceMode.Impulse);
            rb.detectCollisions = false;
            source.PlayOneShot(death);
        }else if(other.gameObject.tag == "coin")
        {
            print("A point!");
            other.gameObject.SetActive(false);
        }
    }
}
