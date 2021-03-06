using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreText : MonoBehaviour
{
    Text text;
    private void Awake()
    {
        text = GetComponent<Text>();
    }
    public void UpdateText()
    {
        text.text = (GameManager.blocksCollected + " / " + (CubeSpawner.cubeIndex));
    }
}
