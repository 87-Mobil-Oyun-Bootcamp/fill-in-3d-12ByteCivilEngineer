using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    bool collided = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!collided)
        {
            collided = true;
            Destroy(other.gameObject);
            int childIndex = transform.GetSiblingIndex();
            transform.parent.GetChild(childIndex - CubeSpawner.cubeIndex).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
