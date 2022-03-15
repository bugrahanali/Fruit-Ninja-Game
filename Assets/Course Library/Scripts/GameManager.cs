using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> GameObjectList;
    private float spawnRate = 1;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;
    public bool isGameActive;
    public Button restartButton;
    public GameObject diffuctyScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame(int difficulty) 
    {
        
        isGameActive = true;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTargetCoroutin());
        UpdateScore(0);
        diffuctyScreen.SetActive(false);

    }
    
    
    private IEnumerator SpawnTargetCoroutin()
    {

        while (isGameActive )
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, GameObjectList.Count);
            Instantiate(GameObjectList[index]);
        }
    }
    public void UpdateScore( int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;   
        restartButton.gameObject.SetActive(true);
    }

    public void Restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
} 
