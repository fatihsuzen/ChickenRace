using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using DG.Tweening;
public class CharacterMovement : NetworkBehaviour
{
    public float speed = 5;
    public float gravity = -5;
    Animator animator;
    float velocityY = 0;
    bool isRun=false;
    bool eggAnimIsPlaying = false;
    int road1,road2,road3;
    CharacterController controller;    
    public Vector3 LastPoint;
    Vector3 input;
    Vector3 temp;
    Vector3 velocity;
    public List<AudioClip> AudioList = new List<AudioClip>();
    AudioSource audioSource;
    public GameObject Cam;
    public GameObject egg;

    Text RankText;
    [SerializeField]
    public static List<GameObject> PlayerList = new List<GameObject>();
    public List<GameObject> playerList = new List<GameObject>();
    public int PlayerRankNo;
    public GameObject[] someObjects;
    float[] PlayerPosX = new float[20];
    float backUp;
    GameObject backUpPlayer;
    //public ParticleSystem particle;
    void Start()
    {       
        if (isLocalPlayer)
        {
            this.gameObject.name = "LocalPlayer";

            RankText = GameObject.Find("ScoreText").GetComponent<Text>();

            controller = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();

           
            transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(0, 15));
            LastPoint = transform.position;
            
            controller.enabled = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(0, 15));
            controller.enabled = true;
            Cam.SetActive(true);

            InvokeRepeating("RandomIdleAnimation", Random.Range(1f, 3f), Random.Range(4f, 10f));
            InvokeRepeating("CheckPoint",2,0.33f);
            InvokeRepeating("PlayerRank", 1, 0.33f);

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
        if (input.z == 1 && !eggAnimIsPlaying)
        {
            temp += transform.forward;
            animator.SetBool("Run", true);
            animator.SetBool("Turn Head", false);
            animator.SetBool("Eat", false);
            isRun = true;
            RunSound();
        }
        else if (input.z == -1 && !eggAnimIsPlaying)
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
    void PlayerRank()
    {
        
        someObjects = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < someObjects.Length; i++)
        {
            PlayerPosX[i] = someObjects[i].transform.position.x;
        }
        for (int i = 0; i < someObjects.Length; i++)
        {
            for (int j = i + 1; j < someObjects.Length; j++)
            {
                if (PlayerPosX[j] > PlayerPosX[i])
                {
                    backUp = PlayerPosX[i];
                    backUpPlayer = someObjects[i];

                    PlayerPosX[i] = PlayerPosX[j];
                    someObjects[i] = someObjects[j];

                    PlayerPosX[j] = backUp;
                    someObjects[j] = backUpPlayer;
                }
                
            }
            if (someObjects[i].name == "LocalPlayer")
            {
                PlayerRankNo = i+1;
            }
        }
        RankText.text = PlayerRankNo.ToString() + "/"+ someObjects.Length; //Controller.PlayerCount.ToString();
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
    void ReturnLastPoint()
    {
        transform.position = LastPoint;
        controller.enabled = true;

        animator.SetBool("Egg", false);
        eggAnimIsPlaying = false;
        InvokeRepeating("RandomIdleAnimation", Random.Range(1f, 3f), Random.Range(4f, 10f));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Car")
        {
            controller.enabled = false;

            animator.SetBool("Egg", true);
            eggAnimIsPlaying = true;
            CancelInvoke("RandomIdleAnimation");

            audioSource.Stop();
            audioSource.clip = AudioList[1];
            audioSource.Play();
            Invoke("ReturnLastPoint", 3);
        }
    }
  
}
