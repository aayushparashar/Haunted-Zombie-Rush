using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance= null;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject gameOverMenu;

    [SerializeField] float xMinPosition;
    [SerializeField] float xMaxPosition;
    [SerializeField] float bottomPosition;
    [SerializeField] float topPosition;
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject coins;

    private bool gameOver = false;
    private bool playerActive = false;
    private bool gameStarted = false;
    public bool GameStarted
    {
        get { return gameStarted; }
    }
    public bool GameOver
    {
        get { return gameOver; }
    }
    public bool PlayerActive
    {
        get { return playerActive; }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 2f);
        InvokeRepeating("SpawnCoins", 5f, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
    void SpawnEnemy()
    {
        float xPosition = Random.Range(xMinPosition, xMaxPosition);
        float yPosition = Random.Range(bottomPosition, topPosition);
        Instantiate(obstacle, new Vector3(xPosition, yPosition, -2.7f), Quaternion.identity);

    }
    void SpawnCoins()
    {
        float xPosition = Random.Range(xMinPosition, xMaxPosition);
        float yPosition = Random.Range(bottomPosition + 2f, topPosition - 2f);
        Instantiate(coins, new Vector3(xPosition, yPosition, -2.7f), Quaternion.identity);

    }
   public void PlayerCollided()
    {
        gameOver = true;
        CancelInvoke("SpawnCoins");
        CancelInvoke("SpawnEnemy");
        gameOverMenu.SetActive(true);
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
        gameOverMenu.SetActive(false);
       // StartGame();
        //playerActive = false;
        //gameOver = false;
       
        
    }
    public void MainMenu()
    {
        gameOverMenu.SetActive(false);
       // gameStarted = false;
       // playerActive = false;
       // gameOver = false;
        SceneManager.LoadScene(0);

    }
 
   public void PlayerStarted()
    {
        playerActive = true;
    }
    
    public void StartGame()
    {
        gameStarted = true;
        menu.SetActive(false);

    }
}
