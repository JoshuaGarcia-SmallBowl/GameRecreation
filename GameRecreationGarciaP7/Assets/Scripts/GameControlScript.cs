using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameControlScript : MonoBehaviour
{
    public static GameControlScript instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private long score = 0;
    public Text scoreText;
    public long income = 1;
    private long NW = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
           Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Scored()
    {
        if (gameOver)
        {
            return;
        }      
        NW = score + income;
        score = NW;
        scoreText.text = "Net Worth:   " + NW.ToString () ;
    }


    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
    public void Sponsor()
    {
        if (gameOver)
        {
            return;
        }
        income = NW * Random.Range(2, 4);
    }
}
