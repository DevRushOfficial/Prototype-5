using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject gameMenu;
    private float _spawnRate = 1.0f;
    private int _score;

    public bool isGameActive;

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(Difficulty difficulty)
    {
        isGameActive = true;
        _score = 0;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        _spawnRate /= (int)difficulty;
        gameMenu.gameObject.SetActive(false);
    }
}