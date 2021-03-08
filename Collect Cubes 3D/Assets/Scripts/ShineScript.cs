using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShineScript : MonoBehaviour
{

    [SerializeField] Renderer _renderer;
    Color originalColor;

    // Update is called once per frame
    private void Start()
    {
        originalColor = _renderer.material.color;
    }
    void Update()
    {
        _renderer.material.SetColor("_EmissionColor", originalColor*GameManager.timer);
    }
}
