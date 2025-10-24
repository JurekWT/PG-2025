using System;
using Mono.Cecil.Cil;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UIElements;

public class zadanie_5 : MonoBehaviour
{
    public GameObject CubePrefab;
    public GameObject Plane;
    public int numberOfCubes = 10;


    Vector3 RandomPosition()
    {
        float x = UnityEngine.Random.Range(-45f, 45f);
        float z = UnityEngine.Random.Range(-45f, 45f);
        Vector3 position = new Vector3(x, 5, z);
        return position;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
