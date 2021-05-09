using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{

    private GameObject[] flames;
    private bool hasPowerup;
    public ParticleSystem waterSplashParticle;
    private AudioSource waterSplashSound;
    private SpriteRenderer[] flamesSprites;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        waterSplashSound = GameObject.Find("Water Splash Sound").GetComponent<AudioSource>();
        hasPowerup = true;
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
                    DestroyFlames();
                    waterSplashSound.Play();
                    waterSplashParticle.Play();

                    hasPowerup = false;



                }

            }
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
}
