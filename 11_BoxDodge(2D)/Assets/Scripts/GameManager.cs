using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] float startTime = 1f;
    [SerializeField] float repeatingTime = 2f;
    [SerializeField] GameObject box;
    [SerializeField] Vector3 spawnPos;
    [SerializeField] float maxXRange = 2f;
    [SerializeField] TextMeshProUGUI scoreText; 
    [SerializeField] Image titleImage;

    bool gameStarted = false;
    float timeElapsed = 0f;
    int interval = 1;
    public int score = 0;
    
    void Update()
    {
        if (Input.GetMouseButton(0) && !gameStarted)
        {
            titleImage.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(true);
            StartSpawningBlocks();
            gameStarted = true;
        }
        CheckTime();
        IncrementScore();
    }

    void StartSpawningBlocks()
    {
        InvokeRepeating("SpawnBlock", startTime, repeatingTime);
    }

    void SpawnBlock()
    {
        spawnPos.x = Random.Range(-maxXRange, maxXRange);
        Instantiate(box, spawnPos, Quaternion.identity);
    }

    void CheckTime()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > interval * 10)
        {
            repeatingTime -= 0.2f;
            interval += 1;
            CancelInvoke();
            InvokeRepeating("SpawnBlock", startTime, repeatingTime);
        }
    }

    public void IncrementScore()
    {
        //score += 1;
        scoreText.text = score.ToString();
    }
}
