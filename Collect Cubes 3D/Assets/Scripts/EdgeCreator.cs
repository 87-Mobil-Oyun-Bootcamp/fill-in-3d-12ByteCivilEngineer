using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCreator : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] int cubeCount=30;
    [SerializeField] float dimension=5f;
    GameObject edge;
    private void Start()
    {
        CreateEdge();
    }
    private void CreateEdge()
    {
        edge = new GameObject();
        edge.name = "Edge";
        edge.transform.position = transform.position;
        for (int i = 0; i <= cubeCount; i++)
        {
            Vector3 deltaTransform = new Vector3(dimension / (cubeCount), 0f, dimension / (cubeCount));
            GameObject newCube= Instantiate(cube, transform.position + deltaTransform * (i), Quaternion.identity,edge.transform);
            newCube.transform.Rotate(0f, (90f/(float)cubeCount)*(i), 0f);
            newCube.transform.localScale = new Vector3(newCube.transform.localScale.x, newCube.transform.localScale.y, dimension);
        }
    }

}

