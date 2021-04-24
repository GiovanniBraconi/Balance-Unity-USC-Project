using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    [SerializeField]private TextMeshProUGUI youWonText;
    public GameObject titleScreen;
    public Button restartButton;
    public GameObject pauseMenu;
    public GameObject levelMusic;
    public GameObject finalCutsceneMusic;
    public GameObject textPanelGuide;
    public GameObject player;
    public GameObject timerObj;
    private GameObject[] GOs;
    private SpriteRenderer[] flames;


    public List<GameObject> targetPrefabs;

    private int score;
    private float spawnRate = 1.5f;
    public bool isGameActive;

    private float spawnRangeY = -11;

    private float spawnRangeX = 7.36f;

    private float spawnRangeZ = -0.07f;

    



    private float timeLeft;

    


    
    public void StartGame(int difficulty)
    {
        timerObj.SetActive(true);
        timeLeft = 30;
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        
        
        titleScreen.SetActive(false);
    }

    // While game is active spawn a random target
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);

            if (isGameActive)
            {
                Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
            }

        }
    }

    // Generate a random spawn position based on a random index from 0 to 3
    Vector3 RandomSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX,spawnRangeX), spawnRangeY, spawnRangeZ);
        return spawnPosition;

    }

   

   



    // Update score with value from target clicked
    

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        if (timeLeft < 0)
        {
            youWonText.gameObject.SetActive(true);
        }
        else {
            gameOverText.gameObject.SetActive(true); 
        }
        
        restartButton.gameObject.SetActive(true);
        

        isGameActive = false;

    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        CountDownTimer();
    }
    public void CountDownTimer()
    {
        if (isGameActive)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(timeLeft);
            if (timeLeft < 0)
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
                    levelMusic.GetComponent<AudioSource>().Stop();
                finalCutsceneMusic.GetComponent<AudioSource>().Play();
                GameOver();
                player.GetComponent<PlayerMovement>().yRange = -2f;
                player.GetComponent<SphereCollider>().enabled = false;
                player.GetComponent<Rigidbody>().velocity = new Vector3(0, -17, 0);
               

            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
    void PauseGame()
    {
        if (isGameActive)
        { 
          Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(true);
              
              
            
        }
    }

    public void ResumeGame()
    {
        if (isGameActive)
        {
          Time.timeScale = 1;
            pauseMenu.gameObject.SetActive(false);
        }
       
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

}