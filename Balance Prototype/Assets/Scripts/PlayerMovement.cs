using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 20.0f;
    private float xRangePos = 11;
    private float xRangeNeg = -7;
    private GameManager gameManager;
    private bool hasPowerup;
    private GameObject[] GOs;
    public ParticleSystem waterSplash;
    public ParticleSystem steamEffect;
    public AudioClip steamSound;
    public AudioClip waterSplashSound;
    private SpriteRenderer[] flames;
    private SpriteRenderer waterDrop;
    private AudioSource waterdropAudio;
   
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        hasPowerup = true;
        waterdropAudio = gameObject.GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {

        gameManager.GameOver();
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        steamEffect.Play();
        waterdropAudio.PlayOneShot(steamSound);

        
        
       
    }
    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hasPowerup)
                {
                    GameObject[] GOs = GameObject.FindGameObjectsWithTag("Flames");
                    for (var i = 0; i < GOs.Length; i++)
                    {
                        // to access component - GOs[i].GetComponent.<BoxCollider>()
                        // but I do it everything in 1 line.
                        GOs[i].gameObject.GetComponentInChildren<ParticleSystem>().Play();
                        GOs[i].gameObject.GetComponent<BoxCollider>().enabled = false;
                        flames = GOs[i].gameObject.GetComponentsInChildren<SpriteRenderer>();
                        foreach (var sr in flames)
                        {
                            sr.enabled = false;
                        }

                    }
                    waterdropAudio.PlayOneShot(waterSplashSound);
                    waterSplash.Play();
                    
                    hasPowerup = false;
                    
                    // now all your game objects are in GOs,
                    // all that remains is to getComponent of each and every script and you are good to go.
                    // to disable a components
                    
                }

            }

            // Check for left and right bounds
            if (transform.position.x < xRangeNeg)
            {
                transform.position = new Vector3(xRangeNeg, transform.position.y, transform.position.z);
            }

            if (transform.position.x > xRangePos)
            {
                transform.position = new Vector3(xRangePos, transform.position.y, transform.position.z);
            }

            // Player movement left to right
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        }
    }
    }


