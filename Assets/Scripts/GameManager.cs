using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float _spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    private int _score;


    void Start()
    {
        StartCoroutine(SpawnTarget());
        _score = 0;
        scoreText.text = "Score: " + _score;
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
