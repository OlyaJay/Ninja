using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void gameStart(int difficulty)
    {
        gameObject.SetActive(false);
        gameManager.StartGame(difficulty);
    }
    public void returnBtn()
    {
        gameObject.SetActive(false);
        menu.SetActive(true);
    }
}
