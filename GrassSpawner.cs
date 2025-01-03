using System.Collections;
using UnityEngine;

public class GrassSpawner : MonoBehaviour
{
    [Range(1, 100)] public int totalGrassCount = 100;
    [Range(1, 600)] public int totalDuration = 600; 
    public Terrain parentTerrain;
    public GameObject grassPrefab;

    private void Start()
    {
        StartCoroutine(SpawnGrassRoutine());
    }

    private IEnumerator SpawnGrassRoutine()
    {
        Terrain[] terrains = parentTerrain.GetComponentsInChildren<Terrain>();
        int grassPerTerrain = totalGrassCount / terrains.Length;
        float spawnInterval = 100f; 
        float elapsedTime = 0f;

        while (elapsedTime < totalDuration)
        {
            foreach (Terrain terrain in terrains)
            {
                SpawnGrassOnTerrain(terrain, grassPerTerrain);
            }

            yield return new WaitForSeconds(spawnInterval);
            elapsedTime += spawnInterval;
        }
    }

    private void SpawnGrassOnTerrain(Terrain terrain, int grassCount)
    {
        TerrainData terrainData = terrain.terrainData;
        float terrainWidth = terrainData.size.x;
        float terrainHeight = terrainData.size.z;
        Vector3 terrainPosition = terrain.transform.position;

        float xMin = -1400f; 
        float xMax = 1400f;
        float zMin = -1400f;
        float zMax = 1400f;

        for (int i = 0; i < grassCount; i++)
        {
            float randomX = Random.Range(xMin, xMax);
            float randomZ = Random.Range(zMin, zMax);
            float yPos = 0f;
            Vector3 spawnPosition = new Vector3(randomX, terrainPosition.y + yPos, randomZ);
            Instantiate(grassPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
