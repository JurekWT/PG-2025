using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int objectLimit = 10;
    // obiekt do generowania
    public GameObject block;
    // obszar generowania obiektów
    public GameObject planeToSpawn;
    // lista materials do wykorzystania
    public Material[] materials;

    void Start()
    {
        var planeRenderer = planeToSpawn.GetComponent<Renderer>();
        var planeBounds = planeRenderer.bounds;
        var minX = planeBounds.min.x;
        var maxX = planeBounds.max.x;
        var minZ = planeBounds.min.z;
        var maxZ = planeBounds.max.z;
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<float> pozycje_x = Enumerable.Range(0, objectLimit).Select(_ => UnityEngine.Random.Range(minX, maxX)).ToList();
        List<float> pozycje_z = Enumerable.Range(0, objectLimit).Select(_ => UnityEngine.Random.Range(minZ, maxZ)).ToList();
        
        for(int i=0; i<objectLimit; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }
        foreach(Vector3 elem in positions){
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach(Vector3 pos in positions)
        {
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            var randomNumber = UnityEngine.Random.Range(0, materials.Length);
            var blockRenderer = block.GetComponent<Renderer>();
            var blockMaterial = blockRenderer.material;
            blockRenderer.material = materials[randomNumber];
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}

