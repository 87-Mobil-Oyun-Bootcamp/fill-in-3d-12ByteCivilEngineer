using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCube : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] BoxCollider _collider;
    GameManager gameManager;

    bool collided = false;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!collided)
        {
            _collider.enabled = false;
            collided = true;
            int childIndex = other.transform.GetSiblingIndex();
            other.transform.parent.GetChild(childIndex - CubeSpawner.cubeIndex).gameObject.SetActive(true);
            gameManager.BlockCollected();
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}
