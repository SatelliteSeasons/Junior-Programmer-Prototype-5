using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> targets;

    public float spawnRate = 1;

    public TextMeshProUGUI scoreText;
    public int score;
    public TextMeshProUGUI gameOverText;
    
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject changeGameButton;

    public bool gameActive;

    void Start()
    {
             
    }

    void Update()
    {
        
    }

    public void StartGame(int difficulty)
    {
        gameActive = true;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        score = 0;
        this.UpdateScore(0);
        titleScreen.SetActive(false);
        changeGameButton.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (gameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        changeGameButton.SetActive(true);
        gameActive = false;
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene("Prototype 5");
        // Ou plus sexy :
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
