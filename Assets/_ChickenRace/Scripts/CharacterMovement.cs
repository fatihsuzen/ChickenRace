using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using DG.Tweening;
public class CharacterMovement : NetworkBehaviour
{
    public float speed = 5;
    public float gravity = -5;
    Animator animator;
    float velocityY = 0;
    bool isRun=false;
    int road1,road2,road3;
    CharacterController controller;
    public GameObject egg;
    public Vector3 LastPoint;
    Vector3 input;
    Vector3 temp;
    Vector3 velocity;
    public List<AudioClip> AudioList = new List<AudioClip>();
    AudioSource audioSource;
    public GameObject Cam;
    //public ParticleSystem particle;
    void Start()
    {       
        if (isLocalPlayer)
        {
            Cam.SetActive(true);
            transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(0, 15));
            LastPoint = transform.position;
            controller = GetComponent<CharacterController>();
            controller.enabled = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(0, 15));
            controller.enabled = true;
            animator = GetComponent<Animator>();
            InvokeRepeating("RandomIdleAnimation", Random.Range(1f, 3f), Random.Range(4f, 10f));
            InvokeRepeating("CheckPoint",2,0.33f);
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = AudioList[0];
            audioSource.Play();
        }
    }

    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
        velocityY += gravity * Time.deltaTime;

        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        input = input.normalized;

        temp = Vector3.zero;
        if (input.z == 1)
        {
            temp += transform.forward;
            animator.SetBool("Run", true);
            animator.SetBool("Turn Head", false);
            animator.SetBool("Eat", false);
            isRun = true;
            RunSound();
        }
        else if (input.z == -1)
        {
            temp += transform.forward * -1;

            animator.SetBool("Turn Head", false);
            animator.SetBool("Eat", false);
            animator.SetBool("Run", true);
            isRun = true;
            RunSound();
        }
        else
        {
            animator.SetBool("Run", false);
            isRun = false;            
        }

        velocity = temp * speed;
        velocity.y = velocityY;

        controller.Move(velocity * Time.deltaTime);
        if (controller.isGrounded)
        {
            velocityY = 0;
        }

        }

    }
    void CheckPoint()
    {
        if (transform.position.x > 0 && road1 == 0)
        {
            road1++;
            LastPoint = transform.position;

        }
        else if (transform.position.x > 12.5f && road2 == 0)
        {
            road2++;
            LastPoint = transform.position;
            Cam.transform.DOLocalRotate(new Vector3(0, -80, 0), 1.5f);
            Cam.transform.DOLocalMoveX(2, 1f);
        }
        else if (transform.position.x > 29 && road3 == 0)
        {
            road3++;
            LastPoint = transform.position;

        }
    }
    void RunSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = AudioList[2];
            audioSource.Play();
        }
        
    }
    void RandomIdleAnimation()
    {
        int Rnd = Random.Range(0, 2);
        if (!isRun)
        {
            if (Rnd % 2 == 0)
            {
                animator.SetBool("Turn Head", false);
                animator.SetBool("Run", false);
                animator.SetBool("Eat", true);
            }
            else
            {
                animator.SetBool("Run", false);
                animator.SetBool("Eat", false);
                animator.SetBool("Turn Head", true);
            }
        }    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Car")
        {
            controller.enabled = false;
            egg.SetActive(true);

            audioSource.Stop();
            audioSource.clip = AudioList[1];
            audioSource.Play();

            Invoke("ReturnLastPoint", 3);
        }
    }
    void ReturnLastPoint()
    {
        transform.position = LastPoint;
        controller.enabled = true;
        egg.SetActive(false);
    }
}
