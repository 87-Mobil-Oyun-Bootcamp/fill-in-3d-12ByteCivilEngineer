using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int blocksCollected=0;
    [SerializeField] scoreText scoreText;
    [SerializeField] SliderScript sliderScript;
    public static float timer;
    bool isIncreasing = true;

    public void BlockCollected()
    {
        blocksCollected++;
        UpdateCanvas();
        if (CubeSpawner.cubeIndex == blocksCollected)
        {
            NextLevel();
        }
    }
    public void UpdateCanvas()
    {
        scoreText.UpdateText();
        sliderScript.UpdateSlider();
    }
    private void NextLevel()
    {
        blocksCollected = 0;
        FindObjectOfType<CubeSpawner>().LoadNextLevel();
    }
    private void Update()
    {
        if (isIncreasing)
        {
            timer += Time.deltaTime;
            if (timer >= 1.5f) { isIncreasing = false; }
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0.5f) { isIncreasing = true; }
        }
    }
}
