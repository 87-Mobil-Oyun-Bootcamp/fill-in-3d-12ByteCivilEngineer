using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] GameObject tapButton;
    public void PressButton()
    {
        Player.isGameStarted = true;
        Destroy(tapButton);
        Destroy(gameObject);
    }
}
