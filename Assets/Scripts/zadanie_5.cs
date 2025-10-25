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
        float x = UnityEngine.Random.Range(-4.5f, 4.5f);
        float z = UnityEngine.Random.Range(-4.5f, 4.5f);
        Vector3 position = new Vector3(x, 0.25f, z);
        return position;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int cubesCount = 0;
        while (cubesCount != numberOfCubes)
        {
            Vector3 newPosition = RandomPosition();
            if (!Physics.CheckBox(newPosition, new Vector3(0.5f, 0.20f, 0.5f)))
            {
                var cube = Instantiate(CubePrefab, newPosition, Quaternion.identity);
                cube.transform.SetParent(Plane.transform, true);
                Material cubeMaterial = cube.GetComponent<Renderer>().material;
                cubeMaterial.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
                cubesCount++;
            }
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
