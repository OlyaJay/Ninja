using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    public GameObject gameOverText;

    private int score = 0;

    private float spawnRate = 1.5f;

    public bool isGameActive = false;
    // Start is called before the first frame update
    void Start()
    {
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
}
