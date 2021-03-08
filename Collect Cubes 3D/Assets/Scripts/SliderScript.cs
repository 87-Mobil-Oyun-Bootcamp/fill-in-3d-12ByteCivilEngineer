using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    public void UpdateSlider()
    {
        _slider.value = (float)GameManager.blocksCollected / (float)(CubeSpawner.cubeIndex);
    }
}
