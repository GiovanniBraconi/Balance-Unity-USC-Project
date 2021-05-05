using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 20.0f;
    private float xRangePos = 11;
    private float xRangeNeg = -7;
    public float yRange = 13.9f;
    private GameManager gameManager;
    private GameObject[] flames;
    private bool hasPowerup;
    public ParticleSystem waterSplashParticle;
    public ParticleSystem steamParticle;
    private AudioSource steamSound;
    private AudioSource waterSplashSound;
    private SpriteRenderer[] flamesSprites;
    
    
    
   
    
    
    void Start()
    {
        steamSound = GameObject.Find("Fire Sound").GetComponent<AudioSource>();
        waterSplashSound = GameObject.Find("Water Splash Sound").GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        hasPowerup = true;
        

    }

    void Movement()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

    private void OnTriggerEnter(Collider other)
    {

        gameManager.GameOver();
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        steamParticle.Play();
        steamSound.Play();

        
        
       
    }
    void BoundCheck()
    {
        if (transform.position.x < xRangeNeg)
        {
            transform.position = new Vector3(xRangeNeg, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRangePos)
        {
            transform.position = new Vector3(xRangePos, transform.position.y, transform.position.z);
        }
    }
    void AntiFall()
    {
        if (transform.position.y < yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
    }
    void DestroyFlames()
    {
         flames = GameObject.FindGameObjectsWithTag("Flames");
        for (var i = 0; i < flames.Length; i++)
        {
            // to access component - GOs[i].GetComponent.<BoxCollider>()
            // but I do it everything in 1 line.
            flames[i].gameObject.GetComponentInChildren<ParticleSystem>().Play();
            flames[i].gameObject.GetComponent<BoxCollider>().enabled = false;
            flamesSprites = flames[i].gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach (var sr in flamesSprites)
            {
                sr.enabled = false;
            }

        }
    }
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hasPowerup)
                {
                    DestroyFlames();
                    waterSplashSound.Play();
                    waterSplashParticle.Play();
                    
                    hasPowerup = false;
                    
                    
                    
                }

            }
            BoundCheck();
            
            gameObject.GetComponent<Rigidbody>().useGravity = true;

            Movement();
            

        }
        AntiFall();
    }
    }



            


