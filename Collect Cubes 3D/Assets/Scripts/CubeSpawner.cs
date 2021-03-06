using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [Space]
    [SerializeField] GameObject mobileCubeSpawner;
    [SerializeField]
    float scale=1f;
    [Space]
    [SerializeField]
    List<Sprite> levelImage;
    [Space]
    [SerializeField]
    GameObject block;
    [Space]
    [SerializeField]
    GameObject blackHole;
    [Space]
    [SerializeField]
    GameObject mobileCubes;
    List<GameObject> originalCubes=new List<GameObject>();
    List<GameObject> cubeHoles = new List<GameObject>();
    int currentLevel = 1;

    public static int cubeIndex =0;

    public void CreateLevelImage(int levenNo)
    {
        int width = levelImage[levenNo - 1].texture.width;
        int height = levelImage[levenNo - 1].texture.height;
        for (int z = 0; z < height; z++)
        {
            for(int x = 0; x < width; x++)
            {
                Color color = levelImage[levenNo - 1].texture.GetPixel(x, z);
                if (color.a == 0)
                {
                    continue;
                }
                GameObject createdBlock = Instantiate(block,transform.position,Quaternion.identity,this.transform);
                createdBlock.transform.position = transform.position - new Vector3(x-width*0.5f,0f,z-height*0.5f);
                Renderer _renderer = createdBlock.GetComponent<Renderer>();
                _renderer.material.color = color;
                _renderer.material.SetColor("_EmissionColor", color);

                originalCubes.Add(createdBlock);
                originalCubes[cubeIndex].SetActive(false);
                cubeIndex++;
            }
        }
        CreateCubeHoles();
        CreateMobileCubes();
        transform.localScale = new Vector3(scale, scale, scale);
        transform.Rotate(0f, 180f, 0f);
        gameManager.UpdateCanvas();
    } 
    private void CreateCubeHoles()
    {
        foreach (GameObject element in originalCubes)
        {
            GameObject createdBlackHoles = Instantiate(blackHole, element.transform.position, Quaternion.identity, this.transform);
            cubeHoles.Add(createdBlackHoles);
        }
    }
    private void CreateMobileCubes()
    {
        int i = 0;
        foreach (GameObject element in originalCubes)
        {
            GameObject createdMobileCubes = Instantiate(mobileCubes, mobileCubeSpawner.transform.position + new Vector3(0f,i*mobileCubes.transform.localScale.x,0f), Quaternion.identity);
            i++;
        }
    }
    public void LoadNextLevel()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        currentLevel++;
        cubeIndex = 0;
        originalCubes = new List<GameObject>();
        cubeHoles = new List<GameObject>();
        if (currentLevel == 6)
        {
            currentLevel = 1;
        }
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(1.5f, 1f, -40.5f);
        CreateLevelImage(currentLevel);
    }
}
