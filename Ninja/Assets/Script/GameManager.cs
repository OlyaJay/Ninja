using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject difficultyWindow;
    public GameObject gameOverText;

    private int score = 0;

    private float spawnRate = 1.5f;

    public bool isGameActive = false;

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;

        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        scoreUpdate(0);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void scoreUpdate(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        gameOverText.SetActive(false);
        difficultyWindow.SetActive(true);
    }
}
