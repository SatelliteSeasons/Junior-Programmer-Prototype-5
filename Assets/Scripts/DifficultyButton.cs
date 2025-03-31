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
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(setDifficulty);
        
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
