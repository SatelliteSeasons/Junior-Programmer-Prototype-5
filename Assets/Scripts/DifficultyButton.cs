using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    private Button button;
    private GameManager gameManager;
    public int difficultyValue;

    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(setDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    public void setDifficulty()
    {
        Debug.Log("La difficulté est de " + button.gameObject.name);
        gameManager.StartGame(difficultyValue);
    }
}
