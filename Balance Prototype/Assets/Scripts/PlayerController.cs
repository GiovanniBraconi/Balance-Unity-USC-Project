using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xRangePos = 11;
    private float xRangeNeg = -7;
    public float yRange = 13.9f;
    private GameManager gameManager;
    public ParticleSystem steamParticle;
    private AudioSource steamSound;
    // Start is called before the first frame update
    void Start()
    {
        steamSound = GameObject.Find("Fire Sound").GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {

            BoundCheck();

            gameObject.GetComponent<Rigidbody>().useGravity = true;

            


        }
        AntiFall();
    }
}
