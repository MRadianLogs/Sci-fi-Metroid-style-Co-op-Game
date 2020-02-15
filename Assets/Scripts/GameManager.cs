using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] private GameObject player = null;

    [SerializeField] private int numTargetsLeft = 0;
    [SerializeField] private float timeLeft = 15f;
    [SerializeField] private Text timeLeftText = null;
    [SerializeField] private Text playerPointsText = null;

    
    private void Awake()
    {
        if(gameManager != null && gameManager != this) //If a game manager already exists,
        {
            Destroy(gameObject); //This one is not needed! Destroy it Frodo!
        }
        else //Make this one the game manager.
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        timeLeftText.text = timeLeft.ToString();
        StartCoroutine(TickTime());
    }

    IEnumerator TickTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft -= 1;
            timeLeftText.text = timeLeft.ToString();
            if(timeLeft == 0)
            {
                //End Game. Change scene to game over scene.
                Debug.Log("Times up!");
                SceneManager.LoadScene(2);
            }
        }
    }

    public void DecrementTargetCount()
    {
        numTargetsLeft -= 1;
        if(numTargetsLeft == 0)
        {
            //End game. Change scene to game over scene.
            Debug.Log("All targets gone!");
            SceneManager.LoadScene(2);
        }
    }

    public void IncrementPlayerPoints(int pointsValue)
    {
        player.GetComponent<PlayerBehavior>().incrementPoints(pointsValue);
        DisplayPlayerPoints();
    }
    private void DisplayPlayerPoints()
    {
        playerPointsText.text = player.GetComponent<PlayerBehavior>().PlayerPoints().ToString();
    }
}
